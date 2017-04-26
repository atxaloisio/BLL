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
    public class FormasPagVendaBLL : BaseBLL, IDisposable
    {
        IFormasPagVendaRepositorio _FormasPagVendaRepositorio;
        public FormasPagVendaBLL()
        {
            try
            {
                _FormasPagVendaRepositorio = new FormasPagVendaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<FormasPagVenda> getFormasPagVenda(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _FormasPagVendaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _FormasPagVendaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<FormasPagVenda> getFormasPagVenda(Expression<Func<FormasPagVenda, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _FormasPagVendaRepositorio.getTotalRegistros();
                return _FormasPagVendaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<FormasPagVenda> getFormasPagVenda(Expression<Func<FormasPagVenda, bool>> predicate, Expression<Func<FormasPagVenda, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _FormasPagVendaRepositorio.getTotalRegistros(predicate);
                return _FormasPagVendaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<FormasPagVenda> getFormasPagVenda(Expression<Func<FormasPagVenda, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<FormasPagVenda, string>>[] ordem)
        {
            try
            {
                totalRecords = _FormasPagVendaRepositorio.getTotalRegistros(predicate);
                return _FormasPagVendaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<FormasPagVenda> getFormasPagVenda(Expression<Func<FormasPagVenda, bool>> predicate, bool desc, params Expression<Func<FormasPagVenda, string>>[] ordem)
        {
            try
            {                
                return _FormasPagVendaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public virtual List<FormasPagVenda> getFormasPagVenda(Expression<Func<FormasPagVenda, bool>> predicate)
        {
            try
            {
                return _FormasPagVendaRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarFormasPagVenda(FormasPagVenda FormasPagVenda)
        {
            try
            {
                _FormasPagVendaRepositorio.Adicionar(FormasPagVenda);
                _FormasPagVendaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual FormasPagVenda Localizar(long? id)
        {
            try
            {
                return _FormasPagVendaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirFormasPagVenda(FormasPagVenda FormasPagVenda)
        {
            try
            {
                _FormasPagVendaRepositorio.Deletar(c => c == FormasPagVenda);
                _FormasPagVendaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarFormasPagVenda(FormasPagVenda FormasPagVenda)
        {
            try
            {
                _FormasPagVendaRepositorio.Atualizar(FormasPagVenda);
                _FormasPagVendaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_FormasPagVendaRepositorio != null)
            {
                _FormasPagVendaRepositorio.Dispose();
            }

        }
    }
}
