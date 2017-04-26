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
    public class VendedorBLL : BaseBLL, IDisposable
    {
        IVendedorRepositorio _VendedorRepositorio;
        public VendedorBLL()
        {
            try
            {
                _VendedorRepositorio = new VendedorRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor> getVendedor(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _VendedorRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _VendedorRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor> getVendedor(Expression<Func<Vendedor, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _VendedorRepositorio.getTotalRegistros();
                return _VendedorRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor> getVendedor(Expression<Func<Vendedor, bool>> predicate, Expression<Func<Vendedor, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _VendedorRepositorio.getTotalRegistros(predicate);
                return _VendedorRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor> getVendedor(Expression<Func<Vendedor, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Vendedor, string>>[] ordem)
        {
            try
            {
                totalRecords = _VendedorRepositorio.getTotalRegistros(predicate);
                return _VendedorRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor> getVendedor(Expression<Func<Vendedor, bool>> predicate, bool desc, params Expression<Func<Vendedor, string>>[] ordem)
        {
            try
            {
                
                return _VendedorRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor> getVendedor(Expression<Func<Vendedor, bool>> predicate)
        {
            try
            {
                return _VendedorRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<VendedorView> ToList_VendedorView(List<Vendedor> lst)
        {
            List<VendedorView> lstRetorno = new List<VendedorView>();

            foreach (Vendedor item in lst)
            {
                lstRetorno.Add(new VendedorView
                {
                    Id = item.Id,
                    nome = item.nome,
                    inativo = item.inativo == "S"
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarVendedor(Vendedor Vendedor)
        {
            try
            {
                _VendedorRepositorio.Adicionar(Vendedor);
                _VendedorRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Vendedor Localizar(long? id)
        {
            try
            {
                return _VendedorRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirVendedor(Vendedor Vendedor)
        {
            try
            {
                _VendedorRepositorio.Deletar(c => c == Vendedor);
                _VendedorRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarVendedor(Vendedor Vendedor)
        {
            try
            {
                _VendedorRepositorio.Atualizar(Vendedor);
                _VendedorRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_VendedorRepositorio != null)
            {
                _VendedorRepositorio.Dispose();
            }

        }
    }
}
