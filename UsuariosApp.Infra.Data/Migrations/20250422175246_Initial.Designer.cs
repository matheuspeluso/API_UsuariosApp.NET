﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UsuariosApp.Infra.Data.Context;

#nullable disable

namespace UsuariosApp.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250422175246_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UsuariosApp.Domain.Models.Entities.Permissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("PERMISSAO", (string)null);
                });

            modelBuilder.Entity("UsuariosApp.Domain.Models.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SENHA");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("UsuariosApp.Domain.Models.Entities.UsuarioPermissao", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USUARIO_ID");

                    b.Property<Guid>("PermissaoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PERMISSAO_ID");

                    b.HasKey("UsuarioId", "PermissaoId");

                    b.HasIndex("PermissaoId");

                    b.ToTable("USUARIO_PERMISSAO", (string)null);
                });

            modelBuilder.Entity("UsuariosApp.Domain.Models.Entities.UsuarioPermissao", b =>
                {
                    b.HasOne("UsuariosApp.Domain.Models.Entities.Permissao", "Permissao")
                        .WithMany("Usuarios")
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UsuariosApp.Domain.Models.Entities.Usuario", "Usuario")
                        .WithMany("Permissoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permissao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("UsuariosApp.Domain.Models.Entities.Permissao", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("UsuariosApp.Domain.Models.Entities.Usuario", b =>
                {
                    b.Navigation("Permissoes");
                });
#pragma warning restore 612, 618
        }
    }
}
