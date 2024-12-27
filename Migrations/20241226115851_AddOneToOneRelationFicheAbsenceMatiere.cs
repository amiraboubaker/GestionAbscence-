using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToOneRelationFicheAbsenceMatiere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodeMatiere",
                table: "FicheAbsence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsence_CodeMatiere",
                table: "FicheAbsence",
                column: "CodeMatiere",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FicheAbsence_Matiere_CodeMatiere",
                table: "FicheAbsence",
                column: "CodeMatiere",
                principalTable: "Matiere",
                principalColumn: "CodeMatiere",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheAbsence_Matiere_CodeMatiere",
                table: "FicheAbsence");

            migrationBuilder.DropIndex(
                name: "IX_FicheAbsence_CodeMatiere",
                table: "FicheAbsence");

            migrationBuilder.DropColumn(
                name: "CodeMatiere",
                table: "FicheAbsence");
        }
    }
}
