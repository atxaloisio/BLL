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
    public class FuncaoBLL : BaseBLL, IDisposable
    {
        IFuncaoRepositorio _FuncaoRepositorio;
        public FuncaoBLL()
        {
            try
            {
                _FuncaoRepositorio = new FuncaoRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao> getFuncao(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _FuncaoRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _FuncaoRepositorio.Get(p => p.codigo == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao> getFuncao(Expression<Func<Funcao, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _FuncaoRepositorio.getTotalRegistros();
                return _FuncaoRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao> getFuncao(Expression<Func<Funcao, bool>> predicate, Expression<Func<Funcao, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _FuncaoRepositorio.getTotalRegistros(predicate);
                return _FuncaoRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao> getFuncao(Expression<Func<Funcao, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Funcao, string>>[] ordem)
        {
            try
            {
                totalRecords = _FuncaoRepositorio.getTotalRegistros(predicate);
                return _FuncaoRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao> getFuncao(Expression<Func<Funcao, bool>> predicate, bool desc, Expression<Func<Funcao, string>>[] ordem)
        {
            try
            {        
                return _FuncaoRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao> getFuncao(Expression<Func<Funcao, bool>> predicate)
        {
            try
            {
        
                return _FuncaoRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarFuncao(Funcao Funcao)
        {
            try
            {
                _FuncaoRepositorio.Adicionar(Funcao);
                _FuncaoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Funcao Localizar(long? id)
        {
            try
            {
                return _FuncaoRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirFuncao(Funcao Funcao)
        {
            try
            {
                _FuncaoRepositorio.Deletar(c => c == Funcao);
                _FuncaoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarFuncao(Funcao Funcao)
        {
            try
            {
                _FuncaoRepositorio.Atualizar(Funcao);
                _FuncaoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_FuncaoRepositorio != null)
            {
                _FuncaoRepositorio.Dispose();
            }

        }
    }
}
