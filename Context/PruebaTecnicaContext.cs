using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PruebaTecnica.Models;

namespace PruebaTecnica.Context
{
    public class PruebaTecnicaContext : DbContext
    {
        public PruebaTecnicaContext() : base("name=PruebaTecnica")
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .ToTable("Personas")
                .HasKey(p => p.Identificador);

            modelBuilder.Entity<Persona>()
                .Property(p => p.Identificador)
                .IsRequired()
                .HasColumnName("Id");

            modelBuilder.Entity<Persona>()
                .Property(p => p.Nombres)
                .IsRequired()
                .HasColumnName("Nombres")
                .HasMaxLength(100);

            modelBuilder.Entity<Persona>()
                .Property(p => p.Apellidos)
                .IsRequired()
                .HasColumnName("Apellidos")
                .HasMaxLength(100);

            modelBuilder.Entity<Persona>()
                .Property(p => p.NumeroIdentificacion)
                .IsRequired()
                .HasColumnName("NumIdentificacion")
                .HasMaxLength(50);

            modelBuilder.Entity<Persona>()
                .Property(p => p.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Persona>()
                .Property(p => p.TipoIdentificacion)
                .IsRequired()
                .HasColumnName("TipoIdentificacion")
                .HasMaxLength(50);

            modelBuilder.Entity<Persona>()
                .Property(p => p.FechaCreacion)
                .HasColumnName("FechaCreacion");

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.Identificador);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Identificador)
                .IsRequired()
                .HasColumnName("Id");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.UsuarioNombre)
                .IsRequired()
                .HasColumnName("Usuario")
                .HasMaxLength(50);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Pass)
                .IsRequired()
                .HasColumnName("Pass")
                .HasMaxLength(50);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.HashKey)
                .IsRequired()
                .HasColumnName("HashKey");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.HashIV)
                .IsRequired()
                .HasColumnName("HashIV");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.FechaCreacion)
                .HasColumnName("FechaCreacion");

            base.OnModelCreating(modelBuilder);
        }
    }
}