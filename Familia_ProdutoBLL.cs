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
    public class Familia_ProdutoBLL : BaseBLL, IDisposable
    {
        IFamilia_ProdutoRepositorio _Familia_ProdutoRepositorio;
        public Familia_ProdutoBLL()
        {
            try
            {
                _Familia_ProdutoRepositorio = new Familia_ProdutoRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Familia_Produto> getFamilia_Produto(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Familia_ProdutoRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Familia_ProdutoRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Familia_Produto> getFamilia_Produto(Expression<Func<Familia_Produto, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Familia_ProdutoRepositorio.getTotalRegistros();
                return _Familia_ProdutoRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Familia_Produto> getFamilia_Produto(Expression<Func<Familia_Produto, bool>> predicate, Expression<Func<Familia_Produto, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Familia_ProdutoRepositorio.getTotalRegistros(predicate);
                return _Familia_ProdutoRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Familia_Produto> getFamilia_Produto(Expression<Func<Familia_Produto, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Familia_Produto, string>>[] ordem)
        {
            try
            {
                totalRecords = _Familia_ProdutoRepositorio.getTotalRegistros(predicate);
                return _Familia_ProdutoRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Familia_Produto> getFamilia_Produto(Expression<Func<Familia_Produto, bool>> predicate, bool desc, params Expression<Func<Familia_Produto, string>>[] ordem)
        {
            try
            {

                return _Familia_ProdutoRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Familia_Produto> getFamilia_Produto(Expression<Func<Familia_Produto, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (NoTracking)
                {
                    return _Familia_ProdutoRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _Familia_ProdutoRepositorio.Get(predicate).ToList();
                }                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarFamilia_Produto(Familia_Produto Familia_Produto)
        {
            try
            {
                _Familia_ProdutoRepositorio.Adicionar(Familia_Produto);
                _Familia_ProdutoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Familia_Produto Localizar(long? id)
        {
            try
            {
                return _Familia_ProdutoRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirFamilia_Produto(Familia_Produto Familia_Produto)
        {
            try
            {
                _Familia_ProdutoRepositorio.Deletar(c => c == Familia_Produto);
                _Familia_ProdutoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarFamilia_Produto(Familia_Produto Familia_Produto)
        {
            try
            {
                _Familia_ProdutoRepositorio.Atualizar(Familia_Produto);
                _Familia_ProdutoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Familia_ProdutoRepositorio != null)
            {
                _Familia_ProdutoRepositorio.Dispose();
            }

        }
    }
}
