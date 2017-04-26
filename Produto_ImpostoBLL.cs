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
    public class Produto_ImpostoBLL : BaseBLL, IDisposable
    {
        IProduto_ImpostoRepositorio _Produto_ImpostoRepositorio;
        public Produto_ImpostoBLL()
        {
            try
            {
                _Produto_ImpostoRepositorio = new Produto_ImpostoRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto_Imposto> getProduto_Imposto(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Produto_ImpostoRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Produto_ImpostoRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto_Imposto> getProduto_Imposto(Expression<Func<Produto_Imposto, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Produto_ImpostoRepositorio.getTotalRegistros();
                return _Produto_ImpostoRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto_Imposto> getProduto_Imposto(Expression<Func<Produto_Imposto, bool>> predicate, Expression<Func<Produto_Imposto, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Produto_ImpostoRepositorio.getTotalRegistros(predicate);
                return _Produto_ImpostoRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto_Imposto> getProduto_Imposto(Expression<Func<Produto_Imposto, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Produto_Imposto, string>>[] ordem)
        {
            try
            {
                totalRecords = _Produto_ImpostoRepositorio.getTotalRegistros(predicate);
                return _Produto_ImpostoRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto_Imposto> getProduto_Imposto(Expression<Func<Produto_Imposto, bool>> predicate, bool desc, params Expression<Func<Produto_Imposto, string>>[] ordem)
        {
            try
            {        
                return _Produto_ImpostoRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Produto_Imposto> getProduto_Imposto(Expression<Func<Produto_Imposto, bool>> predicate)
        {
            try
            {
                return _Produto_ImpostoRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarProduto_Imposto(Produto_Imposto Produto_Imposto)
        {
            try
            {
                _Produto_ImpostoRepositorio.Adicionar(Produto_Imposto);
                _Produto_ImpostoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Produto_Imposto Localizar(long? id)
        {
            try
            {
                return _Produto_ImpostoRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirProduto_Imposto(Produto_Imposto Produto_Imposto)
        {
            try
            {
                _Produto_ImpostoRepositorio.Deletar(c => c == Produto_Imposto);
                _Produto_ImpostoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarProduto_Imposto(Produto_Imposto Produto_Imposto)
        {
            try
            {
                _Produto_ImpostoRepositorio.Atualizar(Produto_Imposto);
                _Produto_ImpostoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Produto_ImpostoRepositorio != null)
            {
                _Produto_ImpostoRepositorio.Dispose();
            }

        }
    }
}
