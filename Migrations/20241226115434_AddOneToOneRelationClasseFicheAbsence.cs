using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscence.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToOneRelationClasseFicheAbsence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeEnseignant",
                table: "FicheAbsence");

            migrationBuilder.DropColumn(
                name: "CodeMatiere",
                table: "FicheAbsence");

            migrationBuilder.DropColumn(
                name: "DateJour",
                table: "FicheAbsence");

            migrationBuilder.RenameColumn(
                name: "CodeFicheAbsence",
                table: "FicheAbsence",
                newName: "IdFicheAbsence");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FicheAbsence",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAbsence_CodeClasse",
                table: "FicheAbsence",
                column: "CodeClasse",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FicheAbsence_Classe_CodeClasse",
                table: "FicheAbsence",
                column: "CodeClasse",
                principalTable: "Classe",
                principalColumn: "CodeClasse",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheAbsence_Classe_CodeClasse",
                table: "FicheAbsence");

            migrationBuilder.DropIndex(
                name: "IX_FicheAbsence_CodeClasse",
                table: "FicheAbsence");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FicheAbsence");

            migrationBuilder.RenameColumn(
                name: "IdFicheAbsence",
                table: "FicheAbsence",
                newName: "CodeFicheAbsence");

            migrationBuilder.AddColumn<int>(
                name: "CodeEnseignant",
                table: "FicheAbsence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodeMatiere",
                table: "FicheAbsence",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJour",
                table: "FicheAbsence",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
