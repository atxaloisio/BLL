using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;


namespace BLL
{
    public class FilialBLL : BaseBLL, IDisposable
    {
        IFilialRepositorio _FilialRepositorio;
        public FilialBLL()
        {
            try
            {
                _FilialRepositorio = new FilialRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Filial> getFilial(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _FilialRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _FilialRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Filial> getFilial(Expression<Func<Filial, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _FilialRepositorio.getTotalRegistros();
                return _FilialRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Filial> getFilial(Expression<Func<Filial, bool>> predicate, Expression<Func<Filial, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _FilialRepositorio.getTotalRegistros(predicate);
                return _FilialRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Filial> getFilial(Expression<Func<Filial, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Filial, string>>[] ordem)
        {
            try
            {
                totalRecords = _FilialRepositorio.getTotalRegistros(predicate);
                return _FilialRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Filial> getFilial(Expression<Func<Filial, bool>> predicate, bool desc, params Expression<Func<Filial, string>>[] ordem)
        {
            try
            {

                return _FilialRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Filial> getFilial(Expression<Func<Filial, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (NoTracking)
                {
                    return _FilialRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _FilialRepositorio.Get(predicate).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public virtual List<FilialView> ToList_FilialView(List<Filial> lst)
        {
            List<FilialView> lstRetorno = new List<FilialView>();

            foreach (Filial item in lst)
            {
                lstRetorno.Add(new FilialView
                {
                    Id = item.Id,
                    cnpj = item.cnpj,
                    codigo_filial = item.codigo_filial,
                    codigo_filial_integracao = item.codigo_filial_integracao,
                    Id_empresa = item.Id_empresa,
                    nome_fantasia = item.nome_fantasia,
                    razao_social = item.razao_social
                });
            }

            return lstRetorno;

        }

        public virtual List<FilialView> ToList_FilialView(ICollection<Filial> lst)
        {
            List<FilialView> lstRetorno = new List<FilialView>();

            foreach (Filial item in lst)
            {
                lstRetorno.Add(new FilialView
                {
                    Id = item.Id,
                    cnpj = item.cnpj,
                    codigo_filial = item.codigo_filial,
                    codigo_filial_integracao = item.codigo_filial_integracao,
                    Id_empresa = item.Id_empresa,
                    nome_fantasia = item.nome_fantasia,
                    razao_social = item.razao_social
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarFilial(Filial Filial)
        {
            try
            {
                _FilialRepositorio.Adicionar(Filial);
                _FilialRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Filial Localizar(long? id)
        {
            try
            {
                return _FilialRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirFilial(Filial Filial)
        {
            try
            {
                _FilialRepositorio.Deletar(c => c == Filial);
                _FilialRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarFilial(Filial Filial)
        {
            try
            {
                _FilialRepositorio.Atualizar(Filial);
                _FilialRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_FilialRepositorio != null)
            {
                _FilialRepositorio.Dispose();
            }

        }
    }
}
