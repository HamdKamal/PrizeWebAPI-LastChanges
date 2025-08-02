using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasComment = table.Column<bool>(type: "bit", nullable: false),
                    IsCommentRequired = table.Column<bool>(type: "bit", nullable: false),
                    CommentLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentPlaceholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false),
                    IsAttachmentRequired = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentPlaceholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormSections_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    LastSubmittedSectionId = table.Column<int>(type: "int", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormSubmissions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormSubmissions_FormSections_LastSubmittedSectionId",
                        column: x => x.LastSubmittedSectionId,
                        principalTable: "FormSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormSubmissions_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormSubSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormSectionId = table.Column<int>(type: "int", nullable: false),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false),
                    IsAttachmentRequired = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentPlaceholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSubSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormSubSections_FormSections_FormSectionId",
                        column: x => x.FormSectionId,
                        principalTable: "FormSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_FormSubmissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "FormSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionPlaceholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerPlaceholder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    FormSubSectionId = table.Column<int>(type: "int", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_FormSubSections_FormSubSectionId",
                        column: x => x.FormSubSectionId,
                        principalTable: "FormSubSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: true),
                    OptionComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedAnswers_FormSubmissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "FormSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmittedAnswers_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittedAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    SubSectionId = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    OptionId = table.Column<int>(type: "int", nullable: true),
                    AttachmentTypeId = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedAttachments_AttachmentTypes_AttachmentTypeId",
                        column: x => x.AttachmentTypeId,
                        principalTable: "AttachmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittedAttachments_FormSubSections_SubSectionId",
                        column: x => x.SubSectionId,
                        principalTable: "FormSubSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittedAttachments_FormSubmissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "FormSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmittedAttachments_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittedAttachments_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AttachmentTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Form Attachment", true, false },
                    { 2, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Sub Section Attachment", true, false },
                    { 3, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Question Attachment", true, false }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "فئة الإدارة المميزة", true, false },
                    { 2, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "فئة الإبداع", true, false }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "AttachmentLabel", "AttachmentPlaceholder", "CommentLabel", "CommentPlaceholder", "CreatedAt", "CreatedBy", "HasAttachment", "HasComment", "IsAttachmentRequired", "IsCommentRequired", "LastModifiedAt", "LastModifiedBy", "Title", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 1, "* ارفاق الدليل", " يرجى إرفاق الشهادات (مرفقة بجميع التنسيقات حتى 30 ميجابايت)", "أضف تعليقات (اختياري)", "أضف تعليقات", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", true, true, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "متوفر", true, false },
                    { 2, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "غير متوفر", true, false }
                });

            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Single Choice", true, false },
                    { 2, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Multiple Choice", true, false },
                    { 3, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Dropdown", true, false },
                    { 4, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Text Box", true, false },
                    { 5, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Text Area", true, false },
                    { 6, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Number", true, false },
                    { 7, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Date", true, false }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Draft", true, false },
                    { 2, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Applied", true, false },
                    { 3, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Under Review", true, false },
                    { 4, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Reset", true, false },
                    { 5, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Accepted", true, false },
                    { 6, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Denied", true, false },
                    { 7, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Expired Without Modification", true, false },
                    { 8, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "Reapply", true, false }
                });

            migrationBuilder.InsertData(
                table: "FormSections",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name", "OrderIndex", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تحقيق الرؤية والاستراتيجية", 1, true, false },
                    { 2, 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "القيم والثقافة المؤسسية", 2, true, false },
                    { 3, 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تمكين العاملين", 3, true, false },
                    { 4, 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "الحوكمة وإدارة الأداء", 4, true, false },
                    { 5, 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "التفاعل الإيجابي مع أصحاب المصلحة", 5, true, false },
                    { 6, 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "إضافة قيمة للمستفيدين", 6, true, false },
                    { 7, 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "التحول الرقمي وقيادة التغيير", 7, true, false }
                });

            migrationBuilder.InsertData(
                table: "FormSubSections",
                columns: new[] { "Id", "AttachmentLabel", "AttachmentPlaceholder", "CreatedAt", "CreatedBy", "FormSectionId", "HasAttachment", "IsAttachmentRequired", "LastModifiedAt", "LastModifiedBy", "Name", "OrderIndex", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 1, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "إعداد وبناء الأنظمة الداعمة لتنفيذ الاستراتيجية", 1, true, false },
                    { 2, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "إﻋﺪاد ﺧﻄﺔ ﺗﺸﻐﻴﻠﻴﺔ، ﺗﺘﻨﺎﺳﺐ ﻣﻊ أﻫﺪاف اﻟﻬﻴﺌﺔ اﻻﺳﱰاﺗﻴﺠﻴﺔ", 2, true, false },
                    { 3, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تشجيع وتحفيز العاملين للمبادرة والمشاركة في تعزيز القيم والسلوك الإيجابي المنشود", 1, true, false },
                    { 4, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "الاهتمام بموظفي الإدارة لرفع الكفاءة مما يحسن الصورة الذهنية عن الإدارة وخدماتها لدى المستفيدين", 1, true, false },
                    { 5, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "وجود خطة لإدارة المخاطر", 1, true, false },
                    { 6, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "وضع واعتماد وتطبيق المعايير والإجراءات والضوابط والاشتراطات ونماذج العمل المطلوبة", 2, true, false },
                    { 7, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تحديد وفهم متطلبات التشريعات الخارجية ذات الصلة", 3, true, false },
                    { 8, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "وجود إطار تنظيمي تنسيقي يحكم العلاقة مع الإدارات والجهات ذات العلاقة (أصحاب المصلحة)", 4, true, false },
                    { 9, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 5, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تطوير شراكات ومبادرات في ضوء الاحتياجات", 1, true, false },
                    { 10, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تطبيق منهج يضمن مراجعة وتحسين الخدمات والعمليات وإجراءات العمل بصورة مستمرة", 1, true, false },
                    { 11, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تحديد المستفيدين وتصنيفهم والتعرف على احتياجاتهم وتوقعاتهم", 2, true, false },
                    { 12, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "وجود قنوات وأساليب لتفعيل أنظمة التغذية الراجعة بغرض تحديد فرص التحسين", 3, true, false },
                    { 13, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", " تحديد وتحسين ومراقبة سلسلة القيمة في كافة مراحلها", 4, true, false },
                    { 14, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", " وضع وتطبيق أساليب وبرامج فعالة للتوعية والتعريف بالخدمات والمنتجات التي تقدمها للمستفيدين الحاليين والمتوقعين مستقبلاً", 5, true, false },
                    { 15, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تحديد وتعميم أهداف ومجالات الإبداع والابتكار", 1, true, false },
                    { 16, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تحديد وتوفير القنوات ووسائل التواصل", 2, true, false },
                    { 17, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "توفير بيئة محفزة للبحث والتجربة وتقديم الأفكار الإبداعية", 3, true, false },
                    { 18, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "التوعية والتهيئة للتغيير", 4, true, false },
                    { 19, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", " دعم البحوث والدراسات", 5, true, false },
                    { 20, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "الاستفادة من التقنيات الحديثة وتطبيق نظم للرقمنة وأتمتة العمليات، وتدريب العاملين على استخدامها", 6, true, false },
                    { 21, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تحديد وجمع البيانات اللازمة لدعم خطط التحول وإدارة التغيير", 7, true, false },
                    { 22, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", " وجود أنظمة وأساليب فاعلة لحفظ وأرشفة واستدعاء المعلومات والبيانات المطلوبة", 8, true, false },
                    { 23, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "استخدام أنظمة الذكاء الاصطناعي وتحليل البيانات لاستخراج المعارف", 9, true, false },
                    { 24, "شواهد اخرى", "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تبادل التجارب والمعارف والممارسات والدروس المستفادة", 10, true, false }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnswerPlaceholder", "CreatedAt", "CreatedBy", "FormSubSectionId", "IsRequired", "LastModifiedAt", "LastModifiedBy", "OrderIndex", "QuestionPlaceholder", "QuestionTypeId", "Title", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* المنهجية المستخدمة في تنفيذ الاستراتيجية مع الأدلة على تفعليها", true, false },
                    { 2, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* قائمة تحديد الأولويات الاستراتيجية والاحتياجات المطلوبة لمرحلة التنفيذ", true, false },
                    { 3, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, null, 1, "* قائمة الأهداف المرتبطة مع الاستراتيجية ومؤشرات الأداء الخاصة بالإدارة", true, false },
                    { 4, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* التقارير الدورية لمتابعة تنفيذ الخطة وفقاً لمؤشرات الإدارة التشغيلية", true, false },
                    { 5, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* محاضر اجتماعات لمناقشة تقارير الأداء مع الإجراءات التصحيحية المتخذة في عملية القياس", true, false },
                    { 6, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* أمثلة تعكس وجود بيئة تحفيزية لتعزيز القيم", true, false },
                    { 7, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* تقديم وتوضيح أمثلة للمبادرات والبرامج التي تعمل على تعزيز القيم", true, false },
                    { 8, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* تقارير مشاركة العاملين في برامج التدريب والتطوير المهني", true, false },
                    { 9, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* أدلة على تنفيذ برامج لتبادل المعرفة", true, false },
                    { 10, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 5, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* سجل المخاطر الخاص بالإدارة", true, false },
                    { 11, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* قائمة الإجراءات والسياسات واللوائح والنماذج والأدلة ذات الصلة بأعمال الإدارة", true, false },
                    { 12, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* مصفوفة الصلاحيات والمسؤوليات المعتمدة للإدارة", true, false },
                    { 13, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, null, 1, "* نماذج لتنفيذ الأعمال والأنشطة وفقا للإجراءات والمنهجيات المعتمدة", true, false },
                    { 14, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* قائمة المتطلبات القانونية والتشريعية ذات الصلة بالإدارة", true, false },
                    { 15, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* أدلة على رصد التغييرات وآليات المواءمة معها", true, false },
                    { 16, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 8, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* إطار فهم أصحاب المصلحة", true, false },
                    { 17, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 8, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* أمثلة على تحديث الإطار بشكل دوري", true, false },
                    { 18, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 9, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* الشراكات والمبادرات التي تم تنفيذها، وأثرها الإيجابي على الهيئة", true, false },
                    { 19, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 9, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* خطط التحسين والتطوير للمبادرات", true, false },
                    { 20, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 9, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, null, 1, "* تفعيل الشراكات والاتفاقيات الإستراتيجية وفقاً لبنود الشراكة ذات المنفعة", true, false },
                    { 21, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 10, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* الخطة السنوية لتحسين الإجراءات والعمليات", true, false },
                    { 22, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 10, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* قائمة التحسينات التي تم تنفيذها  على الخدمات والإجراءات وأثر ذلك على العمل", true, false },
                    { 23, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 11, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* شواهد للمقترحات والأفكار الإبداعية المقدمة من قبل المعنيين", true, false },
                    { 24, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 11, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* عينة لاستطلاع آراء المستفيدين وأخذ المقترحات", true, false },
                    { 25, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 11, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, null, 1, "* نماذج للقاءات والفعاليات", true, false },
                    { 26, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 11, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, null, 1, "*  قائمة المستفيدين وتصنيفاتهم", true, false },
                    { 27, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 11, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 5, null, 1, "* قائمة احتياجات وتوقعات المستفيدين", true, false },
                    { 28, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 12, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* أدلة على القيام بأخذ التغذية الراجعة عن طريق مجموعات التركيز، المسوحات واستطلاعات الرأي، العاملين المباشرين في التعامل مع المستفيدين أو أي أساليب أخرى", true, false },
                    { 29, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 12, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* نماذج للشكاوى وطرق معالجتها", true, false },
                    { 30, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 13, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "*  دراسة توضح رحلة العميل ونقاط التحسين التي تم حصرها والتحسين الذي تم تنفيذه أو خطط له بناء على هذه الدراسة", true, false },
                    { 31, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 14, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* تفعيل الموقع الإلكتروني للتعريف بالإدارة والخدمات التي تقدمها، والمهام والسياسات والوحدات التابعة لها (مع إدراج رابط صفحة الإدارة بالموقع الإلكتروني)", true, false },
                    { 32, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 14, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "*  قائمة الخدمات على أن تشمل (اسم الخدمة، تعريف الخدمة، قنوات تقديم الخدمة، الجهة المستفيدة، الفئة المستهدفة، مدة تنفيذ الخدمة)", true, false },
                    { 33, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 14, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, null, 1, "*   فعاليات وأدوات التوعية والتعريف بالخدمات والمنتجات المقدمة للمستفيدين", true, false },
                    { 34, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 15, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* محضر أو تقرير يوضح مخرجات تنفيذ الأساليب والإجراءات لتحديد مجالات الابداع والابتكار", true, false },
                    { 35, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 15, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* وجود قائمة بمجالات الإبداع والتحسين المستهدفة لتحقيق أهداف الإدارة", true, false },
                    { 36, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 16, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* دليل على وجود قنوات ووسائل تمكن من استقبال الأفكار والابتكارات", true, false },
                    { 37, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 17, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* أدلة توضح تطبيق منهجيات وأساليب تحفيز تقديم الأفكار الابداعية", true, false },
                    { 38, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 17, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* قائمة الأفكار الإبداعية والابتكارات المرصودة", true, false },
                    { 39, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 17, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, null, 1, "* نماذج لأفكار وحلول تم تبنيها ورعايتها بواسطة الإدارة", true, false },
                    { 40, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 18, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* دليل على توعية وتهيئة العاملين للتغيير والتحول", true, false },
                    { 41, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 19, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* نماذج للبحوث التي تم دعمها", true, false },
                    { 42, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 19, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* نماذج للبحوث والدراسات المخطط تنفيذها", true, false },
                    { 43, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 19, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, null, 1, "* قائمة البحوث الموجودة بالإدارة", true, false },
                    { 44, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 20, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* تقديم أدلة على توظيف وتفعيل الأنظمة والتقنيات الحديثة", true, false },
                    { 45, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 20, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, null, 1, "* قائمة الإجراءات المؤتمتة", true, false },
                    { 46, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 20, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, null, 1, "* قائمة البرامج والدورات التدريبية المقدمة للعاملين في مجال إدارة وتطوير العمليات واستخدام التقنيات", true, false },
                    { 47, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 20, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, null, 1, "* صور الأنظمة التقنية المستخدمة", true, false },
                    { 48, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 21, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* نماذج توضح قيام الإدارة بجمع وتصنيف البيانات", true, false },
                    { 49, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 22, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* دليل يوضح آلية الأرشفة وحفظ واستدعاء المعلومات", true, false },
                    { 50, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 23, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* نماذج لتقارير تحليل البيانات", true, false },
                    { 51, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 24, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 1, "* أدلة على تنفيذ منهجيات لتبادل المعارف والخبرات بين العاملين", true, false }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "OptionId", "QuestionId", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 1, true, false },
                    { 2, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 1, true, false },
                    { 3, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 2, true, false },
                    { 4, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 2, true, false },
                    { 5, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 3, true, false },
                    { 6, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 3, true, false },
                    { 7, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 4, true, false },
                    { 8, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 4, true, false },
                    { 9, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 5, true, false },
                    { 10, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 5, true, false },
                    { 11, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 6, true, false },
                    { 12, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 6, true, false },
                    { 13, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 7, true, false },
                    { 14, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 7, true, false },
                    { 15, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 8, true, false },
                    { 16, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 8, true, false },
                    { 17, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 9, true, false },
                    { 18, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 9, true, false },
                    { 19, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 10, true, false },
                    { 20, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 10, true, false },
                    { 21, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 11, true, false },
                    { 22, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 11, true, false },
                    { 23, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 12, true, false },
                    { 24, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 12, true, false },
                    { 25, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 13, true, false },
                    { 26, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 13, true, false },
                    { 27, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 14, true, false },
                    { 28, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 14, true, false },
                    { 29, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 15, true, false },
                    { 30, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 15, true, false },
                    { 31, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 16, true, false },
                    { 32, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 16, true, false },
                    { 33, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 17, true, false },
                    { 34, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 17, true, false },
                    { 35, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 18, true, false },
                    { 36, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 18, true, false },
                    { 37, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 19, true, false },
                    { 38, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 19, true, false },
                    { 39, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 20, true, false },
                    { 40, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 20, true, false },
                    { 41, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 21, true, false },
                    { 42, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 21, true, false },
                    { 43, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 22, true, false },
                    { 44, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 22, true, false },
                    { 45, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 23, true, false },
                    { 46, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 23, true, false },
                    { 47, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 24, true, false },
                    { 48, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 24, true, false },
                    { 49, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 25, true, false },
                    { 50, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 25, true, false },
                    { 51, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 26, true, false },
                    { 52, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 26, true, false },
                    { 53, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 27, true, false },
                    { 54, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 27, true, false },
                    { 55, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 28, true, false },
                    { 56, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 28, true, false },
                    { 57, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 29, true, false },
                    { 58, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 29, true, false },
                    { 59, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 30, true, false },
                    { 60, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 30, true, false },
                    { 61, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 31, true, false },
                    { 62, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 31, true, false },
                    { 63, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 32, true, false },
                    { 64, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 32, true, false },
                    { 65, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 33, true, false },
                    { 66, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 33, true, false },
                    { 67, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 34, true, false },
                    { 68, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 34, true, false },
                    { 69, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 35, true, false },
                    { 70, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 35, true, false },
                    { 71, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 36, true, false },
                    { 72, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 36, true, false },
                    { 73, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 37, true, false },
                    { 74, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 37, true, false },
                    { 75, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 38, true, false },
                    { 76, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 38, true, false },
                    { 77, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 39, true, false },
                    { 78, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 39, true, false },
                    { 79, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 40, true, false },
                    { 80, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 40, true, false },
                    { 81, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 41, true, false },
                    { 82, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 41, true, false },
                    { 83, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 42, true, false },
                    { 84, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 42, true, false },
                    { 85, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 43, true, false },
                    { 86, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 43, true, false },
                    { 87, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 44, true, false },
                    { 88, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 44, true, false },
                    { 89, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 45, true, false },
                    { 90, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 45, true, false },
                    { 91, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 46, true, false },
                    { 92, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 46, true, false },
                    { 93, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 47, true, false },
                    { 94, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 47, true, false },
                    { 95, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 48, true, false },
                    { 96, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 48, true, false },
                    { 97, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 49, true, false },
                    { 98, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 49, true, false },
                    { 99, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 50, true, false },
                    { 100, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 50, true, false },
                    { 101, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, 51, true, false },
                    { 102, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, 51, true, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormSections_CategoryId",
                table: "FormSections",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmissions_CategoryId",
                table: "FormSubmissions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmissions_LastSubmittedSectionId",
                table: "FormSubmissions",
                column: "LastSubmittedSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmissions_StatusId",
                table: "FormSubmissions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubSections_FormSectionId",
                table: "FormSubSections",
                column: "FormSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_SubmissionId",
                table: "Participants",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_OptionId",
                table: "QuestionOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_QuestionId",
                table: "QuestionOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FormSubSectionId",
                table: "Questions",
                column: "FormSubSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswers_OptionId",
                table: "SubmittedAnswers",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswers_QuestionId",
                table: "SubmittedAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswers_SubmissionId",
                table: "SubmittedAnswers",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAttachments_AttachmentTypeId",
                table: "SubmittedAttachments",
                column: "AttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAttachments_OptionId",
                table: "SubmittedAttachments",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAttachments_QuestionId",
                table: "SubmittedAttachments",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAttachments_SubmissionId",
                table: "SubmittedAttachments",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAttachments_SubSectionId",
                table: "SubmittedAttachments",
                column: "SubSectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropTable(
                name: "SubmittedAnswers");

            migrationBuilder.DropTable(
                name: "SubmittedAttachments");

            migrationBuilder.DropTable(
                name: "AttachmentTypes");

            migrationBuilder.DropTable(
                name: "FormSubmissions");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "FormSubSections");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "FormSections");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
