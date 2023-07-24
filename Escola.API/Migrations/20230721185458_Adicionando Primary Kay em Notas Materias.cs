using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.API.Migrations
{
    public partial class AdicionandoPrimaryKayemNotasMaterias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotasMaterias_BOLETIM_BoletimId",
                table: "NotasMaterias");

            migrationBuilder.DropForeignKey(
                name: "FK_NotasMaterias_MATÉRIA_MateriaId",
                table: "NotasMaterias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotasMaterias",
                table: "NotasMaterias");

            migrationBuilder.RenameTable(
                name: "NotasMaterias",
                newName: "NOTAS_MATERIAS");

            migrationBuilder.RenameIndex(
                name: "IX_NotasMaterias_MateriaId",
                table: "NOTAS_MATERIAS",
                newName: "IX_NOTAS_MATERIAS_MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_NotasMaterias_BoletimId",
                table: "NOTAS_MATERIAS",
                newName: "IX_NOTAS_MATERIAS_BoletimId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NOTAS_MATERIAS",
                table: "NOTAS_MATERIAS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NOTAS_MATERIAS_BOLETIM_BoletimId",
                table: "NOTAS_MATERIAS",
                column: "BoletimId",
                principalTable: "BOLETIM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NOTAS_MATERIAS_MATÉRIA_MateriaId",
                table: "NOTAS_MATERIAS",
                column: "MateriaId",
                principalTable: "MATÉRIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NOTAS_MATERIAS_BOLETIM_BoletimId",
                table: "NOTAS_MATERIAS");

            migrationBuilder.DropForeignKey(
                name: "FK_NOTAS_MATERIAS_MATÉRIA_MateriaId",
                table: "NOTAS_MATERIAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NOTAS_MATERIAS",
                table: "NOTAS_MATERIAS");

            migrationBuilder.RenameTable(
                name: "NOTAS_MATERIAS",
                newName: "NotasMaterias");

            migrationBuilder.RenameIndex(
                name: "IX_NOTAS_MATERIAS_MateriaId",
                table: "NotasMaterias",
                newName: "IX_NotasMaterias_MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_NOTAS_MATERIAS_BoletimId",
                table: "NotasMaterias",
                newName: "IX_NotasMaterias_BoletimId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotasMaterias",
                table: "NotasMaterias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotasMaterias_BOLETIM_BoletimId",
                table: "NotasMaterias",
                column: "BoletimId",
                principalTable: "BOLETIM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotasMaterias_MATÉRIA_MateriaId",
                table: "NotasMaterias",
                column: "MateriaId",
                principalTable: "MATÉRIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
