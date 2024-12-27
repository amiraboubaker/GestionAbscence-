using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyClasseFicheAbsence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FicheAbsence_CodeClasse",
                table: "FicheAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsence_CodeClasse",
                table: "FicheAbsence",
                column: "CodeClasse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FicheAbsence_CodeClasse",
                table: "FicheAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsence_CodeClasse",
                table: "FicheAbsence",
                column: "CodeClasse",
                unique: true);
        }
    }
}
