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
    public class ProdutoBLL : BaseBLL, IDisposable
    {
        IProdutoRepositorio _ProdutoRepositorio;
        public ProdutoBLL()
        {
            try
            {
                _ProdutoRepositorio = new ProdutoRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto> getProduto(long Id = -1 , bool NoTracking = false)
        {
            try
            {
                if (Id == -1)
                {
                    return _ProdutoRepositorio.GetTodos().ToList();
                }
                else
                {
                    if (NoTracking)
                    {
                        return _ProdutoRepositorio.GetNT(p => p.id == Id).ToList();
                    }
                    else
                    {
                        return _ProdutoRepositorio.Get(p => p.id == Id).ToList();
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto> getProduto(Expression<Func<Produto, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ProdutoRepositorio.getTotalRegistros();
                return _ProdutoRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto> getProduto(Expression<Func<Produto, bool>> predicate, Expression<Func<Produto, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ProdutoRepositorio.getTotalRegistros(predicate);
                return _ProdutoRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto> getProduto(Expression<Func<Produto, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Produto, string>>[] ordem)
        {
            try
            {
                totalRecords = _ProdutoRepositorio.getTotalRegistros(predicate);
                return _ProdutoRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto> getProduto(Expression<Func<Produto, bool>> predicate, bool desc, params Expression<Func<Produto, string>>[] ordem)
        {
            try
            {        
                return _ProdutoRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto> getProduto(Expression<Func<Produto, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (NoTracking)
                {
                    return _ProdutoRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _ProdutoRepositorio.Get(predicate).ToList();
                }
                    
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<ProdutoView> ToList_ProdutoView(List<Produto> lst)
        {
            List<ProdutoView> lstRetorno = new List<ProdutoView>();

            foreach (Produto item in lst)
            {
                lstRetorno.Add(new ProdutoView
                {
                    Id = item.id,
                    codigo =  item.codigo,
                    descricao = item.descricao,
                    familia = item.descricao_familia,
                    ncm = item.ncm,
                    unidade = item.unidade,
                    valor_unitario = item.valor_unitario
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarProduto(Produto Produto)
        {
            try
            {
                Produto.inclusao = DateTime.Now;
                _ProdutoRepositorio.Adicionar(Produto);
                _ProdutoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Produto Localizar(long? id)
        {
            try
            {
                return _ProdutoRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirProduto(Produto Produto)
        {
            try
            {
                _ProdutoRepositorio.Deletar(c => c == Produto);
                _ProdutoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarProduto(Produto Produto)
        {
            try
            {
                Produto.alteracao = DateTime.Now;
                _ProdutoRepositorio.Atualizar(Produto);
                _ProdutoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_ProdutoRepositorio != null)
            {
                _ProdutoRepositorio.Dispose();
            }

        }
    }
}
