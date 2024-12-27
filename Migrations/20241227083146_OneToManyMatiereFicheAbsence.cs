using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyMatiereFicheAbsence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FicheAbsence_CodeMatiere",
                table: "FicheAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsence_CodeMatiere",
                table: "FicheAbsence",
                column: "CodeMatiere");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FicheAbsence_CodeMatiere",
                table: "FicheAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsence_CodeMatiere",
                table: "FicheAbsence",
                column: "CodeMatiere",
                unique: true);
        }
    }
}
