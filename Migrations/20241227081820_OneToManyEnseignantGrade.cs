using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyEnseignantGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Enseignant_CodeGrade",
                table: "Enseignant",
                column: "CodeGrade");

            migrationBuilder.AddForeignKey(
                name: "FK_Enseignant_Grade_CodeGrade",
                table: "Enseignant",
                column: "CodeGrade",
                principalTable: "Grade",
                principalColumn: "CodeGrade",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enseignant_Grade_CodeGrade",
                table: "Enseignant");

            migrationBuilder.DropIndex(
                name: "IX_Enseignant_CodeGrade",
                table: "Enseignant");
        }
    }
}
