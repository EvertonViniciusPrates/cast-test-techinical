using System;

namespace Cast.Model.DTOs
{
    public class CursoDTO : EntityBase
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int QuantidadeDeAlunos { get; set; }
        public Guid CategoriaId { get; set; }

        public CursoDTO() { }

        public CursoDTO(Guid id, string descricao, DateTime dataInicio, DateTime dataTermino, int quantidadeDeAlunos, Guid categoriaId)
        {
            Id = id;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            QuantidadeDeAlunos = quantidadeDeAlunos;
            CategoriaId = categoriaId;
        }

        public static explicit operator CursoDTO(Curso curso)
        {
            if (curso != null)
                return new CursoDTO(curso.Id, curso.Descricao, curso.DataInicio, curso.DataTermino, curso.QuantidadeDeAlunos, curso.CategoriaId);
            return null;
        }
    }
}
