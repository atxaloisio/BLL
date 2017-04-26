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
    public class CaixaBLL : BaseBLL, IDisposable
    {
        ICaixaRepositorio _CaixaRepositorio;
        public CaixaBLL()
        {
            try
            {
                _CaixaRepositorio = new CaixaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Caixa> getCaixa(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _CaixaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _CaixaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Caixa> getCaixa(Expression<Func<Caixa, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _CaixaRepositorio.getTotalRegistros();
                return _CaixaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Caixa> getCaixa(Expression<Func<Caixa, bool>> predicate, Expression<Func<Caixa, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _CaixaRepositorio.getTotalRegistros(predicate);
                return _CaixaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Caixa> getCaixa(Expression<Func<Caixa, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Caixa, string>>[] ordem)
        {
            try
            {
                totalRecords = _CaixaRepositorio.getTotalRegistros(predicate);
                return _CaixaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Caixa> getCaixa(Expression<Func<Caixa, bool>> predicate, bool desc, params Expression<Func<Caixa, string>>[] ordem)
        {
            try
            {        
                return _CaixaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Caixa> getCaixa(Expression<Func<Caixa, bool>> predicate)
        {
            try
            {
                return _CaixaRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Caixa> getCaixaJoin(StatusPedido status)
        {
            try
            {
                return _CaixaRepositorio.GetCaixaJoin(status).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<CaixaView> ToList_CaixaView(List<Caixa> lst)
        {
            List<CaixaView> lstRetorno = new List<CaixaView>();

            foreach (Caixa item in lst)
            {
                lstRetorno.Add(new CaixaView
                {
                    Id = item.Id,
                    numero =  item.numero,
                    inativo = item.inativo == "S"
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarCaixa(Caixa Caixa)
        {
            try
            {
                _CaixaRepositorio.Adicionar(Caixa);
                _CaixaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Caixa Localizar(long? id)
        {
            try
            {
                return _CaixaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCaixa(Caixa Caixa)
        {
            try
            {
                _CaixaRepositorio.Deletar(c => c == Caixa);
                _CaixaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCaixa(Caixa Caixa)
        {
            try
            {
                _CaixaRepositorio.Atualizar(Caixa);
                _CaixaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_CaixaRepositorio != null)
            {
                _CaixaRepositorio.Dispose();
            }

        }
    }
}
