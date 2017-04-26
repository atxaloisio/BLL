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
    public class ParcelaBLL : BaseBLL, IDisposable
    {
        IParcelaRepositorio _ParcelaRepositorio;
        public ParcelaBLL()
        {
            try
            {
                _ParcelaRepositorio = new ParcelaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Parcela> getParcela(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _ParcelaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _ParcelaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Parcela> getParcela(Expression<Func<Parcela, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ParcelaRepositorio.getTotalRegistros();
                return _ParcelaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Parcela> getParcela(Expression<Func<Parcela, bool>> predicate, Expression<Func<Parcela, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ParcelaRepositorio.getTotalRegistros(predicate);
                return _ParcelaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Parcela> getParcela(Expression<Func<Parcela, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Parcela, string>>[] ordem)
        {
            try
            {
                totalRecords = _ParcelaRepositorio.getTotalRegistros(predicate);
                return _ParcelaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Parcela> getParcela(Expression<Func<Parcela, bool>> predicate, bool desc, params Expression<Func<Parcela, string>>[] ordem)
        {
            try
            {                
                return _ParcelaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public virtual List<Parcela> getParcela(Expression<Func<Parcela, bool>> predicate)
        {
            try
            {
                return _ParcelaRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarParcela(Parcela Parcela)
        {
            try
            {
                Parcela.inclusao = DateTime.Now;
                _ParcelaRepositorio.Adicionar(Parcela);
                _ParcelaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Parcela Localizar(long? id)
        {
            try
            {
                return _ParcelaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirParcela(Parcela Parcela)
        {
            try
            {
                _ParcelaRepositorio.Deletar(c => c == Parcela);
                _ParcelaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarParcela(Parcela Parcela)
        {
            try
            {
                Parcela.alteracao = DateTime.Now;
                _ParcelaRepositorio.Atualizar(Parcela);
                _ParcelaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_ParcelaRepositorio != null)
            {
                _ParcelaRepositorio.Dispose();
            }

        }
    }
}
