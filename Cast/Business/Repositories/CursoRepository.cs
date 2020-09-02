using Cast.Data.Context;
using Cast.Model;

namespace Cast.Business.Repositories
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(CursoDBContext context) : base(context)
        {
        }
    }
}