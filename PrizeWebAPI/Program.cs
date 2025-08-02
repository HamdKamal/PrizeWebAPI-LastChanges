using Application.Abstractions.Common;
using Application.Features.Forms.Commands.CreateNewForm;
using Application.Features.Forms.Commands.FormSubmissions.UpdateFormSubmissions;
using Application.Features.Forms.Commands.ReviewComments.UpdateReviewComments;
using Application.Features.Forms.Commands.UpdateNewForm;
using Application.Features.Forms.Commands.FormSubmissions.DeleteFormSubmission;
using Application.Features.Forms.Commands.FormSubmissions.SendReminderEmails;
using Application.Features.Forms.Queries.FormSubmissions.GetFormSubmissions;
using Application.Features.Forms.Queries.GetNewForm.GetNewDepartmentForm;
using Application.Features.Forms.Queries.GetNewForm.GetNewIndividualForm;
using Application.Features.Forms.Queries.GetSavedForm;
using Application.Features.Forms.Queries.GetSavedForm.GetSavedCreativityForm;
using Application.Features.Forms.Queries.GetSavedForm.GetSavedDistinguishedManagementForm;
using Application.Features.Forms.Queries.ReviewComments.GetReviewComments;
using Application.Features.Forms.Queries.Statuses;
using Application.Mapping;
using Application.Models.Common;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using PrizeWebAPI.Extensions;
using PrizeWebAPI.Mapping;
using PrizeWebAPI.Models;
using Hangfire;
using System;

var builder = WebApplication.CreateBuilder(args);

// Manually register AutoMapper and scan profiles
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AdminDashboardListProfile());
    mc.AddProfile(new CategoryProfile());
    mc.AddProfile(new DashboardListProfile());
    mc.AddProfile(new DepartmentFormProfile());
    mc.AddProfile(new FormSectionProfile());
    mc.AddProfile(new FormSubmissionProfile());
    mc.AddProfile(new FormSubSectionProfile());
    mc.AddProfile(new IndividualFormProfile());
    mc.AddProfile(new OptionProfile());
    mc.AddProfile(new ParticipantProfile());
    mc.AddProfile(new QuestionOptionProfile());
    mc.AddProfile(new QuestionProfile());
    mc.AddProfile(new QuestionTypeProfile());
    mc.AddProfile(new ReviewCommentProfile());
    mc.AddProfile(new SavedFormProfile());
    mc.AddProfile(new SavedCreativityFormProfile());
    mc.AddProfile(new SavedDistinguishedManagementFormProfile());
    mc.AddProfile(new StatusProfile());
    mc.AddProfile(new SubmittedAnswerProfile());
    mc.AddProfile(new SubmittedAttachmentProfile());
});

mapperConfig.AssertConfigurationIsValid();
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(typeof(VEmployeeRecordAllMappingProfile).Assembly);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.ConfigureAuthenticationSettings(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v2", new OpenApiInfo { Title = " API", Version = "v2" }); });

// Register DbContexts
builder.Services.AddDbContext<PrizeDbContext>(options =>
      options.UseSqlServer(
          builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string DefaultConnection not found"),
          options => options.EnableRetryOnFailure()
      )
);

builder.Services.AddDbContext<SWCCSharedDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("SWCCSharedDatabase")));
//builder.Services.AddScoped<SWCCSharedDbContext>(provider => provider.GetService<SWCCSharedDbContext>());

builder.Services.Configure<EmailConfigurationModel>(builder.Configuration.GetSection("EmailConfiguration"));

builder.Services.AddSingleton(sp =>
    builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfigurationModel>()
);

//file upload size limit and form data value count limit
builder.Services.Configure<FormOptions>(options =>
{
    options.ValueCountLimit = int.MaxValue; // Increase form field limit
    options.MultipartBodyLengthLimit = 2L * 1024 * 1024 * 1024; // 2 GB
});

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 2L * 1024 * 1024 * 1024; // 2 GB
});

builder.Services.AddHttpContextAccessor();


//Register Notification 
builder.Services.AddScoped<INotificationService, EmailNotificationService>();
builder.Services.AddScoped<IViewRendererService, ViewRendererService>();

//Register AuthService
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService>();

