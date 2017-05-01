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
    public class CNAEBLL : BaseBLL, IDisposable
    {
        ICNAERepositorio _CNAERepositorio;
        public CNAEBLL()
        {
            try
            {
                _CNAERepositorio = new CNAERepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<CNAE> getCNAE(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _CNAERepositorio.GetTodos().ToList();
                }
                else
                {
                    return _CNAERepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<CNAE> getCNAE(Expression<Func<CNAE, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _CNAERepositorio.getTotalRegistros();
                return _CNAERepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<CNAE> getCNAE(Expression<Func<CNAE, bool>> predicate, Expression<Func<CNAE, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _CNAERepositorio.getTotalRegistros(predicate);
                return _CNAERepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<CNAE> getCNAE(Expression<Func<CNAE, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<CNAE, string>>[] ordem)
        {
            try
            {
                totalRecords = _CNAERepositorio.getTotalRegistros(predicate);
                return _CNAERepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<CNAE> getCNAE(Expression<Func<CNAE, bool>> predicate, bool desc, params Expression<Func<CNAE, string>>[] ordem)
        {
            try
            {

                return _CNAERepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<CNAE> getCNAE(Expression<Func<CNAE, bool>> predicate)
        {
            try
            {
                return _CNAERepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarCNAE(CNAE CNAE)
        {
            try
            {
                _CNAERepositorio.Adicionar(CNAE);
                _CNAERepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual CNAE Localizar(long? id)
        {
            try
            {
                return _CNAERepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCNAE(CNAE CNAE)
        {
            try
            {
                _CNAERepositorio.Deletar(c => c == CNAE);
                _CNAERepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCNAE(CNAE CNAE)
        {
            try
            {
                _CNAERepositorio.Atualizar(CNAE);
                _CNAERepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_CNAERepositorio != null)
            {
                _CNAERepositorio.Dispose();
            }

        }
    }
}
