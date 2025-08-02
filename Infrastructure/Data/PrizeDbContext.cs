
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Core.Entities;

namespace Infrastructure.Data;

public class PrizeDbContext(DbContextOptions<PrizeDbContext> options) : DbContext(options)
{
    public DbSet<AttachmentType> AttachmentTypes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FormSection> FormSections { get; set; }
    public DbSet<FormSubmission> FormSubmissions { get; set; }
    public DbSet<FormSubSection> FormSubSections { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<QuestionType> QuestionTypes { get; set; }
    public DbSet<ReviewComment> ReviewComments { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<SubmittedAnswer> SubmittedAnswers { get; set; }
    public DbSet<SubmittedAttachment> SubmittedAttachments { get; set; }
    public DbSet<AdminUser> AdminUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttachmentType>()
            .HasKey(a => a.Id); // Primary Key

        modelBuilder.Entity<AttachmentType>()
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();  // Auto-increment


        modelBuilder.Entity<Category>()
            .HasKey(c => c.Id); // Primary Key

        modelBuilder.Entity<Category>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<FormSection>()
           .HasKey(f => f.Id); // Primary Key

        modelBuilder.Entity<FormSection>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<FormSection>()
            .HasOne(f => f.Category) // Navigation
            .WithMany(c => c.Sections)
            .HasForeignKey(f => f.CategoryId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FormSubmission>()
           .HasKey(f => f.Id); // Primary Key

        modelBuilder.Entity<FormSubmission>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<FormSubmission>()
            .HasOne(f => f.Category) // Navigation
            .WithMany(c => c.Submissions)
            .HasForeignKey(f => f.CategoryId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FormSubmission>()
            .HasOne(f => f.Status) // Navigation
            .WithMany(c => c.Submissions)
            .HasForeignKey(f => f.StatusId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FormSubmission>()
            .HasOne(f => f.LastSubmittedSection) // Navigation
            .WithMany(c => c.Submissions)
            .HasForeignKey(f => f.LastSubmittedSectionId) // Foreign Key
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FormSubSection>()
           .HasKey(f => f.Id); // Primary Key

        modelBuilder.Entity<FormSubSection>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<FormSubSection>()
            .HasOne(f => f.FormSection) // Navigation
            .WithMany(c => c.SubSections)
            .HasForeignKey(f => f.FormSectionId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Option>()
           .HasKey(q => q.Id); // Primary Key

        modelBuilder.Entity<Option>()
            .Property(q => q.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<Participant>()
           .HasKey(q => q.Id); // Primary Key

        modelBuilder.Entity<Participant>()
            .Property(q => q.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<Participant>()
            .HasOne(f => f.FormSubmission) // Navigation
            .WithMany(c => c.Participants)
            .HasForeignKey(f => f.SubmissionId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Question>()
           .HasKey(q => q.Id); // Primary Key

        modelBuilder.Entity<Question>()
            .Property(q => q.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<Question>()
            .HasOne(q => q.QuestionType) // Navigation
            .WithMany(c => c.Questions)
            .HasForeignKey(q => q.QuestionTypeId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Question>()
            .HasOne(q => q.FormSubSection) // Navigation
            .WithMany(f => f.Questions)
            .HasForeignKey(q => q.FormSubSectionId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<QuestionOption>()
           .HasKey(q => q.Id); // Primary Key

        modelBuilder.Entity<QuestionOption>()
            .Property(q => q.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<QuestionOption>()
            .HasOne(qa => qa.Question) // Navigation
            .WithMany(q => q.QuestionOptions)
            .HasForeignKey(qa => qa.QuestionId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<QuestionOption>()
           .HasOne(q => q.Option) // Navigation
           .WithMany(a => a.QuestionOptions)
           .HasForeignKey(q => q.OptionId) // Foreign Key
           .IsRequired()
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<QuestionType>()
           .HasKey(q => q.Id); // Primary Key

        modelBuilder.Entity<QuestionType>()
            .Property(q => q.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<ReviewComment>()
          .HasKey(f => f.Id); // Primary Key

        modelBuilder.Entity<ReviewComment>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<ReviewComment>()
            .HasOne(f => f.FormSubmission) // Navigation
            .WithMany(c => c.ReviewComments)
            .HasForeignKey(f => f.FormSubmissionId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReviewComment>()
            .HasOne(f => f.Question) // Navigation
            .WithMany(c => c.ReviewComments)
            .HasForeignKey(f => f.QuestionId) // Foreign Key
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReviewComment>()
            .HasOne(f => f.FormSubSection) // Navigation
            .WithMany(c => c.ReviewComments)
            .HasForeignKey(f => f.FormSubSectionId) // Foreign Key
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Status>()
           .HasKey(s => s.Id); // Primary Key

        modelBuilder.Entity<Status>()
            .Property(s => s.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<SubmittedAnswer>()
           .HasKey(s => s.Id); // Primary Key

        modelBuilder.Entity<SubmittedAnswer>()
            .Property(s => s.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<SubmittedAnswer>()
            .HasOne(s => s.Submission) // Navigation
            .WithMany(sa => sa.SubmittedAnswers)
            .HasForeignKey(s => s.SubmissionId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubmittedAnswer>()
         .HasOne(s => s.SubSection) // Navigation
         .WithMany(sa => sa.SubmittedAnswers)
         .HasForeignKey(s => s.SubSectionId) // Foreign Key
         .IsRequired(false)
         .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubmittedAnswer>()
           .HasOne(s => s.Question) // Navigation
           .WithMany(sa => sa.SubmittedAnswers)
           .HasForeignKey(s => s.QuestionId) // Foreign Key
           .IsRequired(false)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubmittedAnswer>()
           .HasOne(s => s.Option) // Navigation
           .WithMany(sa => sa.SubmittedAnswers)
           .HasForeignKey(s => s.OptionId) // Foreign Key
           .IsRequired(false)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubmittedAttachment>()
        .HasKey(s => s.Id); // Primary Key

        modelBuilder.Entity<SubmittedAttachment>()
            .Property(s => s.Id)
            .ValueGeneratedOnAdd();  // Auto-increment

        modelBuilder.Entity<SubmittedAttachment>()
            .HasOne(s => s.Submission) // Navigation
            .WithMany(sa => sa.SubmittedAttachments)
            .HasForeignKey(s => s.SubmissionId) // Foreign Key
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SubmittedAttachment>()
           .HasOne(s => s.SubSection) // Navigation
           .WithMany(sa => sa.SubmittedAttachments)
           .HasForeignKey(s => s.SubSectionId) // Foreign Key
           .IsRequired(false)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubmittedAttachment>()
           .HasOne(s => s.Question) // Navigation
           .WithMany(sa => sa.SubmittedAttachments)
           .HasForeignKey(s => s.QuestionId) // Foreign Key
           .IsRequired(false)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubmittedAttachment>()
           .HasOne(s => s.Option) // Navigation
           .WithMany(sa => sa.SubmittedAttachments)
           .HasForeignKey(s => s.OptionId) // Foreign Key
           .IsRequired(false)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SubmittedAttachment>()
           .HasOne(s => s.AttachmentType) // Navigation
           .WithMany(sa => sa.SubmittedAttachments)
           .HasForeignKey(s => s.AttachmentTypeId) // Foreign Key
           .IsRequired()
           .OnDelete(DeleteBehavior.Restrict);


        // Seed static AttachmentTypes
        modelBuilder.Entity<AttachmentType>().HasData(
            new AttachmentType { Id = 1, Name = "Form Attachment", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new AttachmentType { Id = 2, Name = "Sub Section Attachment", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new AttachmentType { Id = 3, Name = "Question Attachment", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }
        );

        // Seed static Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "فئة الإدارة المتميزة", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Category { Id = 2, Name = "فئة الإبداع", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }
        );      

        // Seed static FormSections
        modelBuilder.Entity<FormSection>().HasData(

            //category = 1
            new FormSection { Id = 1, Name = "تحقيق الرؤية والاستراتيجية", OrderIndex=1, CategoryId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSection { Id = 2, Name = "القيم والثقافة المؤسسية", OrderIndex = 2, CategoryId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSection { Id = 3, Name = "تمكين العاملين", OrderIndex = 3, CategoryId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSection { Id = 4, Name = "الحوكمة وإدارة الأداء", OrderIndex = 4, CategoryId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSection { Id = 5, Name = "التفاعل الإيجابي مع أصحاب المصلحة", OrderIndex = 5, CategoryId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSection { Id = 6, Name = "إضافة قيمة للمستفيدين", OrderIndex = 6, CategoryId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSection { Id = 7, Name = "التحول الرقمي وقيادة التغيير", OrderIndex = 7, CategoryId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //category = 2    
            new FormSection { Id = 8, Name = "المعلومات الأساسية للمشارك", OrderIndex = 1, CategoryId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSection { Id = 9, Name = "تفاصيل الفكرة الإبداعية", OrderIndex = 2, CategoryId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSection { Id = 10, Name = "الأدلة الداعمة", OrderIndex = 3, CategoryId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }

        );

        modelBuilder.Entity<FormSubSection>().HasData(

            //category = 1

            //subsection=1
            new FormSubSection { Id = 1, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "إعداد وبناء المنهجية الداعمة لتنفيذ الإستراتيجية", FormSectionId = 1, OrderIndex = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 2, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "إﻋﺪاد ﺧﻄﺔ ﺗﺸﻐﻴﻠﻴﺔ، ﺗﺘﻨﺎﺳﺐ ﻣﻊ أﻫﺪاف اﻟﻬﻴﺌﺔ اﻻﺳﱰاﺗﻴﺠﻴﺔ", FormSectionId = 1, OrderIndex = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //subsection=2
            new FormSubSection { Id = 3, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "تشجيع وتحفيز العاملين للمبادرة والمشاركة في تعزيز القيم والسلوك الإيجابي المنشود", FormSectionId = 2, OrderIndex = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //subsection=3
            new FormSubSection { Id = 4, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "الاهتمام بموظفي الإدارة لرفع الكفاءة مما يحسن الصورة الذهنية عن الإدارة وخدماتها لدى المستفيدين", FormSectionId = 3, OrderIndex = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //subsection=4
            new FormSubSection { Id = 5, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "وجود خطة لإدارة المخاطر", FormSectionId = 4, OrderIndex = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }, 
            new FormSubSection { Id = 6, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "وضع واعتماد وتطبيق المعايير والإجراءات والضوابط والاشتراطات ونماذج العمل المطلوبة", FormSectionId = 4, OrderIndex = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 7, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "تحديد وفهم متطلبات التشريعات الخارجية ذات الصلة", FormSectionId = 4, OrderIndex = 3, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 8, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "وجود إطار تنظيمي تنسيقي يحكم العلاقة مع الإدارات والجهات ذات العلاقة (أصحاب المصلحة)", FormSectionId = 4, OrderIndex = 4, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //subsection=5
            new FormSubSection { Id = 9, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "تطوير شراكات ومبادرات في ضوء الاحتياجات", FormSectionId = 5, OrderIndex = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //subsection=6
            new FormSubSection { Id = 10, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "تطبيق منهج يضمن مراجعة وتحسين الخدمات والعمليات وإجراءات العمل بصورة مستمرة", FormSectionId = 6, OrderIndex = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 11, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "تحديد المستفيدين وتصنيفهم والتعرف على احتياجاتهم وتوقعاتهم", FormSectionId = 6, OrderIndex = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 12, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "وجود قنوات وأساليب لتفعيل أنظمة التغذية الراجعة بغرض تحديد فرص التحسين", FormSectionId = 6, OrderIndex = 3, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 13, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = " تحديد وتحسين ومراقبة سلسلة القيمة في كافة مراحلها", FormSectionId = 6, OrderIndex = 4, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 14, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = " وضع وتطبيق أساليب وبرامج فعالة للتوعية والتعريف بالخدمات والمنتجات التي تقدمها للمستفيدين الحاليين والمتوقعين مستقبلاً", FormSectionId = 6, OrderIndex = 5, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //subsection=7
            new FormSubSection { Id = 15, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "تحديد وتعميم أهداف ومجالات الإبداع والابتكار", FormSectionId = 7, OrderIndex = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 16, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "تحديد وتوفير القنوات ووسائل التواصل", FormSectionId = 7, OrderIndex = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 17, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "توفير بيئة محفزة للبحث والتجربة وتقديم الأفكار الإبداعية", FormSectionId = 7, OrderIndex = 3, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 18, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "التوعية والتهيئة للتغيير", FormSectionId = 7, OrderIndex = 4, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 19, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = " دعم البحوث والدراسات", FormSectionId = 7, OrderIndex = 5, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 20, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "الاستفادة من التقنيات الحديثة وتطبيق نظم للرقمنة وأتمتة العمليات، وتدريب العاملين على استخدامها", FormSectionId = 7, OrderIndex = 6, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 21, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "تحديد وجمع البيانات اللازمة لدعم خطط التحول وإدارة التغيير", FormSectionId = 7, OrderIndex = 7, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 22, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = " وجود أنظمة وأساليب فاعلة لحفظ وأرشفة واستدعاء المعلومات والبيانات المطلوبة", FormSectionId = 7, OrderIndex = 8, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 23, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "استخدام أنظمة الذكاء الاصطناعي وتحليل البيانات لاستخراج المعارف", FormSectionId = 7, OrderIndex = 9, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 24, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "شواهد اخرى", AttachmentPlaceholder = "اسحب وأفلِت الملفات هنا للتحميل.\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = "تبادل التجارب والمعارف والممارسات والدروس المستفادة", FormSectionId = 7, OrderIndex = 10, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //category = 2

            new FormSubSection { Id = 25, HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, Name = "تفاصيل الفكرة", FormSectionId = 9, OrderIndex = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new FormSubSection { Id = 26, HasComment = true, IsCommentRequired = false, CommentLabel = "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = false, AttachmentLabel = "يسمح بإرفاق 5 ملفات بحد اقصى ", AttachmentPlaceholder = "اسحب و أفلت الملفات هنا للرفع\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", Name = " الأدلة المرفقة", FormSectionId = 10, OrderIndex = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }

        );

        // Seed static QuestionTypes
        modelBuilder.Entity<QuestionType>().HasData(
            new QuestionType { Id = 1, Name = "Single Choice", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionType { Id = 2, Name = "Multiple Choice", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionType { Id = 3, Name = "Dropdown", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionType { Id = 4, Name = "Text Box", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionType { Id = 5, Name = "Text Area", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionType { Id = 6, Name = "Number", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionType { Id = 7, Name = "Date", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }
        );


        // Seed static Statuses
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = 1, Name = "Draft", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Status { Id = 2, Name = "Applied", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Status { Id = 3, Name = "Under Review", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Status { Id = 4, Name = "Reset", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Status { Id = 5, Name = "Accepted", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Status { Id = 6, Name = "Denied", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Status { Id = 7, Name = "Expired Without Modification", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Status { Id = 8, Name = "Reapply", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }
        );
    

        // Seed static Options
        modelBuilder.Entity<Option>().HasData(
           
            //Category 1

            //Question 1 to 51 options
            new Option { Id = 1, Title = "متوفر", HasComment = true, IsCommentRequired = false, CommentLabel= "أضف تعليقات (اختياري)", CommentPlaceholder = "أضف تعليقات", HasAttachment = true, IsAttachmentRequired = true, AttachmentLabel = "ارفاق الدليل",  AttachmentPlaceholder = "يرجى إرفاق الشواهد (مرفقات بجميع الصيغ حتى 30 ميجابايت)", isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 2, Title = "غير متوفر", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            ////Category = 2

            //QuestionId 53
            new Option { Id = 3, Title = "تحسين جودة الخدمات", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 4, Title = "تحسين تجربة المستفيد", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 5, Title = "زيادة الفاعلية التشغيلية", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 6, Title = "معالجة مشاكل أو تحديات تواجة قطاع المياه", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 7, Title = "رفع مستوى المحتوى المحلي", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //QuestionId 54
            new Option { Id = 8, Title = "دعم تطوير السياسات وتطوير وتفعيل اللوائح والإجراءات داخل القطاع", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 9, Title = "مراقبة منظومة المياه وجودة البيانات وضمان الامتثال", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 10, Title = "حماية مصالح المستفيدين في منظومة المياه", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 11, Title = "توفير إدارة متكاملة للمياه وتمكين الامدادات المستدامة لجميع المستهلكين", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 12, Title = "تطوير وتعزيز القدرات لرفع الكفاءة", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 13, Title = "تعزيز الابتكار والرقمنة وتمكين التكنولوجيا داخل منظومة المياه", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 14, Title = "المساهمة في التنمية الاقتصادية وتمكين المحتوى المحلي في قطاع المياه", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //QuestionId 55
            new Option { Id = 15, Title = "تقليل الدورة الزمنية", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 16, Title = "تقليل التكلفة", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 17, Title = "تحسين تجربة المستفيد", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 18, Title = "معالجة مشاكل عمل حالية", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 19, Title = "استثمار الفرص", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 20, Title = "توطين الصناعات والتقنيات", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 21, Title = "زيادة الكفاءة والفعالية التشغيلية", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 22, Title = "تقديم بدائل", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 23, Title = "المساهمة في تحقيق الاستراتيجية", HasComment = false, IsCommentRequired = false, CommentLabel = null, CommentPlaceholder = null, HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Option { Id = 24, Title = "آخرى", HasComment = true, IsCommentRequired = true, CommentLabel = null, CommentPlaceholder = "كتابة النص هنا", HasAttachment = false, IsAttachmentRequired = false, AttachmentLabel = null, AttachmentPlaceholder = null, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }

        );


        // Seed static Questions
        modelBuilder.Entity<Question>().HasData(

            //Category = 1

            //formsection = 1, formSubSection = 1
            new Question { Id = 1, FormSubSectionId = 1, OrderIndex = 1, Title = "المنهجية المستخدمة في تنفيذ الاستراتيجية مع الأدلة على تفعليها", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 2, FormSubSectionId = 1, OrderIndex = 2, Title = "قائمة تحديد الأولويات الاستراتيجية والاحتياجات المطلوبة لمرحلة التنفيذ", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 3, FormSubSectionId = 1, OrderIndex = 3, Title = "قائمة الأهداف المرتبطة مع الاستراتيجية ومؤشرات الأداء الخاصة بالإدارة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 1, formSubSection = 2
            new Question { Id = 4, FormSubSectionId = 2, OrderIndex = 1, Title = "التقارير الدورية لمتابعة تنفيذ الخطة وفقاً لمؤشرات الإدارة التشغيلية", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 5, FormSubSectionId = 2, OrderIndex = 2, Title = "محاضر اجتماعات لمناقشة تقارير الأداء مع الإجراءات التصحيحية المتخذة في عملية القياس", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 2, formSubSection = 3
            new Question { Id = 6, FormSubSectionId = 3, OrderIndex = 1, Title = "أمثلة تعكس وجود بيئة تحفيزية لتعزيز القيم", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 7, FormSubSectionId = 3, OrderIndex = 2, Title = "تقديم وتوضيح أمثلة للمبادرات والبرامج التي تعمل على تعزيز القيم", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 3, formSubSection = 4
            new Question { Id = 8, FormSubSectionId = 4, OrderIndex = 1, Title = "تقارير مشاركة العاملين في برامج التدريب والتطوير المهني", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 9, FormSubSectionId = 4, OrderIndex = 2, Title = "أدلة على تنفيذ برامج لتبادل المعرفة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 4, formSubSection = 5
            new Question { Id = 10, FormSubSectionId = 5, OrderIndex = 1, Title = "سجل المخاطر الخاص بالإدارة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 4, formSubSection = 6
            new Question { Id = 11, FormSubSectionId = 6, OrderIndex = 1, Title = "قائمة الإجراءات والسياسات واللوائح والنماذج والأدلة ذات الصلة بأعمال الإدارة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 12, FormSubSectionId = 6, OrderIndex = 2, Title = "مصفوفة الصلاحيات والمسؤوليات المعتمدة للإدارة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 13, FormSubSectionId = 6, OrderIndex = 3, Title = "نماذج لتنفيذ الأعمال والأنشطة وفقا للإجراءات والمنهجيات المعتمدة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 4, formSubSection = 7
            new Question { Id = 14, FormSubSectionId = 7, OrderIndex = 1, Title = "قائمة المتطلبات القانونية والتشريعية ذات الصلة بالإدارة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 15, FormSubSectionId = 7, OrderIndex = 2, Title = "أدلة على رصد التغييرات وآليات المواءمة معها", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 4, formSubSection = 8
            new Question { Id = 16, FormSubSectionId = 8, OrderIndex = 1, Title = "إطار فهم أصحاب المصلحة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 17, FormSubSectionId = 8, OrderIndex = 2, Title = "أمثلة على تحديث الإطار بشكل دوري", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 5, formSubSection = 9
            new Question { Id = 18, FormSubSectionId = 9, OrderIndex = 1, Title = "الشراكات والمبادرات التي تم تنفيذها، وأثرها الإيجابي على الهيئة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 19, FormSubSectionId = 9, OrderIndex = 2, Title = "خطط التحسين والتطوير للمبادرات", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 20, FormSubSectionId = 9, OrderIndex = 3, Title = "تفعيل الشراكات والاتفاقيات الإستراتيجية وفقاً لبنود الشراكة ذات المنفعة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },



            //formsection = 6, formSubSection = 10
            new Question { Id = 21, FormSubSectionId = 10, OrderIndex = 1, Title = "الخطة السنوية لتحسين الإجراءات والعمليات", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 22, FormSubSectionId = 10, OrderIndex = 2, Title = "قائمة التحسينات التي تم تنفيذها  على الخدمات والإجراءات وأثر ذلك على العمل", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 6, formSubSection = 11
            new Question { Id = 23, FormSubSectionId = 11, OrderIndex = 1, Title = "شواهد للمقترحات والأفكار الإبداعية المقدمة من قبل المعنيين", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 24, FormSubSectionId = 11, OrderIndex = 2, Title = "عينة لاستطلاع آراء المستفيدين وأخذ المقترحات", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 25, FormSubSectionId = 11, OrderIndex = 3, Title = "نماذج للقاءات والفعاليات", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 26, FormSubSectionId = 11, OrderIndex = 4, Title = " قائمة المستفيدين وتصنيفاتهم", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 27, FormSubSectionId = 11, OrderIndex = 5, Title = "قائمة احتياجات وتوقعات المستفيدين", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 6, formSubSection = 12
            new Question { Id = 28, FormSubSectionId = 12, OrderIndex = 1, Title = "أدلة على القيام بأخذ التغذية الراجعة عن طريق مجموعات التركيز، المسوحات واستطلاعات الرأي، العاملين المباشرين في التعامل مع المستفيدين أو أي أساليب أخرى", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 29, FormSubSectionId = 12, OrderIndex = 2, Title = "نماذج للشكاوى وطرق معالجتها", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 6, formSubSection = 13
            new Question { Id = 30, FormSubSectionId = 13, OrderIndex = 1, Title = " دراسة توضح رحلة العميل ونقاط التحسين التي تم حصرها والتحسين الذي تم تنفيذه أو خطط له بناء على هذه الدراسة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 6, formSubSection = 14
            new Question { Id = 31, FormSubSectionId = 14, OrderIndex = 1, Title = "تفعيل الموقع الإلكتروني للتعريف بالإدارة والخدمات التي تقدمها، والمهام والسياسات والوحدات التابعة لها (مع إدراج رابط صفحة الإدارة بالموقع الإلكتروني)", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 32, FormSubSectionId = 14, OrderIndex = 2, Title = " قائمة الخدمات على أن تشمل (اسم الخدمة، تعريف الخدمة، قنوات تقديم الخدمة، الجهة المستفيدة، الفئة المستهدفة، مدة تنفيذ الخدمة)", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 33, FormSubSectionId = 14, OrderIndex = 3, Title = "  فعاليات وأدوات التوعية والتعريف بالخدمات والمنتجات المقدمة للمستفيدين", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 15
            new Question { Id = 34, FormSubSectionId = 15, OrderIndex = 1, Title = "محضر أو تقرير يوضح مخرجات تنفيذ الأساليب والإجراءات لتحديد مجالات الابداع والابتكار", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 35, FormSubSectionId = 15, OrderIndex = 2, Title = "وجود قائمة بمجالات الإبداع والتحسين المستهدفة لتحقيق أهداف الإدارة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 16
            new Question { Id = 36, FormSubSectionId = 16, OrderIndex = 1, Title = "دليل على وجود قنوات ووسائل تمكن من استقبال الأفكار والابتكارات", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 17
            new Question { Id = 37, FormSubSectionId = 17, OrderIndex = 1, Title = "أدلة توضح تطبيق منهجيات وأساليب تحفيز تقديم الأفكار الابداعية", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 38, FormSubSectionId = 17, OrderIndex = 2, Title = "قائمة الأفكار الإبداعية والابتكارات المرصودة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 39, FormSubSectionId = 17, OrderIndex = 3, Title = "نماذج لأفكار وحلول تم تبنيها ورعايتها بواسطة الإدارة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 18
            new Question { Id = 40, FormSubSectionId = 18, OrderIndex = 1, Title = "دليل على توعية وتهيئة العاملين للتغيير والتحول", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 19
            new Question { Id = 41, FormSubSectionId = 19, OrderIndex = 1, Title = "نماذج للبحوث التي تم دعمها", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 42, FormSubSectionId = 19, OrderIndex = 2, Title = "نماذج للبحوث والدراسات المخطط تنفيذها", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 43, FormSubSectionId = 19, OrderIndex = 3, Title = "قائمة البحوث الموجودة بالإدارة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 20
            new Question { Id = 44, FormSubSectionId = 20, OrderIndex = 1, Title = "تقديم أدلة على توظيف وتفعيل الأنظمة والتقنيات الحديثة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 45, FormSubSectionId = 20, OrderIndex = 2, Title = "قائمة الإجراءات المؤتمتة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 46, FormSubSectionId = 20, OrderIndex = 3, Title = "قائمة البرامج والدورات التدريبية المقدمة للعاملين في مجال إدارة وتطوير العمليات واستخدام التقنيات", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 47, FormSubSectionId = 20, OrderIndex = 4, Title = "صور الأنظمة التقنية المستخدمة", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 21
            new Question { Id = 48, FormSubSectionId = 21, OrderIndex = 1, Title = "نماذج توضح قيام الإدارة بجمع وتصنيف البيانات", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 22
            new Question { Id = 49, FormSubSectionId = 22, OrderIndex = 1, Title = "دليل يوضح آلية الأرشفة وحفظ واستدعاء المعلومات", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 23
            new Question { Id = 50, FormSubSectionId = 23, OrderIndex = 1, Title = "نماذج لتقارير تحليل البيانات", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            //formsection = 7, formSubSection = 24
            new Question { Id = 51, FormSubSectionId = 24, OrderIndex = 1, Title = "أدلة على تنفيذ منهجيات لتبادل المعارف والخبرات بين العاملين", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 1, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //Category = 2,

            //formsection = 9, formSubSection=25
            new Question { Id = 52, FormSubSectionId = 25, OrderIndex = 1, Title = "عنوان الفكرة", QuestionPlaceholder = null, AnswerPlaceholder = "عنوان الفكرة", QuestionTypeId = 4, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 53, FormSubSectionId = 25, OrderIndex = 2, Title = "مجالات الفكرة الإبداعية", QuestionPlaceholder = "الرجاء اختيار خيار واحد على الأقل", AnswerPlaceholder = null, QuestionTypeId = 2, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 54, FormSubSectionId = 25, OrderIndex = 3, Title = "ارتباط الفكرة الإبداعية بالأهداف الاستراتيجية للهيئة ", QuestionPlaceholder = "الرجاء اختيار خيار واحد على الأقل", AnswerPlaceholder = null, QuestionTypeId = 2, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 55, FormSubSectionId = 25, OrderIndex = 4, Title = "تتمثل المساهمة الإيجابية للفكرة الإبداعية للمقدم في", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 2, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 56, FormSubSectionId = 25, OrderIndex = 5, Title = "بداية التنفيذ", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 7, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 57, FormSubSectionId = 25, OrderIndex = 6, Title = "نهاية التنفيذ", QuestionPlaceholder = null, AnswerPlaceholder = null, QuestionTypeId = 7, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 58, FormSubSectionId = 25, OrderIndex = 7, Title = "وصف الفكرة الإبداعية", QuestionPlaceholder = null, AnswerPlaceholder = "الرجاء الكتابة هنا فقط 500 كلمة.", QuestionTypeId = 5, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 59, FormSubSectionId = 25, OrderIndex = 8, Title = "الفئة المستهدفة", QuestionPlaceholder = null, AnswerPlaceholder = "الفئة المستهدفة", QuestionTypeId = 4, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 60, FormSubSectionId = 25, OrderIndex = 9, Title = "شركاء النجاح", QuestionPlaceholder = null, AnswerPlaceholder = "شركاء النجاح", QuestionTypeId = 4, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 61, FormSubSectionId = 25, OrderIndex = 10, Title = "مراحل التنفيذ", QuestionPlaceholder = null, AnswerPlaceholder = "لا يتجاوز 10 مراحل", QuestionTypeId = 5, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 62, FormSubSectionId = 25, OrderIndex = 11, Title = "المخرجات", QuestionPlaceholder = null, AnswerPlaceholder = "لا يتجاوز 10 مخرجات", QuestionTypeId = 5, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 63, FormSubSectionId = 25, OrderIndex = 12, Title = "التحديات", QuestionPlaceholder = null, AnswerPlaceholder = "الرجاء الكتابة هنا فقط 500 كلمة.", QuestionTypeId = 5, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new Question { Id = 64, FormSubSectionId = 25, OrderIndex = 13, Title = "الأثر والمنافع", QuestionPlaceholder = null, AnswerPlaceholder = "الرجاء الكتابة هنا فقط 500 كلمة.", QuestionTypeId = 5, IsRequired = true, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }


        );

        // Seed static QuestionOptions
        modelBuilder.Entity<QuestionOption>().HasData(

            //Category = 1

            //formsection = 1, formSubSection = 1
            new QuestionOption { Id = 1, QuestionId = 1, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 2, QuestionId = 1, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 3, QuestionId = 2, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 4, QuestionId = 2, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 5, QuestionId = 3, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 6, QuestionId = 3, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 1, formSubSection = 2
            new QuestionOption { Id = 7, QuestionId = 4, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 8, QuestionId = 4, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 9, QuestionId = 5, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 10, QuestionId = 5, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 2, formSubSection = 3
            new QuestionOption { Id = 11, QuestionId = 6, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 12, QuestionId = 6, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 13, QuestionId = 7, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 14, QuestionId = 7, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 3, formSubSection = 4
            new QuestionOption { Id = 15, QuestionId = 8, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 16, QuestionId = 8, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 17, QuestionId = 9, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 18, QuestionId = 9, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 4, formSubSection = 5
            new QuestionOption { Id = 19, QuestionId = 10, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 20, QuestionId = 10, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 4, formSubSection = 6
            new QuestionOption { Id = 21, QuestionId = 11, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 22, QuestionId = 11, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 23, QuestionId = 12, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 24, QuestionId = 12, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            
            new QuestionOption { Id = 25, QuestionId = 13, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 26, QuestionId = 13, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 4, formSubSection = 7
            new QuestionOption { Id = 27, QuestionId = 14, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 28, QuestionId = 14, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 29, QuestionId = 15, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 30, QuestionId = 15, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 4, formSubSection = 8
            new QuestionOption { Id = 31, QuestionId = 16, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 32, QuestionId = 16, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 33, QuestionId = 17, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 34, QuestionId = 17, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 5, formSubSection = 9
            new QuestionOption { Id = 35, QuestionId = 18, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 36, QuestionId = 18, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 37, QuestionId = 19, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 38, QuestionId = 19, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            
            new QuestionOption { Id = 39, QuestionId = 20, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 40, QuestionId = 20, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 6, formSubSection = 10
            new QuestionOption { Id = 41, QuestionId = 21, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 42, QuestionId = 21, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 43, QuestionId = 22, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 44, QuestionId = 22, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 6, formSubSection = 11
            new QuestionOption { Id = 45, QuestionId = 23, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 46, QuestionId = 23, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 47, QuestionId = 24, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 48, QuestionId = 24, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 49, QuestionId = 25, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 50, QuestionId = 25, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 51, QuestionId = 26, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 52, QuestionId = 26, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 53, QuestionId = 27, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 54, QuestionId = 27, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 6, formSubSection = 12
            new QuestionOption { Id = 55, QuestionId = 28, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 56, QuestionId = 28, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 57, QuestionId = 29, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 58, QuestionId = 29, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 6, formSubSection = 13
            new QuestionOption { Id = 59, QuestionId = 30, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 60, QuestionId = 30, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 6, formSubSection = 14
            new QuestionOption { Id = 61, QuestionId = 31, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 62, QuestionId = 31, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 63, QuestionId = 32, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 64, QuestionId = 32, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 65, QuestionId = 33, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 66, QuestionId = 33, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 15
            new QuestionOption { Id = 67, QuestionId = 34, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 68, QuestionId = 34, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 69, QuestionId = 35, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 70, QuestionId = 35, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 16
            new QuestionOption { Id = 71, QuestionId = 36, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 72, QuestionId = 36, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 17
            new QuestionOption { Id = 73, QuestionId = 37, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 74, QuestionId = 37, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 75, QuestionId = 38, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 76, QuestionId = 38, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 77, QuestionId = 39, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 78, QuestionId = 39, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 18
            new QuestionOption { Id = 79, QuestionId = 40, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 80, QuestionId = 40, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 19
            new QuestionOption { Id = 81, QuestionId = 41, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 82, QuestionId = 41, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 83, QuestionId = 42, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 84, QuestionId = 42, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 85, QuestionId = 43, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 86, QuestionId = 43, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 20            
            new QuestionOption { Id = 87, QuestionId = 44, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 88, QuestionId = 44, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 89, QuestionId = 45, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 90, QuestionId = 45, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 91, QuestionId = 46, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 92, QuestionId = 46, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 93, QuestionId = 47, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 94, QuestionId = 47, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 21
            new QuestionOption { Id = 95, QuestionId = 48, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 96, QuestionId = 48, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 22
            new QuestionOption { Id = 97, QuestionId = 49, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 98, QuestionId = 49, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 23
            new QuestionOption { Id = 99, QuestionId = 50, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 100, QuestionId = 50, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //formsection = 7, formSubSection = 24            
            new QuestionOption { Id = 101, QuestionId = 51, OptionId = 1, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 102, QuestionId = 51, OptionId = 2, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            //Category = 2,

            //formsection = 9, formSubSection = 25
            new QuestionOption { Id = 103, QuestionId = 53, OptionId = 3, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 104, QuestionId = 53, OptionId = 4, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 105, QuestionId = 53, OptionId = 5, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 106, QuestionId = 53, OptionId = 6, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 107, QuestionId = 53, OptionId = 7, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },


            new QuestionOption { Id = 108, QuestionId = 54, OptionId = 8, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 109, QuestionId = 54, OptionId = 9, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 110, QuestionId = 54, OptionId = 10, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 111, QuestionId = 54, OptionId = 11, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 112, QuestionId = 54, OptionId = 12, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 113, QuestionId = 54, OptionId = 13, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 114, QuestionId = 54, OptionId = 14, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },

            new QuestionOption { Id = 115, QuestionId = 55, OptionId = 15, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 116, QuestionId = 55, OptionId = 16, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 117, QuestionId = 55, OptionId = 17, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 118, QuestionId = 55, OptionId = 18, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 119, QuestionId = 55, OptionId = 19, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 120, QuestionId = 55, OptionId = 20, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 121, QuestionId = 55, OptionId = 21, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 122, QuestionId = 55, OptionId = 22, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 123, QuestionId = 55, OptionId = 23, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" },
            new QuestionOption { Id = 124, QuestionId = 55, OptionId = 24, isActive = true, isDeleted = false, CreatedAt = new DateTime(2025, 06, 25, 14, 01, 00), CreatedBy = "System", LastModifiedAt = new DateTime(2025, 06, 25, 14, 01, 00), LastModifiedBy = "System" }


        );

       
    }

}

