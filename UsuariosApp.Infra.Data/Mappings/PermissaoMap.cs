using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsuariosApp.Domain.Models.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class PermissaoMap : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("PERMISSAO"); //nome da tabela
            builder.HasKey(x => x.Id);//chave primária

            //mapeamento dos demais campos
            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.Nome).HasColumnName("NOME")
                .HasMaxLength(50).IsRequired();

            builder.HasIndex(p=> p.Nome).IsUnique();//criando um indice -> campo único
        }
    }
}
