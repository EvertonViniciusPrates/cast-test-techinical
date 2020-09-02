using Cast.Model;
using Cast.Model.DTOs;
using Cast.Util.Results;
using System;

namespace Cast.Business.Services
{
    public interface ICursoService
    {
        public ResultSet<CursoDTO> Save(CursoDTO curso);
        public ResultSet<CursoDTO> Delete(Guid id);
        public ResultSet<CursoDTO> Update(CursoDTO curso);
        public ResultSet<CursoDTO> GetById(Guid id);
        public ResultSet<CursoDTO> GetAll();
    }
}
