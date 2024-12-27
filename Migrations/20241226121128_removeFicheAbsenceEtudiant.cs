using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class removeFicheAbsenceEtudiant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FicheAbsenceEtudiant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FicheAbsenceEtudiant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEtudiant = table.Column<int>(type: "int", nullable: false),
                    IdFicheAbsence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheAbsenceEtudiant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FicheAbsenceEtudiant_Etudiant_IdEtudiant",
                        column: x => x.IdEtudiant,
                        principalTable: "Etudiant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FicheAbsenceEtudiant_FicheAbsence_IdFicheAbsence",
                        column: x => x.IdFicheAbsence,
                        principalTable: "FicheAbsence",
                        principalColumn: "IdFicheAbsence",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsenceEtudiant_IdEtudiant",
                table: "FicheAbsenceEtudiant",
                column: "IdEtudiant");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsenceEtudiant_IdFicheAbsence",
                table: "FicheAbsenceEtudiant",
                column: "IdFicheAbsence");
        }
    }
}
