using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto_AppFinanzas.Models
{
    public partial class finanzasContext : DbContext
    {
        public finanzasContext()
        {
        }

        public finanzasContext(DbContextOptions<finanzasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Configuracion> Configuracions { get; set; }
        public virtual DbSet<Gasto> Gastos { get; set; }
        public virtual DbSet<Ingreso> Ingresos { get; set; }
        public virtual DbSet<Texto> Textos { get; set; }
        public virtual DbSet<TipoGasto> TipoGastos { get; set; }
        public virtual DbSet<TipoIngreso> TipoIngresos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=new.c2kbets.com;user=jimmy;password=Jimmy12345;database=finanzas", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.41-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("configuracion");

                entity.HasIndex(e => e.IdConfiguracion, "id_configuracion");

                entity.Property(e => e.IdConfiguracion)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_configuracion");

                entity.Property(e => e.Notificaciones).HasColumnName("notificaciones");

                entity.Property(e => e.Tema).HasColumnName("tema");

                entity.HasOne(d => d.IdConfiguracionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdConfiguracion)
                    .HasConstraintName("configuracion_ibfk_1");
            });

            modelBuilder.Entity<Gasto>(entity =>
            {
                entity.HasKey(e => e.IdGastos)
                    .HasName("PRIMARY");

                entity.ToTable("gastos");

                entity.HasIndex(e => e.IdUsuario, "id_usuario");

                entity.Property(e => e.IdGastos)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_gastos");

                entity.Property(e => e.Automatico).HasColumnName("automatico");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.IdUsuario)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_usuario");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Notificacion).HasColumnName("notificacion");

                entity.Property(e => e.Tipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Gastos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("gastos_ibfk_1");
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.HasKey(e => e.IdIngresos)
                    .HasName("PRIMARY");

                entity.ToTable("ingresos");

                entity.HasIndex(e => e.Id, "id");

                entity.Property(e => e.IdIngresos)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_ingresos");

                entity.Property(e => e.Automatico).HasColumnName("automatico");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Notificacion).HasColumnName("notificacion");

                entity.Property(e => e.Tipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("ingresos_ibfk_1");
            });

            modelBuilder.Entity<Texto>(entity =>
            {
                entity.HasKey(e => e.IdTexto)
                    .HasName("PRIMARY");

                entity.ToTable("textos");

                entity.Property(e => e.IdTexto)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_texto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoGasto>(entity =>
            {
                entity.ToTable("tipo_gasto");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Tipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TipoGasto)
                    .HasForeignKey<TipoGasto>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tipo_gasto_ibfk_1");
            });

            modelBuilder.Entity<TipoIngreso>(entity =>
            {
                entity.ToTable("tipo_ingreso");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Tipo)
                    .HasColumnType("int(11)")
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TipoIngreso)
                    .HasForeignKey<TipoIngreso>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tipo_ingreso_ibfk_1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasColumnType("int(11)")
                    .HasColumnName("codigo");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(255)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Correo)
                    .HasMaxLength(255)
                    .HasColumnName("correo");

                entity.Property(e => e.Estado)
                    .HasColumnType("int(11)")
                    .HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Validado).HasColumnName("validado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
