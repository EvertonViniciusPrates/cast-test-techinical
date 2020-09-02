using Cast.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Cast.Data.Mappers
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categorias", "dbo");
            builder.HasKey(x => x.Id).HasName("cd_categoria_id");
            builder.Property(x => x.Id).HasColumnName("cd_categoria_id");
            builder.Property(x => x.Descricao).HasColumnName("ds_descricao").HasMaxLength(100);
        }
    }
}
