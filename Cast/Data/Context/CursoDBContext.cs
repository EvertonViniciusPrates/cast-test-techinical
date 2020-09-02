using Cast.Data.Mappers;
using Cast.Model;
using Microsoft.EntityFrameworkCore;

namespace Cast.Data.Context
{
    public class CursoDBContext : DbContext
    {
        public CursoDBContext(DbContextOptions<CursoDBContext> options)
               : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}