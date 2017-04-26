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
    public class Cliente_TagBLL : BaseBLL, IDisposable
    {
        ICliente_TagRepositorio _Cliente_TagRepositorio;
        public Cliente_TagBLL()
        {
            try
            {
                _Cliente_TagRepositorio = new Cliente_TagRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Tag> getCliente_Tag(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Cliente_TagRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Cliente_TagRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Tag> getCliente_Tag(Expression<Func<Cliente_Tag, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Cliente_TagRepositorio.getTotalRegistros();
                return _Cliente_TagRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Tag> getCliente_Tag(Expression<Func<Cliente_Tag, bool>> predicate, Expression<Func<Cliente_Tag, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Cliente_TagRepositorio.getTotalRegistros(predicate);
                return _Cliente_TagRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Tag> getCliente_Tag(Expression<Func<Cliente_Tag, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords,params Expression<Func<Cliente_Tag, string>>[] ordem)
        {
            try
            {
                totalRecords = _Cliente_TagRepositorio.getTotalRegistros(predicate);
                return _Cliente_TagRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Tag> getCliente_Tag(Expression<Func<Cliente_Tag, bool>> predicate, bool desc, params Expression<Func<Cliente_Tag, string>>[] ordem)
        {
            try
            {
                
                return _Cliente_TagRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Tag> getCliente_Tag(Expression<Func<Cliente_Tag, bool>> predicate)
        {
            try
            {
                return _Cliente_TagRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarCliente_Tag(Cliente_Tag Cliente_Tag)
        {
            try
            {
                Cliente_Tag.inclusao = DateTime.Now;
                _Cliente_TagRepositorio.Adicionar(Cliente_Tag);
                _Cliente_TagRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Cliente_Tag Localizar(long? id)
        {
            try
            {
                return _Cliente_TagRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCliente_Tag(Cliente_Tag Cliente_Tag)
        {
            try
            {
                _Cliente_TagRepositorio.Deletar(c => c == Cliente_Tag);
                _Cliente_TagRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCliente_Tag(Cliente_Tag Cliente_Tag)
        {
            try
            {
                Cliente_Tag.alteracao = DateTime.Now;
                _Cliente_TagRepositorio.Atualizar(Cliente_Tag);
                _Cliente_TagRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Cliente_TagRepositorio != null)
            {
                _Cliente_TagRepositorio.Dispose();
            }

        }
    }
}
