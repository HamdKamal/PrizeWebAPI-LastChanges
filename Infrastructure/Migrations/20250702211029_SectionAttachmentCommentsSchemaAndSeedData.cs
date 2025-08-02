using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SectionAttachmentCommentsSchemaAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentLabel",
                table: "FormSubSections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentPlaceholder",
                table: "FormSubSections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasComment",
                table: "FormSubSections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCommentRequired",
                table: "FormSubSections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { null, null, false, false });

            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CommentLabel", "CommentPlaceholder", "HasComment", "IsCommentRequired" },
                values: new object[] { "أضف تعليقات (اختياري)", "أضف تعليقات", true, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentLabel",
                table: "FormSubSections");

            migrationBuilder.DropColumn(
                name: "CommentPlaceholder",
                table: "FormSubSections");

            migrationBuilder.DropColumn(
                name: "HasComment",
                table: "FormSubSections");

            migrationBuilder.DropColumn(
                name: "IsCommentRequired",
                table: "FormSubSections");
        }
    }
}
