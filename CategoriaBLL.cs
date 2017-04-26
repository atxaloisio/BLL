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
    public class CategoriaBLL : BaseBLL, IDisposable
    {
        ICategoriaRepositorio _CategoriaRepositorio;
        public CategoriaBLL()
        {
            try
            {
                _CategoriaRepositorio = new CategoriaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Categoria> getCategoria(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _CategoriaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _CategoriaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Categoria> getCategoria(Expression<Func<Categoria, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _CategoriaRepositorio.getTotalRegistros();
                return _CategoriaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Categoria> getCategoria(Expression<Func<Categoria, bool>> predicate, Expression<Func<Categoria, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _CategoriaRepositorio.getTotalRegistros(predicate);
                return _CategoriaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Categoria> getCategoria(Expression<Func<Categoria, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Categoria, string>>[] ordem)
        {
            try
            {
                totalRecords = _CategoriaRepositorio.getTotalRegistros(predicate);
                return _CategoriaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Categoria> getCategoria(Expression<Func<Categoria, bool>> predicate, bool desc, params Expression<Func<Categoria, string>>[] ordem)
        {
            try
            {
         
                return _CategoriaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Categoria> getCategoria(Expression<Func<Categoria, bool>> predicate)
        {
            try
            {
                return _CategoriaRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarCategoria(Categoria Categoria)
        {
            try
            {                
                _CategoriaRepositorio.Adicionar(Categoria);
                _CategoriaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Categoria Localizar(long? id)
        {
            try
            {
                return _CategoriaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCategoria(Categoria Categoria)
        {
            try
            {
                _CategoriaRepositorio.Deletar(c => c == Categoria);
                _CategoriaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCategoria(Categoria Categoria)
        {
            try
            {                
                _CategoriaRepositorio.Atualizar(Categoria);
                _CategoriaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_CategoriaRepositorio != null)
            {
                _CategoriaRepositorio.Dispose();
            }

        }
    }
}
