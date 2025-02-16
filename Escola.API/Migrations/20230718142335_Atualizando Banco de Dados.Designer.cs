﻿// <auto-generated />
using System;
using Escola.API.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Escola.API.Migrations
{
    [DbContext(typeof(EscolaDbContexto))]
    [Migration("20230718142335_Atualizando Banco de Dados")]
    partial class AtualizandoBancodeDados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Escola.API.Model.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("PK_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_NASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Genero")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("GENERO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("NOME");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("SOBRENOME");

                    b.Property<string>("Telefone")
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("TELEFONE");

                    b.HasKey("Id")
                        .HasName("Pk_aluno_id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("AlunoTB");
                });

            modelBuilder.Entity("Escola.API.Model.AlunoTurma", b =>
                {
                    b.Property<int>("AlunoID")
                        .HasColumnType("int")
                        .HasColumnName("Aluno_Id");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int")
                        .HasColumnName("Turma_Id");

                    b.HasKey("AlunoID", "TurmaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("ALUNO_X_TURMA");
                });

            modelBuilder.Entity("Escola.API.Model.Boletim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId")
                        .HasColumnType("int")
                        .HasColumnName("Aluno_Id");

                    b.Property<DateTime>("Data_Pedido")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data_Consulta");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("BOLETIM");
                });

            modelBuilder.Entity("Escola.API.Model.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeMateria")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Nome_Materia");

                    b.HasKey("Id");

                    b.ToTable("MATÉRIA");
                });

            modelBuilder.Entity("Escola.API.Model.NotasMateria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoletimId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoletimId");

                    b.HasIndex("MateriaId");

                    b.ToTable("NotasMaterias");
                });

            modelBuilder.Entity("Escola.API.Model.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Curso")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Curso Basico")
                        .HasColumnName("CURSO");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasFilter("[Nome] IS NOT NULL");

                    b.ToTable("TURMA");
                });

            modelBuilder.Entity("Escola.API.Model.AlunoTurma", b =>
                {
                    b.HasOne("Escola.API.Model.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escola.API.Model.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Escola.API.Model.Boletim", b =>
                {
                    b.HasOne("Escola.API.Model.Aluno", "Aluno")
                        .WithMany("Boletims")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Escola.API.Model.NotasMateria", b =>
                {
                    b.HasOne("Escola.API.Model.Boletim", "Boletim")
                        .WithMany("NotasMaterias")
                        .HasForeignKey("BoletimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escola.API.Model.Materia", "Materia")
                        .WithMany("NotasMaterias")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Boletim");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("Escola.API.Model.Aluno", b =>
                {
                    b.Navigation("Boletims");
                });

            modelBuilder.Entity("Escola.API.Model.Boletim", b =>
                {
                    b.Navigation("NotasMaterias");
                });

            modelBuilder.Entity("Escola.API.Model.Materia", b =>
                {
                    b.Navigation("NotasMaterias");
                });
#pragma warning restore 612, 618
        }
    }
}