//Register QueryHandlers
builder.Services.AddTransient<IGetFormSubmissionQueryHandler, GetFormSubmissionQueryHandler>();
builder.Services.AddTransient<IGetNewDepartmentFormQueryHandler, GetNewDepartmentFormQueryHandler>();
builder.Services.AddTransient<IGetNewIndividualFormQueryHandler, GetNewIndividualFormQueryHandler>();
builder.Services.AddTransient<IGetSavedFormQueryHandler, GetSavedFormQueryHandler>();
builder.Services.AddTransient<IGetSavedCreativityFormQueryHandler, GetSavedCreativityFormQueryHandler>();
builder.Services.AddTransient<IGetSavedDistinguishedManagementFormQueryHandler, GetSavedDistinguishedManagementFormQueryHandler>();
builder.Services.AddTransient<IGetStatusesQueryHandler, GetStatusesQueryHandler>(); 
builder.Services.AddTransient<IGetSubmittedAttachmentsQueryHandler, GetSubmittedAttachmentsQueryHandler>();
builder.Services.AddTransient<IGetReviewCommentQueryHandler, GetReviewCommentQueryHandler>();

//Register CommandHandlers
builder.Services.AddTransient<ICreateNewFormCommandHandler, CreateNewFormCommandHandler>();
builder.Services.AddTransient<IUpdateFormCommandHandler, UpdateFormCommandHandler>();
builder.Services.AddTransient<IUpdateFormSubmissionCommandHandler, UpdateFormSubmissionCommandHandler>();
builder.Services.AddTransient<IUpdateReviewCommentCommandHandler, UpdateReviewCommentCommandHandler>();

// Register custom command handlers for deleting submissions and sending reminders
builder.Services.AddTransient<IDeleteFormSubmissionCommandHandler, DeleteFormSubmissionCommandHandler>();
builder.Services.AddTransient<ISendReminderEmailsCommandHandler, SendReminderEmailsCommandHandler>();

//Register Repositories
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IFormSectionRepository, FormSectionRepository>();
builder.Services.AddTransient<IFormSubmissionRepository, FormSubmissionRepository>();
builder.Services.AddTransient<IFormSubSectionRepository, FormSubSectionRepository>();
builder.Services.AddTransient<IParticipantRepository, ParticipantRepository>();
builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<IReviewCommentRepository, ReviewCommentRepository>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<ISubmittedAnswerRepository, SubmittedAnswerRepository>();
builder.Services.AddTransient<ISubmittedAttachmentRepository, SubmittedAttachmentRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Register the admin repository which allows checking if a user is an admin
builder.Services.AddTransient<IAdminRepository, AdminRepository>();


builder.Services.AddCors(options =>
    options.AddPolicy("CorsPolicy",
    builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().SetIsOriginAllowed((host) => true))
);

//// Allow all origins (for development only)
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowLocalhost3000", policy =>
//    {
//        policy.WithOrigins("http://localhost:3000")
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});


builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings"));

builder.Services.Configure<JWTModel>(builder.Configuration.GetSection("JWTValidator"));

// Configure Hangfire for background job scheduling
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //app.UseSwagger(options =>
    //{
    //    options.SerializeAsV2 = true;
    //});

    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("../swagger/v2/swagger.json", "API V2");
    //});
}

app.UseHttpsRedirection();

// Configure Hangfire dashboard for monitoring background jobs
// You may restrict access to this dashboard through authentication policies if desired.
app.UseHangfireDashboard();

var forwardingOptions = new ForwardedHeadersOptions() { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.All };
app.UseForwardedHeaders(forwardingOptions);

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Append("Referrer-Policy", "no-referrer");
    context.Response.Headers.Append("X-Permitted-Cross-Domain-Policies", "none");
    context.Response.Headers.Append("Content-Security-Policy", "default-src * 'unsafe-inline' 'unsafe-eval'; script-src * 'unsafe-inline' 'unsafe-eval'; connect-src * 'unsafe-inline'; img-src * data: blob: 'unsafe-inline'; frame-src *; style-src * 'unsafe-inline';");
    context.Response.Headers.Remove("X-AspNet-Version");
    context.Response.Headers.Remove("X-Powered-By");
    context.Response.Headers.Remove("Server");

    await next.Invoke();
});

app.UseCors("CorsPolicy");
//app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// Register a recurring job to send reminder emails daily
using (var scope = app.Services.CreateScope())
{
    var reminderHandler = scope.ServiceProvider.GetRequiredService<ISendReminderEmailsCommandHandler>();
    RecurringJob.AddOrUpdate(
        "send-reminder-emails-job",
        () => reminderHandler.HandleAsync(new DateTime(2025, 8, 31)),
        Cron.Daily);
}

app.Run();
