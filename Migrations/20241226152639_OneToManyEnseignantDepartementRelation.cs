using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyEnseignantDepartementRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Enseignant_CodeDepartement",
                table: "Enseignant",
                column: "CodeDepartement");

            migrationBuilder.AddForeignKey(
                name: "FK_Enseignant_Departement_CodeDepartement",
                table: "Enseignant",
                column: "CodeDepartement",
                principalTable: "Departement",
                principalColumn: "CodeDepartement",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enseignant_Departement_CodeDepartement",
                table: "Enseignant");

            migrationBuilder.DropIndex(
                name: "IX_Enseignant_CodeDepartement",
                table: "Enseignant");
        }
    }
}
