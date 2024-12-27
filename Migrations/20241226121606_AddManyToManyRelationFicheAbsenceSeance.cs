using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationFicheAbsenceSeance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodeFicheAbsence",
                table: "FicheAbsenceSeance",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "IdFicheAbsence",
                table: "FicheAbsenceSeance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsenceSeance_CodeSeance",
                table: "FicheAbsenceSeance",
                column: "CodeSeance");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsenceSeance_IdFicheAbsence",
                table: "FicheAbsenceSeance",
                column: "IdFicheAbsence");

            migrationBuilder.AddForeignKey(
                name: "FK_FicheAbsenceSeance_FicheAbsence_IdFicheAbsence",
                table: "FicheAbsenceSeance",
                column: "IdFicheAbsence",
                principalTable: "FicheAbsence",
                principalColumn: "IdFicheAbsence",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FicheAbsenceSeance_Seance_CodeSeance",
                table: "FicheAbsenceSeance",
                column: "CodeSeance",
                principalTable: "Seance",
                principalColumn: "CodeSeance",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheAbsenceSeance_FicheAbsence_IdFicheAbsence",
                table: "FicheAbsenceSeance");

            migrationBuilder.DropForeignKey(
                name: "FK_FicheAbsenceSeance_Seance_CodeSeance",
                table: "FicheAbsenceSeance");

            migrationBuilder.DropIndex(
                name: "IX_FicheAbsenceSeance_CodeSeance",
                table: "FicheAbsenceSeance");

            migrationBuilder.DropIndex(
                name: "IX_FicheAbsenceSeance_IdFicheAbsence",
                table: "FicheAbsenceSeance");

            migrationBuilder.DropColumn(
                name: "IdFicheAbsence",
                table: "FicheAbsenceSeance");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FicheAbsenceSeance",
                newName: "CodeFicheAbsence");
        }
    }
}
