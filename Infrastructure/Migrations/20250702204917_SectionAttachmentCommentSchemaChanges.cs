using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SectionAttachmentCommentSchemaChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "SubmittedAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubSectionId",
                table: "SubmittedAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAnswers_SubSectionId",
                table: "SubmittedAnswers",
                column: "SubSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedAnswers_FormSubSections_SubSectionId",
                table: "SubmittedAnswers",
                column: "SubSectionId",
                principalTable: "FormSubSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedAnswers_FormSubSections_SubSectionId",
                table: "SubmittedAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedAnswers_SubSectionId",
                table: "SubmittedAnswers");

            migrationBuilder.DropColumn(
                name: "SubSectionId",
                table: "SubmittedAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "SubmittedAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
