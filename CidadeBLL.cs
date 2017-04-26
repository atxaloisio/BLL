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
    public class CidadeBLL : BaseBLL, IDisposable
    {
        ICidadeRepositorio _CidadeRepositorio;
        public CidadeBLL()
        {
            try
            {
                _CidadeRepositorio = new CidadeRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cidade> getCidade(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _CidadeRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _CidadeRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cidade> getCidade(Expression<Func<Cidade, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _CidadeRepositorio.getTotalRegistros();
                return _CidadeRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cidade> getCidade(Expression<Func<Cidade, bool>> predicate, Expression<Func<Cidade, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _CidadeRepositorio.getTotalRegistros(predicate);
                return _CidadeRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cidade> getCidade(Expression<Func<Cidade, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Cidade, string>>[] ordem)
        {
            try
            {
                totalRecords = _CidadeRepositorio.getTotalRegistros(predicate);
                return _CidadeRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cidade> getCidade(Expression<Func<Cidade, bool>> predicate, bool desc, params Expression<Func<Cidade, string>>[] ordem)
        {
            try
            {
         
                return _CidadeRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cidade> getCidade(Expression<Func<Cidade, bool>> predicate)
        {
            try
            {
                return _CidadeRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarCidade(Cidade Cidade)
        {
            try
            {                
                _CidadeRepositorio.Adicionar(Cidade);
                _CidadeRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Cidade Localizar(long? id)
        {
            try
            {
                return _CidadeRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCidade(Cidade Cidade)
        {
            try
            {
                _CidadeRepositorio.Deletar(c => c == Cidade);
                _CidadeRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCidade(Cidade Cidade)
        {
            try
            {                
                _CidadeRepositorio.Atualizar(Cidade);
                _CidadeRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_CidadeRepositorio != null)
            {
                _CidadeRepositorio.Dispose();
            }

        }
    }
}
