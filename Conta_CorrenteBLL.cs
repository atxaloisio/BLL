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
    public class Conta_CorrenteBLL : BaseBLL, IDisposable
    {
        IConta_CorrenteRepositorio _Conta_CorrenteRepositorio;
        public Conta_CorrenteBLL()
        {
            try
            {
                _Conta_CorrenteRepositorio = new Conta_CorrenteRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Conta_Corrente> getConta_Corrente(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Conta_CorrenteRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Conta_CorrenteRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Conta_Corrente> getConta_Corrente(Expression<Func<Conta_Corrente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Conta_CorrenteRepositorio.getTotalRegistros();
                return _Conta_CorrenteRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Conta_Corrente> getConta_Corrente(Expression<Func<Conta_Corrente, bool>> predicate, Expression<Func<Conta_Corrente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Conta_CorrenteRepositorio.getTotalRegistros(predicate);
                return _Conta_CorrenteRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Conta_Corrente> getConta_Corrente(Expression<Func<Conta_Corrente, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Conta_Corrente, string>>[] ordem)
        {
            try
            {
                totalRecords = _Conta_CorrenteRepositorio.getTotalRegistros(predicate);
                return _Conta_CorrenteRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Conta_Corrente> getConta_Corrente(Expression<Func<Conta_Corrente, bool>> predicate, bool desc, params Expression<Func<Conta_Corrente, string>>[] ordem)
        {
            try
            {                
                return _Conta_CorrenteRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Conta_Corrente> getConta_Corrente(Expression<Func<Conta_Corrente, bool>> predicate)
        {
            try
            {
                return _Conta_CorrenteRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarConta_Corrente(Conta_Corrente Conta_Corrente)
        {
            try
            {
                Conta_Corrente.inclusao = DateTime.Now;
                _Conta_CorrenteRepositorio.Adicionar(Conta_Corrente);
                _Conta_CorrenteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Conta_Corrente Localizar(long? id)
        {
            try
            {
                return _Conta_CorrenteRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirConta_Corrente(Conta_Corrente Conta_Corrente)
        {
            try
            {
                _Conta_CorrenteRepositorio.Deletar(c => c == Conta_Corrente);
                _Conta_CorrenteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarConta_Corrente(Conta_Corrente Conta_Corrente)
        {
            try
            {         
                _Conta_CorrenteRepositorio.Atualizar(Conta_Corrente);
                _Conta_CorrenteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Conta_CorrenteRepositorio != null)
            {
                _Conta_CorrenteRepositorio.Dispose();
            }

        }
    }
}
