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
    public class Pedido_Otica_InfoAdicBLL : BaseBLL, IDisposable
    {
        IPedido_Otica_InfoAdicRepositorio _Pedido_Otica_InfoAdicRepositorio;
        public Pedido_Otica_InfoAdicBLL()
        {
            try
            {
                _Pedido_Otica_InfoAdicRepositorio = new Pedido_Otica_InfoAdicRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_InfoAdic> getPedido_Otica_InfoAdic(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Pedido_Otica_InfoAdicRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Pedido_Otica_InfoAdicRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_InfoAdic> getPedido_Otica_InfoAdic(Expression<Func<Pedido_Otica_InfoAdic, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_Otica_InfoAdicRepositorio.getTotalRegistros();
                return _Pedido_Otica_InfoAdicRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_InfoAdic> getPedido_Otica_InfoAdic(Expression<Func<Pedido_Otica_InfoAdic, bool>> predicate, Expression<Func<Pedido_Otica_InfoAdic, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_Otica_InfoAdicRepositorio.getTotalRegistros(predicate);
                return _Pedido_Otica_InfoAdicRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_InfoAdic> getPedido_Otica_InfoAdic(Expression<Func<Pedido_Otica_InfoAdic, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Pedido_Otica_InfoAdic, string>>[] ordem)
        {
            try
            {
                totalRecords = _Pedido_Otica_InfoAdicRepositorio.getTotalRegistros(predicate);
                return _Pedido_Otica_InfoAdicRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_InfoAdic> getPedido_Otica_InfoAdic(Expression<Func<Pedido_Otica_InfoAdic, bool>> predicate, bool desc, params Expression<Func<Pedido_Otica_InfoAdic, string>>[] ordem)
        {
            try
            {

                return _Pedido_Otica_InfoAdicRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_InfoAdic> getPedido_Otica_InfoAdic(Expression<Func<Pedido_Otica_InfoAdic, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (NoTracking)
                {
                    return _Pedido_Otica_InfoAdicRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _Pedido_Otica_InfoAdicRepositorio.Get(predicate).ToList();
                }                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarPedido_Otica_InfoAdic(Pedido_Otica_InfoAdic Pedido_Otica_InfoAdic)
        {
            try
            {
                _Pedido_Otica_InfoAdicRepositorio.Adicionar(Pedido_Otica_InfoAdic);
                _Pedido_Otica_InfoAdicRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Pedido_Otica_InfoAdic Localizar(long? id)
        {
            try
            {
                return _Pedido_Otica_InfoAdicRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirPedido_Otica_InfoAdic(Pedido_Otica_InfoAdic Pedido_Otica_InfoAdic)
        {
            try
            {
                _Pedido_Otica_InfoAdicRepositorio.Deletar(c => c == Pedido_Otica_InfoAdic);
                _Pedido_Otica_InfoAdicRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarPedido_Otica_InfoAdic(Pedido_Otica_InfoAdic Pedido_Otica_InfoAdic)
        {
            try
            {
                _Pedido_Otica_InfoAdicRepositorio.Atualizar(Pedido_Otica_InfoAdic);
                _Pedido_Otica_InfoAdicRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Pedido_Otica_InfoAdicRepositorio != null)
            {
                _Pedido_Otica_InfoAdicRepositorio.Dispose();
            }

        }
    }
}
