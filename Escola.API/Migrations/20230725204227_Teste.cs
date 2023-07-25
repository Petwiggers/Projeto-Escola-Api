using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.API.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_USUÁRIOS",
                table: "USUÁRIOS");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "USUÁRIOS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUÁRIOS",
                table: "USUÁRIOS",
                column: "NOME_USUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_USUÁRIOS",
                table: "USUÁRIOS");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "USUÁRIOS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUÁRIOS",
                table: "USUÁRIOS",
                column: "Id");
        }
    }
}
