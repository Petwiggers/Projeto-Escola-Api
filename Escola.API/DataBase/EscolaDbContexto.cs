using Microsoft.EntityFrameworkCore;
using Escola.API.Model;

namespace Escola.API.DataBase
{
    public class EscolaDbContexto : DbContext
    {
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<AlunoTurma> AlunoTurma { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Boletim> Boletims { get; set; }
        public virtual DbSet<NotasMateria> NotasMaterias { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Escola;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("AlunoTB");

            modelBuilder.Entity<Aluno>().HasKey(x => x.Id)
                        .HasName("Pk_aluno_id");

            modelBuilder.Entity<Aluno>().Property(x => x.Id)
                        .HasColumnName("PK_ID" )
                        .HasColumnType("INT");

            modelBuilder.Entity<Aluno>().Property(x => x.Nome)
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(50);

            modelBuilder.Entity<Aluno>().Property(x => x.Sobrenome)
                        .IsRequired()
                        .HasColumnName("SOBRENOME")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(150);

            modelBuilder.Entity<Aluno>().Ignore(x => x.Idade);

            modelBuilder.Entity<Aluno>().Property(x => x.Email)
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(50);


            modelBuilder.Entity<Aluno>().HasIndex(x => x.Email)
                        .IsUnique();

            modelBuilder.Entity<Aluno>().Property(x => x.Genero)
                        .HasColumnName("GENERO")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(20);

            modelBuilder.Entity<Aluno>().Property(x => x.Telefone)
                        .HasColumnName("TELEFONE")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(30);

            modelBuilder.Entity<Aluno>().Property(x => x.DataNascimento)
                        .HasColumnName("DATA_NASCIMENTO")
                        .HasColumnType("datetime2");


            modelBuilder.Entity<Turma>().ToTable("TURMA");

            modelBuilder.Entity<Turma>().Property(x => x.Id)
                        .HasColumnType("int")
                        .HasColumnName("ID");

            modelBuilder.Entity<Turma>().HasKey(x => x.Id);


            modelBuilder.Entity<Turma>().Property(x => x.Curso)
                        .HasColumnType("varchar")
                        .HasMaxLength(50)
                        .HasDefaultValue("Curso Basico")
                        .HasColumnName("CURSO");

            modelBuilder.Entity<Turma>().Property(x => x.Nome)
                        .HasColumnType("varchar")
                        .HasMaxLength(50)
                        .HasColumnName("Nome");

            modelBuilder.Entity<Turma>().HasIndex(x => x.Nome)
                        .IsUnique();

            modelBuilder.Entity<AlunoTurma>().ToTable("ALUNO_X_TURMA");
            modelBuilder.Entity<AlunoTurma>().Property(x => x.AlunoID)
                        .HasColumnType("int")
                        .HasColumnName("Aluno_Id");

            modelBuilder.Entity<AlunoTurma>().Property(x => x.TurmaId)
                        .HasColumnType("int")
                        .HasColumnName("Turma_Id");

            modelBuilder.Entity<Aluno>().HasMany(x => x.Turmas)
                        .WithMany(x => x.Alunos)
                        .UsingEntity<AlunoTurma>(
                                    t => t.HasOne<Turma>(x => x.Turma).WithMany().HasForeignKey(x => x.TurmaId),
                                    a => a.HasOne<Aluno>(x => x.Aluno).WithMany().HasForeignKey(x => x.AlunoID)
                                    );

            modelBuilder.Entity<Boletim>().ToTable("BOLETIM")
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Boletim>().Property(x => x.AlunoId)
                        .HasColumnType("int")
                        .IsRequired()
                        .HasColumnName("Aluno_Id");

            modelBuilder.Entity<Boletim>().Property(x => x.Data_Pedido)
                        .HasColumnType("datetime2")
                        .IsRequired()
                        .HasColumnName("Data_Consulta");

            modelBuilder.Entity<Boletim>().HasOne(x => x.Aluno)
                        .WithMany(x => x.Boletims)
                        .HasForeignKey(x => x.AlunoId);

            modelBuilder.Entity<Boletim>().HasMany(x => x.NotasMaterias)
                        .WithOne(x => x.Boletim)
                        .HasForeignKey(x => x.BoletimId);

            modelBuilder.Entity<NotasMateria>().HasOne(x => x.Materia)
                        .WithMany(x => x.NotasMaterias)
                        .HasForeignKey(x=> x.MateriaId);

            modelBuilder.Entity<Materia>().ToTable("MATÉRIA").HasKey(X => X.Id);

            modelBuilder.Entity<Materia>().Property(x => x.NomeMateria)
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("Nome_Materia")
                        .HasMaxLength(200);

            modelBuilder.Entity<NotasMateria>().ToTable("NOTAS_MATERIAS").HasKey(x => x.Id);

            modelBuilder.Entity<Usuario>().ToTable("USUÁRIOS").HasKey(x => x.Login);
            modelBuilder.Entity<Usuario>().Property(x => x.Login)
                        .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.NomeCompleto)
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .HasColumnName("NOME_COMPLETO")
                        .IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.Login)
                       .HasColumnType("varchar")
                       .HasMaxLength(100)
                       .HasColumnName("NOME_USUARIO")
                       .IsRequired();

            modelBuilder.Entity<Usuario>().Property(x => x.Senha)
                       .HasColumnType("varchar")
                       .HasMaxLength(300)
                       .HasColumnName("SENHA")
                       .IsRequired();

        }
    }
}
