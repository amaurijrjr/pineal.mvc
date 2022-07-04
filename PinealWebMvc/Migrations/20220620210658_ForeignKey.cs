using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PinealWebMvc.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_TipoProjeto_TipoId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Vertente_VertenteId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_TipoId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Projeto");

            migrationBuilder.AlterColumn<int>(
                name: "VertenteId",
                table: "Projeto",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoProjetoId",
                table: "Projeto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Img = table.Column<string>(nullable: true),
                    ProjetoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagem_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_TipoProjetoId",
                table: "Projeto",
                column: "TipoProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_ProjetoId",
                table: "Imagem",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_TipoProjeto_TipoProjetoId",
                table: "Projeto",
                column: "TipoProjetoId",
                principalTable: "TipoProjeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Vertente_VertenteId",
                table: "Projeto",
                column: "VertenteId",
                principalTable: "Vertente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_TipoProjeto_TipoProjetoId",
                table: "Projeto");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Vertente_VertenteId",
                table: "Projeto");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_TipoProjetoId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "TipoProjetoId",
                table: "Projeto");

            migrationBuilder.AlterColumn<int>(
                name: "VertenteId",
                table: "Projeto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Projeto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_TipoId",
                table: "Projeto",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_TipoProjeto_TipoId",
                table: "Projeto",
                column: "TipoId",
                principalTable: "TipoProjeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Vertente_VertenteId",
                table: "Projeto",
                column: "VertenteId",
                principalTable: "Vertente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
