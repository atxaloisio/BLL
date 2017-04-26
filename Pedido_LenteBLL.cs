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
    public class Pedido_LenteBLL : BaseBLL, IDisposable
    {
        IPedido_LenteRepositorio _Pedido_LenteRepositorio;
        public Pedido_LenteBLL()
        {
            try
            {
                _Pedido_LenteRepositorio = new Pedido_LenteRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Lente> getPedido_Lente(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Pedido_LenteRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Pedido_LenteRepositorio.GetNT(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Lente> getPedido_Lente(Expression<Func<Pedido_Lente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_LenteRepositorio.getTotalRegistros();
                return _Pedido_LenteRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Lente> getPedido_Lente(Expression<Func<Pedido_Lente, bool>> predicate, Expression<Func<Pedido_Lente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_LenteRepositorio.getTotalRegistros(predicate);
                return _Pedido_LenteRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Lente> getPedido_Lente(Expression<Func<Pedido_Lente, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Pedido_Lente, string>>[] ordem)
        {
            try
            {
                totalRecords = _Pedido_LenteRepositorio.getTotalRegistros(predicate);
                return _Pedido_LenteRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Lente> getPedido_Lente(Expression<Func<Pedido_Lente, bool>> predicate, bool desc, params Expression<Func<Pedido_Lente, string>>[] ordem)
        {
            try
            {        
                return _Pedido_LenteRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Lente> getPedido_Lente(Expression<Func<Pedido_Lente, bool>> predicate)
        {
            try
            {
                return _Pedido_LenteRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarPedido_Lente(Pedido_Lente Pedido_Lente)
        {
            try
            {
                _Pedido_LenteRepositorio.Adicionar(Pedido_Lente);
                _Pedido_LenteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Pedido_Lente Localizar(long? id)
        {
            try
            {
                return _Pedido_LenteRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirPedido_Lente(Pedido_Lente Pedido_Lente)
        {
            try
            {
                _Pedido_LenteRepositorio.Deletar(c => c == Pedido_Lente);
                _Pedido_LenteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarPedido_Lente(Pedido_Lente Pedido_Lente)
        {
            try
            {
                _Pedido_LenteRepositorio.Atualizar(Pedido_Lente);
                _Pedido_LenteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Pedido_LenteRepositorio != null)
            {
                _Pedido_LenteRepositorio.Dispose();
            }

        }
    }
}
