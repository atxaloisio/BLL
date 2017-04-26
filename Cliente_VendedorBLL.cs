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
    public class Cliente_VendedorBLL : BaseBLL, IDisposable
    {
        ICliente_VendedorRepositorio _Cliente_VendedorRepositorio;
        public Cliente_VendedorBLL()
        {
            try
            {
                _Cliente_VendedorRepositorio = new Cliente_VendedorRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Vendedor> getCliente_Vendedor(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Cliente_VendedorRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Cliente_VendedorRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Vendedor> getCliente_Vendedor(Expression<Func<Cliente_Vendedor, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Cliente_VendedorRepositorio.getTotalRegistros();
                return _Cliente_VendedorRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Vendedor> getCliente_Vendedor(Expression<Func<Cliente_Vendedor, bool>> predicate, Expression<Func<Cliente_Vendedor, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Cliente_VendedorRepositorio.getTotalRegistros(predicate);
                return _Cliente_VendedorRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Vendedor> getCliente_Vendedor(Expression<Func<Cliente_Vendedor, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Cliente_Vendedor, string>>[] ordem)
        {
            try
            {
                totalRecords = _Cliente_VendedorRepositorio.getTotalRegistros(predicate);
                return _Cliente_VendedorRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Vendedor> getCliente_Vendedor(Expression<Func<Cliente_Vendedor, bool>> predicate, bool desc, params Expression<Func<Cliente_Vendedor, string>>[] ordem)
        {
            try
            {                
                return _Cliente_VendedorRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Vendedor> getCliente_Vendedor(Expression<Func<Cliente_Vendedor, bool>> predicate)
        {
            try
            {
                return _Cliente_VendedorRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_VendedorView> ToList_Cliente_VendedorView(List<Cliente_Vendedor> lst)
        {
            List<Cliente_VendedorView> lstRetorno = new List<Cliente_VendedorView>();

            foreach (Cliente_Vendedor item in lst)
            {
                lstRetorno.Add(new Cliente_VendedorView()
                {
                    id = item.Id,
                    cliente = item.cliente.nome_fantasia,
                    vendedor = item.vendedor.nome
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarCliente_Vendedor(Cliente_Vendedor Cliente_Vendedor)
        {
            try
            {

                _Cliente_VendedorRepositorio.Adicionar(Cliente_Vendedor);
                _Cliente_VendedorRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Cliente_Vendedor Localizar(long? id)
        {
            try
            {
                return _Cliente_VendedorRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCliente_Vendedor(Cliente_Vendedor Cliente_Vendedor)
        {
            try
            {
                _Cliente_VendedorRepositorio.Deletar(c => c == Cliente_Vendedor);
                _Cliente_VendedorRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCliente_Vendedor(Cliente_Vendedor Cliente_Vendedor)
        {
            try
            {

                _Cliente_VendedorRepositorio.Atualizar(Cliente_Vendedor);
                _Cliente_VendedorRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Cliente_VendedorRepositorio != null)
            {
                _Cliente_VendedorRepositorio.Dispose();
            }

        }
    }
}
