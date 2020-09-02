using Cast.Business.Messages;
using Cast.Business.Repositories;
using Cast.Model;
using Cast.Model.DTOs;
using Cast.Util.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cast.Business.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public ResultSet<CursoDTO> Delete(Guid id)
        {
            ResultSet<CursoDTO> result;
            CursoDTO obj = new CursoDTO();
            try
            {
                obj = (CursoDTO)_cursoRepository.GetById(id);

                if (obj != null)
                {
                    _cursoRepository.Remove(id);
                    _cursoRepository.Commit();
                    result = new ResultSet<CursoDTO>(obj, MensagensGeral.REMOVE_SUCESSO);
                }
                else
                {
                    result = new ResultSet<CursoDTO>(obj, MensagensGeral.REMOVE_ERRO);
                }
            }
            catch (Exception EX)
            {
                result = new ResultSet<CursoDTO>(obj, MensagensGeral.EXCECAO + EX.Message);
            }
            return result;
        }

        public ResultSet<CursoDTO> Save(CursoDTO curso)
        {
            ResultSet<CursoDTO> result = null;
            if (curso.DataInicio >= DateTime.Now)
            {
                CursoDTO obj = null;
                try
                {
                    if (IsFieldObrigatory(curso))
                    {
                        result = new ResultSet<CursoDTO>(obj, MensagensGeral.CAMPO_OBRIGATORIO_NAO_PREENCHIDO);
                    }
                    else
                    {
                        if (IsPeriodConflit(curso))
                        {
                            result = new ResultSet<CursoDTO>(obj, MensagensGeral.PERIODO_ALERTA_MESMO_PERIODO);
                        }
                        else
                        {
                            if (curso.DataTermino <= curso.DataInicio)
                            {
                                result = new ResultSet<CursoDTO>(obj, MensagensGeral.PERIODO_ALERTA_TERMINO_INFERIOR);
                            }
                            else
                            {
                                obj = (CursoDTO)_cursoRepository.Save((Curso)curso);
                                if (obj != null)
                                {
                                    _cursoRepository.Commit();
                                    result = new ResultSet<CursoDTO>(obj, MensagensGeral.CADASTRA_SUCESSO);
                                }
                                else
                                {
                                    result = new ResultSet<CursoDTO>(obj, MensagensGeral.CADASTRA_ERRO);
                                }
                            }
                        }
                    }
                }
                catch (Exception EX)
                {
                    result = new ResultSet<CursoDTO>(obj, MensagensGeral.EXCECAO + EX.Message);
                }
            }
            else
                result = new ResultSet<CursoDTO>(curso, MensagensGeral.PERIODO_ALERTA_INFERIOR);

            return result;
        }

        public ResultSet<CursoDTO> Update(CursoDTO curso)
        {
            ResultSet<CursoDTO> result;
            Curso obj = null;
            if (curso != null)
                try
                {
                    obj = _cursoRepository.GetById(curso.Id);

                    if (IsFieldObrigatory(curso))
                    {
                        result = new ResultSet<CursoDTO>((CursoDTO)obj, MensagensGeral.CAMPO_OBRIGATORIO_NAO_PREENCHIDO);
                    }
                    else
                    {
                        if (IsPeriodConflit(curso))
                        {
                            result = new ResultSet<CursoDTO>((CursoDTO)obj, MensagensGeral.PERIODO_ALERTA_MESMO_PERIODO);
                        }
                        else
                        {
                            if (curso.DataTermino <= curso.DataInicio)
                            {
                                result = new ResultSet<CursoDTO>((CursoDTO)obj, MensagensGeral.PERIODO_ALERTA_TERMINO_INFERIOR);
                            }
                            else
                            {
                                if (obj != null)
                                {
                                    obj.CategoriaId = curso.CategoriaId;
                                    obj.DataInicio = curso.DataInicio;
                                    obj.DataTermino = curso.DataTermino;
                                    obj.QuantidadeDeAlunos = curso.QuantidadeDeAlunos;
                                    obj.Descricao = curso.Descricao;
                                    _cursoRepository.Update(obj);
                                    _cursoRepository.Commit();
                                    result = new ResultSet<CursoDTO>((CursoDTO)obj, MensagensGeral.ALTERA_SUCESSO);
                                }
                                else
                                {
                                    result = new ResultSet<CursoDTO>((CursoDTO)obj, MensagensGeral.ALTERA_ERRO);
                                }
                            }
                        }
                    }

                   
                }
                catch (Exception EX)
                {
                    result = new ResultSet<CursoDTO>((CursoDTO)obj, MensagensGeral.EXCECAO + EX.Message);
                }
            else
                result = new ResultSet<CursoDTO>((CursoDTO)obj, MensagensGeral.ALTERA_ERRO);

            return result;
        }
        public ResultSet<CursoDTO> GetById(Guid id)
        {
            ResultSet<CursoDTO> result;
            CursoDTO obj = (CursoDTO)_cursoRepository.GetById(id);
            if (obj != null)
                result = new ResultSet<CursoDTO>(obj, null);
            else
                result = new ResultSet<CursoDTO>(obj, MensagensGeral.CONSULTA_ZERO_RESULTADOS);

            return result;
        }
        public ResultSet<CursoDTO> GetAll()
        {
            ResultSet<CursoDTO> result;
            List<CursoDTO> obj = _cursoRepository.GetAll()
                .Select(x => new CursoDTO(x.Id, x.Descricao, x.DataInicio, x.DataTermino, x.QuantidadeDeAlunos, x.CategoriaId)).ToList();

            if (obj != null)
                result = new ResultSet<CursoDTO>(obj, null);
            else
                result = new ResultSet<CursoDTO>(obj, MensagensGeral.CONSULTA_ZERO_RESULTADOS);

            return result;
        }

        private bool IsPeriodConflit(CursoDTO curso)
        {
            return _cursoRepository.GetAll().Where(x => curso.Id != x.Id && (
                                                        curso.DataInicio >= x.DataInicio && curso.DataInicio <= x.DataTermino ||
                                                        curso.DataInicio <= x.DataTermino && curso.DataTermino >= x.DataTermino ||
                                                        curso.DataInicio >= x.DataInicio && curso.DataTermino <= x.DataTermino ||
                                                        curso.DataInicio <= x.DataInicio && curso.DataTermino >= x.DataTermino ||
                                                        curso.DataInicio <= x.DataInicio && curso.DataTermino <= x.DataTermino && curso.DataTermino >= x.DataInicio)
                                                        ).Any();
        }
        private bool IsFieldObrigatory(CursoDTO curso)
        {
            if (string.IsNullOrEmpty(curso.Descricao) || curso.DataInicio == null || curso.DataTermino == null || curso.CategoriaId == null)
                return true;
            return false;
        }
    }
}
