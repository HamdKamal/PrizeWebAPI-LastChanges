using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuestionAttachmentPlaceholder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "AttachmentPlaceholder",
                value: "يرجى إرفاق الشواهد (مرفقات بجميع الصيغ حتى 30 ميجابايت)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                column: "AttachmentPlaceholder",
                value: " يرجى إرفاق الشهادات (مرفقة بجميع التنسيقات حتى 30 ميجابايت)");
        }
    }
}
