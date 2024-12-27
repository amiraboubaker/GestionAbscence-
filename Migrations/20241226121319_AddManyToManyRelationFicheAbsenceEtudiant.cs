using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationFicheAbsenceEtudiant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodeSeance",
                table: "LigneFicheAbsence",
                newName: "IdFicheAbsence");

            migrationBuilder.RenameColumn(
                name: "CodeFicheAbsence",
                table: "LigneFicheAbsence",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "IdEtudiant",
                table: "LigneFicheAbsence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LigneFicheAbsence_IdEtudiant",
                table: "LigneFicheAbsence",
                column: "IdEtudiant");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFicheAbsence_IdFicheAbsence",
                table: "LigneFicheAbsence",
                column: "IdFicheAbsence");

            migrationBuilder.AddForeignKey(
                name: "FK_LigneFicheAbsence_Etudiant_IdEtudiant",
                table: "LigneFicheAbsence",
                column: "IdEtudiant",
                principalTable: "Etudiant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneFicheAbsence_FicheAbsence_IdFicheAbsence",
                table: "LigneFicheAbsence",
                column: "IdFicheAbsence",
                principalTable: "FicheAbsence",
                principalColumn: "IdFicheAbsence",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LigneFicheAbsence_Etudiant_IdEtudiant",
                table: "LigneFicheAbsence");

            migrationBuilder.DropForeignKey(
                name: "FK_LigneFicheAbsence_FicheAbsence_IdFicheAbsence",
                table: "LigneFicheAbsence");

            migrationBuilder.DropIndex(
                name: "IX_LigneFicheAbsence_IdEtudiant",
                table: "LigneFicheAbsence");

            migrationBuilder.DropIndex(
                name: "IX_LigneFicheAbsence_IdFicheAbsence",
                table: "LigneFicheAbsence");

            migrationBuilder.DropColumn(
                name: "IdEtudiant",
                table: "LigneFicheAbsence");

            migrationBuilder.RenameColumn(
                name: "IdFicheAbsence",
                table: "LigneFicheAbsence",
                newName: "CodeSeance");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LigneFicheAbsence",
                newName: "CodeFicheAbsence");
        }
    }
}
