using Microsoft.EntityFrameworkCore;
using Senai.InLock.CodeFirst.WebApi.Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Context
{
    public class InLockContext : DbContext
    {
        public InLockContext()
        {

        }

        public InLockContext(DbContextOptions<InLockContext> options) : base(options)
        {

        }

        public DbSet<EstudioDomain> Estudios { get; set; }
        public DbSet<JogoDomain> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; initial Catalog= InLock_CodeFirst_Tarde; User id = sa; password = 132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.HasKey(e => e.EstudiosId);

                entity.Property(e => e.NomeEstudio)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Jogos>(entity =>
            {
                entity.HasKey(e => e.JogoId);

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Descricao)
                .IsRequired()
                .HasColumnType("text");

                entity.Property(e => e.NomeJogo)
                .IsRequired()
                .HasMaxLenght(50)
                .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(5, 2");

                entity.HasOne(d => d.Estudio)
                .WithMany(p => p.Jogos)
                .HasForeignKey(d => d.EstudioId)
                .HasConstraintName("FK_Jogos_EstudioId_4D948798");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLenght(100)
                .IsUnicode(false);
            });
        }
    }
}
