using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho03.Migrations
{
    /// <inheritdoc />
    public partial class RefatorarTodasAsTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materia_Aluno_Id",
                table: "Materia");

            migrationBuilder.AddColumn<Guid>(
                name: "AlunoId",
                table: "Materia",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Aluno_Id",
                        column: x => x.Id,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Materia_Id",
                table: "Aluno",
                column: "Id",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Materia_Id",
                table: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Materia");

            migrationBuilder.AddForeignKey(
                name: "FK_Materia_Aluno_Id",
                table: "Materia",
                column: "Id",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
