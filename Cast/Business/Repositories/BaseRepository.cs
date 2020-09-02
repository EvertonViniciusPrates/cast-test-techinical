using Cast.Data.Context;
using Cast.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cast.Business.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly CursoDBContext _context;

        protected BaseRepository(CursoDBContext context)
        {
            _context = context;
        }

        public T Save(T objeto)
        {
            objeto.Id = Guid.NewGuid();
            _context.Set<T>().Add(objeto);

            return objeto;
        }

        public T Update(T objeto)
        {
            _context.Set<T>().Update(objeto);

            return objeto;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);

            _context.Remove(obj);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}