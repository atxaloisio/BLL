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
    public class ClienteBLL : BaseBLL, IDisposable
    {
        IClienteRepositorio _ClienteRepositorio;
        public ClienteBLL()
        {
            try
            {
                _ClienteRepositorio = new ClienteRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _ClienteRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _ClienteRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(Expression<Func<Cliente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ClienteRepositorio.getTotalRegistros();
                return _ClienteRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(Expression<Func<Cliente, bool>> predicate, Expression<Func<Cliente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ClienteRepositorio.getTotalRegistros(predicate);
                return _ClienteRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(Expression<Func<Cliente, bool>> predicate)
        {
            try
            {                
                return _ClienteRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarCliente(Cliente Cliente)
        {
            try
            {
                Cliente.inclusao = DateTime.Now;
                _ClienteRepositorio.Adicionar(Cliente);
                _ClienteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Cliente Localizar(long? id)
        {
            try
            {
                return _ClienteRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCliente(Cliente Cliente)
        {
            try
            {
                _ClienteRepositorio.Deletar(c => c == Cliente);
                _ClienteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCliente(Cliente Cliente)
        {
            try
            {
                Cliente.alteracao = DateTime.Now;
                _ClienteRepositorio.Atualizar(Cliente);
                _ClienteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_ClienteRepositorio != null)
            {
                _ClienteRepositorio.Dispose();
            }

        }
    }
}
