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
    public class UsuarioPermissaoMap : IEntityTypeConfiguration<UsuarioPermissao>
    {
        public void Configure(EntityTypeBuilder<UsuarioPermissao> builder)
        {
            builder.ToTable("USUARIO_PERMISSAO");

            builder.HasKey(up => new
            {
                up.UsuarioId,
                up.PermissaoId
            });

            builder.Property(up => up.UsuarioId).HasColumnName("USUARIO_ID");
            builder.Property(up => up.PermissaoId).HasColumnName("PERMISSAO_ID");

            builder.HasOne(up => up.Usuario)//usuario tem
                .WithMany(u => u.Permissoes)//muitas permissoes
                .HasForeignKey(up => up.UsuarioId); //chave estrangeira

            //mapeando o relacionamento com a entidade Permissão
            builder.HasOne(up=> up.Permissao)//Permissao tem
                .WithMany(u => u.Usuarios)//muitos usuarios
                .HasForeignKey(up => up.PermissaoId);//chave estrangeira
        }
    }
}
