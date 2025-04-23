using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Models.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");//nome da tabela
            builder.HasKey(u => u.Id);//chave primaria
            builder.Property(u => u.Id).HasColumnName("ID");

            builder.Property(u => u.Nome)
                .HasColumnName("NOME").HasMaxLength(100).IsRequired();

            builder.Property(u=> u.Email)
                .HasColumnName("EMAIL").HasMaxLength(50).IsRequired();

            builder.HasIndex(u=> u.Email).IsUnique();

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA").HasMaxLength(100).IsRequired();



        }
    }
}
