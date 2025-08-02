using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreativityCategoryFormSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FormSections",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name", "OrderIndex", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 8, 2, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "المعلومات الأساسية للمشارك", 1, true, false },
                    { 9, 2, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تفاصيل الفكرة الإبداعية", 2, true, false },
                    { 10, 2, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "الأدلة الداعمة", 3, true, false }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "AttachmentLabel", "AttachmentPlaceholder", "CommentLabel", "CommentPlaceholder", "CreatedAt", "CreatedBy", "HasAttachment", "HasComment", "IsAttachmentRequired", "IsCommentRequired", "LastModifiedAt", "LastModifiedBy", "Title", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 3, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تحسين جودة الخدمات", true, false },
                    { 4, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تحسين تجربة المستفيد", true, false },
                    { 5, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "زيادة الفاعلية التشغيلية", true, false },
                    { 6, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "معالجة مشاكل أو تحديات تواجة قطاع المياه", true, false },
                    { 7, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "رفع مستوى المحتوى المحلي", true, false },
                    { 8, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "دعم تطوير السياسات وتطوير وتفعيل اللوائح والإجراءات داخل القطاع", true, false },
                    { 9, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "مراقبة منظومة المياه وجودة البيانات وضمان الامتثال", true, false },
                    { 10, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "حماية مصالح المستفيدين في منظومة المياه", true, false },
                    { 11, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "توفير إدارة متكاملة للمياه وتمكين الامدادات المستدامة لجميع المستهلكين", true, false },
                    { 12, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تطوير وتعزيز القدرات لرفع الكفاءة", true, false },
                    { 13, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تعزيز الابتكار والرقمنة وتمكين التكنولوجيا داخل منظومة المياه", true, false },
                    { 14, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "المساهمة في التنمية الاقتصادية وتمكين المحتوى المحلي في قطاع المياه", true, false },
                    { 15, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تقليل الدورة الزمنية", true, false },
                    { 16, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تقليل التكلفة", true, false },
                    { 17, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تحسين تجربة المستفيد", true, false },
                    { 18, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "معالجة مشاكل عمل حالية", true, false },
                    { 19, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "استثمار الفرص", true, false },
                    { 20, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "توطين الصناعات والتقنيات", true, false },
                    { 21, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "زيادة الكفاءة والفعالية التشغيلية", true, false },
                    { 22, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تقديم بدائل", true, false },
                    { 23, null, null, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, false, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "المساهمة في تحقيق الاستراتيجية", true, false },
                    { 24, null, null, null, "كتابة النص هنا", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", false, true, false, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "آخرى", true, false }
                });

            migrationBuilder.InsertData(
                table: "FormSubSections",
                columns: new[] { "Id", "AttachmentLabel", "AttachmentPlaceholder", "CreatedAt", "CreatedBy", "FormSectionId", "HasAttachment", "IsAttachmentRequired", "LastModifiedAt", "LastModifiedBy", "Name", "OrderIndex", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 25, null, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 9, false, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", "تفاصيل الفكرة", 1, true, false },
                    { 26, "يسمح بإرفاق 5 ملفات بحد اقصى ", "اسحب و أفلت الملفات هنا للرفع\r\n\r\nالحد الأقصى لحجم الملف المسموح به هو 2 ميجابايت، وتشمل الصيغ المدعومة .jpg و .png و .pdf.\r\n\r\nتصفح الملفات\r\n", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 10, true, false, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", " الأدلة المرفقة", 2, true, false }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnswerPlaceholder", "CreatedAt", "CreatedBy", "FormSubSectionId", "IsRequired", "LastModifiedAt", "LastModifiedBy", "OrderIndex", "QuestionPlaceholder", "QuestionTypeId", "Title", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 52, "عنوان الفكرة", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 1, null, 4, "عنوان الفكرة", true, false },
                    { 53, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 2, "الرجاء اختيار خيار واحد على الأقل", 2, "مجالات الفكرة الإبداعية", true, false },
                    { 54, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, "الرجاء اختيار خيار واحد على الأقل", 2, "ارتباط الفكرة الإبداعية بالأهداف الاستراتيجية للهيئة ", true, false },
                    { 55, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, null, 2, "تتمثل المساهمة الإيجابية للفكرة الإبداعية للمقدم في", true, false },
                    { 56, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 5, null, 7, "بداية التنفيذ", true, false },
                    { 57, null, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, null, 7, "نهاية التنفيذ", true, false },
                    { 58, "الرجاء الكتابة هنا فقط 500 كلمة.", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, null, 5, "وصف الفكرة الإبداعية", true, false },
                    { 59, "الفئة المستهدفة", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 8, null, 4, "الفئة المستهدفة", true, false },
                    { 60, "شركاء النجاح", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 9, null, 4, "شركاء النجاح", true, false },
                    { 61, "لا يتجاوز 10 مراحل", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 10, null, 5, "مراحل التنفيذ", true, false },
                    { 62, "لا يتجاوز 10 مخرجات", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 11, null, 5, "المخرجات", true, false },
                    { 63, "الرجاء الكتابة هنا فقط 500 كلمة.", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 12, null, 5, "التحديات", true, false },
                    { 64, "الرجاء الكتابة هنا فقط 500 كلمة.", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 25, true, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 13, null, 5, "الأثر والمنافع", true, false }
                });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "OptionId", "QuestionId", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { 103, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 3, 53, true, false },
                    { 104, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 4, 53, true, false },
                    { 105, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 5, 53, true, false },
                    { 106, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 6, 53, true, false },
                    { 107, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 7, 53, true, false },
                    { 108, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 8, 54, true, false },
                    { 109, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 9, 54, true, false },
                    { 110, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 10, 54, true, false },
                    { 111, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 11, 54, true, false },
                    { 112, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 12, 54, true, false },
                    { 113, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 13, 54, true, false },
                    { 114, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 14, 54, true, false },
                    { 115, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 15, 55, true, false },
                    { 116, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 16, 55, true, false },
                    { 117, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 17, 55, true, false },
                    { 118, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 18, 55, true, false },
                    { 119, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 19, 55, true, false },
                    { 120, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 20, 55, true, false },
                    { 121, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 21, 55, true, false },
                    { 122, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 22, 55, true, false },
                    { 123, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 23, 55, true, false },
                    { 124, new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2025, 6, 25, 14, 1, 0, 0, DateTimeKind.Unspecified), "System", 24, 55, true, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FormSections",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "FormSections",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FormSections",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
