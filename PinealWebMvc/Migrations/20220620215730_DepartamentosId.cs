using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PinealWebMvc.Migrations
{
    public partial class DepartamentosId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_TipoProjeto_TipoProjetoId",
                table: "Projeto");

            migrationBuilder.DropTable(
                name: "TipoProjeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_TipoProjetoId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "TipoProjetoId",
                table: "Projeto");

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Projeto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_TipoId",
                table: "Projeto",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_Tipo_TipoId",
                table: "Projeto",
                column: "TipoId",
                principalTable: "Tipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_Tipo_TipoId",
                table: "Projeto");

            migrationBuilder.DropTable(
                name: "Tipo");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_TipoId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Projeto");

            migrationBuilder.AddColumn<int>(
                name: "TipoProjetoId",
                table: "Projeto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoProjeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProjeto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_TipoProjetoId",
                table: "Projeto",
                column: "TipoProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_TipoProjeto_TipoProjetoId",
                table: "Projeto",
                column: "TipoProjetoId",
                principalTable: "TipoProjeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
