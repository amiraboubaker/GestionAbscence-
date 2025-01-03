using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class updateEtudiant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FicheAbsence",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "FicheAbsence");
        }
    }
}
