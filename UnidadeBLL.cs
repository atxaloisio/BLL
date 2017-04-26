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
    public class UnidadeBLL : BaseBLL, IDisposable
    {
        IUnidadeRepositorio _UnidadeRepositorio;
        public UnidadeBLL()
        {
            try
            {
                _UnidadeRepositorio = new UnidadeRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Unidade> getUnidade(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _UnidadeRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _UnidadeRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Unidade> getUnidade(string pUnidade)
        {
            try
            {
                return _UnidadeRepositorio.Get(p => p.codigo.Contains(pUnidade)).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Unidade> getUnidade(Expression<Func<Unidade, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _UnidadeRepositorio.getTotalRegistros();
                return _UnidadeRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Unidade> getUnidade(Expression<Func<Unidade, bool>> predicate, Expression<Func<Unidade, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _UnidadeRepositorio.getTotalRegistros(predicate);
                return _UnidadeRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Unidade> getUnidade(Expression<Func<Unidade, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Unidade, string>>[] ordem)
        {
            try
            {
                totalRecords = _UnidadeRepositorio.getTotalRegistros(predicate);
                return _UnidadeRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Unidade> getUnidade(Expression<Func<Unidade, bool>> predicate, bool desc, params Expression<Func<Unidade, string>>[] ordem)
        {
            try
            {
         
                return _UnidadeRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Unidade> getUnidade(Expression<Func<Unidade, bool>> predicate)
        {
            try
            {

                return _UnidadeRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarUnidade(Unidade Unidade)
        {
            try
            {                
                _UnidadeRepositorio.Adicionar(Unidade);
                _UnidadeRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Unidade Localizar(long? id)
        {
            try
            {
                return _UnidadeRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirUnidade(Unidade Unidade)
        {
            try
            {
                _UnidadeRepositorio.Deletar(c => c == Unidade);
                _UnidadeRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarUnidade(Unidade Unidade)
        {
            try
            {                
                _UnidadeRepositorio.Atualizar(Unidade);
                _UnidadeRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_UnidadeRepositorio != null)
            {
                _UnidadeRepositorio.Dispose();
            }

        }
    }
}
