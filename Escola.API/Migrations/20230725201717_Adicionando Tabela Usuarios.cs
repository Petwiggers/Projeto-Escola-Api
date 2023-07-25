using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.API.Migrations
{
    public partial class AdicionandoTabelaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUÁRIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_COMPLETO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TipoAcesso = table.Column<int>(type: "int", nullable: false),
                    NOME_USUARIO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUÁRIOS", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUÁRIOS");
        }
    }
}
