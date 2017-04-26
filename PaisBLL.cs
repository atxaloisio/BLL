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
    public class PaisBLL : BaseBLL, IDisposable
    {
        IPaisRepositorio _PaisRepositorio;
        public PaisBLL()
        {
            try
            {
                _PaisRepositorio = new PaisRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pais> getPais(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _PaisRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _PaisRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pais> getPais(Expression<Func<Pais, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _PaisRepositorio.getTotalRegistros();
                return _PaisRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pais> getPais(Expression<Func<Pais, bool>> predicate, Expression<Func<Pais, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _PaisRepositorio.getTotalRegistros(predicate);
                return _PaisRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pais> getPais(Expression<Func<Pais, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Pais, string>>[] ordem)
        {
            try
            {
                totalRecords = _PaisRepositorio.getTotalRegistros(predicate);
                return _PaisRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pais> getPais(Expression<Func<Pais, bool>> predicate, bool desc,params Expression<Func<Pais, string>>[] ordem)
        {
            try
            {
                
                return _PaisRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pais> getPais(Expression<Func<Pais, bool>> predicate)
        {
            try
            {

                return _PaisRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarPais(Pais Pais)
        {
            try
            {                
                _PaisRepositorio.Adicionar(Pais);
                _PaisRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Pais Localizar(long? id)
        {
            try
            {
                return _PaisRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirPais(Pais Pais)
        {
            try
            {
                _PaisRepositorio.Deletar(c => c == Pais);
                _PaisRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarPais(Pais Pais)
        {
            try
            {                
                _PaisRepositorio.Atualizar(Pais);
                _PaisRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_PaisRepositorio != null)
            {
                _PaisRepositorio.Dispose();
            }

        }
    }
}
