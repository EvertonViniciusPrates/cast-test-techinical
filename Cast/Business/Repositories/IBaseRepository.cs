using Cast.Model;
using System;
using System.Collections.Generic;

namespace Cast.Business.Repositories
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        T Save(T objeto);

        T Update(T objeto);

        void Remove(Guid id);

        List<T> GetAll();

        T GetById(Guid id);

        bool Commit();
    }
}
