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
    public class PedidoBLL : BaseBLL, IDisposable
    {
        IPedidoRepositorio _PedidoRepositorio;
        public PedidoBLL()
        {
            try
            {
                _PedidoRepositorio = new PedidoRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido> getPedido(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _PedidoRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _PedidoRepositorio.Get(p => p.id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido> getPedido(Expression<Func<Pedido, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _PedidoRepositorio.getTotalRegistros();
                return _PedidoRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido> getPedido(Expression<Func<Pedido, bool>> predicate, Expression<Func<Pedido, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _PedidoRepositorio.getTotalRegistros(predicate);
                return _PedidoRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarPedido(Pedido Pedido)
        {
            try
            {
                Pedido.inclusao = DateTime.Now;
                _PedidoRepositorio.Adicionar(Pedido);
                _PedidoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Pedido Localizar(long? id)
        {
            try
            {
                return _PedidoRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirPedido(Pedido Pedido)
        {
            try
            {
                _PedidoRepositorio.Deletar(c => c == Pedido);
                _PedidoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarPedido(Pedido Pedido)
        {
            try
            {
                Pedido.alteracao = DateTime.Now;
                _PedidoRepositorio.Atualizar(Pedido);
                _PedidoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_PedidoRepositorio != null)
            {
                _PedidoRepositorio.Dispose();
            }

        }
    }
}
