using Cast.Model.DTOs;
using System;

namespace Cast.Model
{
    public class Curso : EntityBase
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int QuantidadeDeAlunos { get; set; }
        public Categoria Categoria { get; private set; }
        public Guid CategoriaId { get; set; }

        public Curso()
        {
        }

        public Curso(string descricao, DateTime dataInicio, DateTime dataTermino, int quantidadeDeAlunos, Categoria categoria, Guid categoriaId)
        {
            Descricao = descricao;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            QuantidadeDeAlunos = quantidadeDeAlunos;
            Categoria = categoria;
            CategoriaId = categoriaId;
        }

        public Curso(Guid id, string descricao, DateTime dataInicio, DateTime dataTermino, int quantidadeDeAlunos, Guid categoriaId)
        {
            Id = id;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            QuantidadeDeAlunos = quantidadeDeAlunos;
            CategoriaId = categoriaId;
        }

        public static explicit operator Curso(CursoDTO curso)
        {
            return new Curso(curso.Id, curso.Descricao, curso.DataInicio, curso.DataTermino, curso.QuantidadeDeAlunos, curso.CategoriaId);
        }
    }
}
