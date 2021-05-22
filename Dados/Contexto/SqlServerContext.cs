using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Dados.Contexto
{
    public partial class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Local> Locals { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Reuniao> Reuniaos { get; set; }
        public virtual DbSet<ReuniaoLocal> ReuniaoLocals { get; set; }
        public virtual DbSet<ReuniaoPessoa> ReuniaoPessoas { get; set; }
        public virtual DbSet<Sessao> Sessaos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tecweb-180861.database.windows.net;Initial Catalog=TECWEB; Persist Security Info=False; User ID=dbmx1080861; Password=dbMX1808tp; MultipleActiveResultSets=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Local>(entity =>
            {
                entity.ToTable("Local");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO");

                entity.Property(e => e.Dtcriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DTCRIACAO");

                entity.Property(e => e.Excluido).HasColumnName("EXCLUIDO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Excluido).HasColumnName("EXCLUIDO");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.Telefone).HasColumnName("TELEFONE");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK_Pessoa_Usuario");
            });

            modelBuilder.Entity<Reuniao>(entity =>
            {
                entity.ToTable("Reuniao");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Datafim)
                    .HasColumnType("datetime")
                    .HasColumnName("DATAFIM");

                entity.Property(e => e.Dataincio)
                    .HasColumnType("datetime")
                    .HasColumnName("DATAINCIO");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO");

                entity.Property(e => e.Dtcriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DTCRIACAO");

                entity.Property(e => e.Excluido).HasColumnName("EXCLUIDO");

                entity.Property(e => e.IdLocal).HasColumnName("ID_LOCAL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.Usuariocriador).HasColumnName("USUARIOCRIADOR");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.Reuniaos)
                    .HasForeignKey(d => d.IdLocal)
                    .HasConstraintName("FK_Reuniao_Reuniao_Local");

                entity.HasOne(d => d.UsuariocriadorNavigation)
                    .WithMany(p => p.Reunioes)
                    .HasForeignKey(d => d.Usuariocriador)
                    .HasConstraintName("FK_Reuniao_Usuario");
            });

            modelBuilder.Entity<ReuniaoLocal>(entity =>
            {
                entity.ToTable("Reuniao_Local");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Dtcriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DTCRIACAO");

                entity.Property(e => e.Excluido).HasColumnName("EXCLUIDO");

                entity.Property(e => e.IdLocal).HasColumnName("ID_LOCAL");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.ReuniaoLocals)
                    .HasForeignKey(d => d.IdLocal)
                    .HasConstraintName("FK_Reuniao_Local_Local");
            });

            modelBuilder.Entity<ReuniaoPessoa>(entity =>
            {
                entity.ToTable("Reuniao_Pessoa");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Dtcriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DTCRIACAO");

                entity.Property(e => e.Exlcuido).HasColumnName("EXLCUIDO");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdReuniao).HasColumnName("ID_REUNIAO");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.ReuniaoPessoas)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK_Reuniao_Pessoa_Pessoa");

                entity.HasOne(d => d.IdReuniaoNavigation)
                    .WithMany(p => p.ReuniaoPessoas)
                    .HasForeignKey(d => d.IdReuniao)
                    .HasConstraintName("FK_Reuniao_Pessoa_Reuniao");
            });

            modelBuilder.Entity<Sessao>(entity =>
            {
                entity.ToTable("Sessao");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Dtcriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DTCRIACAO");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Sessoes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Sessao_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Dtcriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DTCRIACAO")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Excluido).HasColumnName("EXCLUIDO");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LOGIN");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SENHA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
