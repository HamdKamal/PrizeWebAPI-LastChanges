using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFormSubSectionNameSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "إعداد وبناء المنهجية الداعمة لتنفيذ الإستراتيجية");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FormSubSections",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "إعداد وبناء الأنظمة الداعمة لتنفيذ الاستراتيجية");
        }
    }
}
