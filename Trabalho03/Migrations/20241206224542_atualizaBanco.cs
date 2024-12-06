using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho03.Migrations
{
    /// <inheritdoc />
    public partial class atualizaBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Materia_Id",
                table: "Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Materia_AlunoId",
                table: "Materia",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materia_Aluno_AlunoId",
                table: "Materia",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materia_Aluno_AlunoId",
                table: "Materia");

            migrationBuilder.DropIndex(
                name: "IX_Materia_AlunoId",
                table: "Materia");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Materia_Id",
                table: "Aluno",
                column: "Id",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
