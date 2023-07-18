using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.API.Migrations
{
    public partial class AtualizandoBancodeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoTB",
                columns: table => new
                {
                    PK_ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    SOBRENOME = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    GENERO = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    TELEFONE = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    EMAIL = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_aluno_id", x => x.PK_ID);
                });

            migrationBuilder.CreateTable(
                name: "MATÉRIA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Materia = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATÉRIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TURMA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURSO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValue: "Curso Basico"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TURMA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BOLETIM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aluno_Id = table.Column<int>(type: "int", nullable: false),
                    Data_Consulta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOLETIM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOLETIM_AlunoTB_Aluno_Id",
                        column: x => x.Aluno_Id,
                        principalTable: "AlunoTB",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALUNO_X_TURMA",
                columns: table => new
                {
                    Aluno_Id = table.Column<int>(type: "int", nullable: false),
                    Turma_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO_X_TURMA", x => new { x.Aluno_Id, x.Turma_Id });
                    table.ForeignKey(
                        name: "FK_ALUNO_X_TURMA_AlunoTB_Aluno_Id",
                        column: x => x.Aluno_Id,
                        principalTable: "AlunoTB",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ALUNO_X_TURMA_TURMA_Turma_Id",
                        column: x => x.Turma_Id,
                        principalTable: "TURMA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasMaterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoletimId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasMaterias_BOLETIM_BoletimId",
                        column: x => x.BoletimId,
                        principalTable: "BOLETIM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotasMaterias_MATÉRIA_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "MATÉRIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_X_TURMA_Turma_Id",
                table: "ALUNO_X_TURMA",
                column: "Turma_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTB_EMAIL",
                table: "AlunoTB",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOLETIM_Aluno_Id",
                table: "BOLETIM",
                column: "Aluno_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NotasMaterias_BoletimId",
                table: "NotasMaterias",
                column: "BoletimId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasMaterias_MateriaId",
                table: "NotasMaterias",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TURMA_Nome",
                table: "TURMA",
                column: "Nome",
                unique: true,
                filter: "[Nome] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALUNO_X_TURMA");

            migrationBuilder.DropTable(
                name: "NotasMaterias");

            migrationBuilder.DropTable(
                name: "TURMA");

            migrationBuilder.DropTable(
                name: "BOLETIM");

            migrationBuilder.DropTable(
                name: "MATÉRIA");

            migrationBuilder.DropTable(
                name: "AlunoTB");
        }
    }
}
