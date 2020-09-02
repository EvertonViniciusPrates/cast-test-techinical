using Cast.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cast.Data.Mappers
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("cursos", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("cd_curso_id");
            builder.Property(x => x.Descricao).HasColumnName("ds_descricao").HasMaxLength(100);
            builder.Property(x => x.DataInicio).HasColumnName("dt_inicio").IsRequired();
            builder.Property(x => x.DataTermino).HasColumnName("dt_termino").IsRequired();
            builder.Property(x => x.QuantidadeDeAlunos).HasColumnName("qtd_alunos");
            builder.Property(x => x.CategoriaId).HasColumnName("cd_categoria");
            builder.HasOne(x => x.Categoria).WithOne().HasForeignKey<Categoria>(x => x.Id);
        }
    }
}
