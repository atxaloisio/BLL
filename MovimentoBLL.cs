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
    public class MovimentoBLL : BaseBLL, IDisposable
    {
        IMovimentoRepositorio _MovimentoRepositorio;
        public MovimentoBLL()
        {
            try
            {
                _MovimentoRepositorio = new MovimentoRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Movimento> getMovimento(long? Id = -1, bool NoTracking = false)
        {
            try
            {
                if (Id == -1)
                {
                    return _MovimentoRepositorio.GetTodos().ToList();
                }
                else
                {
                    if (NoTracking)
                    {
                        return _MovimentoRepositorio.GetNT(p => p.Id == Id).ToList();
                    }
                    else
                    {
                        return _MovimentoRepositorio.Get(p => p.Id == Id).ToList();
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Movimento> getMovimento(Expression<Func<Movimento, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _MovimentoRepositorio.getTotalRegistros();
                return _MovimentoRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Movimento> getMovimento(Expression<Func<Movimento, bool>> predicate, Expression<Func<Movimento, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _MovimentoRepositorio.getTotalRegistros(predicate);
                return _MovimentoRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Movimento> getMovimento(Expression<Func<Movimento, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Movimento, string>>[] ordem)
        {
            try
            {
                totalRecords = _MovimentoRepositorio.getTotalRegistros(predicate);
                return _MovimentoRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Movimento> getMovimento(Expression<Func<Movimento, bool>> predicate, bool desc, params Expression<Func<Movimento, string>>[] ordem)
        {
            try
            {

                return _MovimentoRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Movimento> getMovimento(Expression<Func<Movimento, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (NoTracking)
                {
                    return _MovimentoRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _MovimentoRepositorio.Get(predicate).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        

        public virtual void AdicionarMovimento(Movimento Movimento)
        {
            try
            {                
                _MovimentoRepositorio.Adicionar(Movimento);
                _MovimentoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Movimento Localizar(long? id)
        {
            try
            {
                return _MovimentoRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirMovimento(Movimento Movimento)
        {
            try
            {
                _MovimentoRepositorio.Deletar(c => c == Movimento);
                _MovimentoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarMovimento(Movimento Movimento)
        {
            try
            {                
                _MovimentoRepositorio.Atualizar(Movimento);
                _MovimentoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_MovimentoRepositorio != null)
            {
                _MovimentoRepositorio.Dispose();
            }

        }
    }
}
