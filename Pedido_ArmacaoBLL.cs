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
    public class Pedido_ArmacaoBLL : BaseBLL, IDisposable
    {
        IPedido_ArmacaoRepositorio _Pedido_ArmacaoRepositorio;
        public Pedido_ArmacaoBLL()
        {
            try
            {
                _Pedido_ArmacaoRepositorio = new Pedido_ArmacaoRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Armacao> getPedido_Armacao(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Pedido_ArmacaoRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Pedido_ArmacaoRepositorio.GetNT(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Armacao> getPedido_Armacao(Expression<Func<Pedido_Armacao, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_ArmacaoRepositorio.getTotalRegistros();
                return _Pedido_ArmacaoRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Armacao> getPedido_Armacao(Expression<Func<Pedido_Armacao, bool>> predicate, Expression<Func<Pedido_Armacao, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_ArmacaoRepositorio.getTotalRegistros(predicate);
                return _Pedido_ArmacaoRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Armacao> getPedido_Armacao(Expression<Func<Pedido_Armacao, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Pedido_Armacao, string>>[] ordem)
        {
            try
            {
                totalRecords = _Pedido_ArmacaoRepositorio.getTotalRegistros(predicate);
                return _Pedido_ArmacaoRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Armacao> getPedido_Armacao(Expression<Func<Pedido_Armacao, bool>> predicate, bool desc, params Expression<Func<Pedido_Armacao, string>>[] ordem)
        {
            try
            {         
                return _Pedido_ArmacaoRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Armacao> getPedido_Armacao(Expression<Func<Pedido_Armacao, bool>> predicate)
        {
            try
            {
                return _Pedido_ArmacaoRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarPedido_Armacao(Pedido_Armacao Pedido_Armacao)
        {
            try
            {
                _Pedido_ArmacaoRepositorio.Adicionar(Pedido_Armacao);
                _Pedido_ArmacaoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Pedido_Armacao Localizar(long? id)
        {
            try
            {
                return _Pedido_ArmacaoRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirPedido_Armacao(Pedido_Armacao Pedido_Armacao)
        {
            try
            {
                _Pedido_ArmacaoRepositorio.Deletar(c => c == Pedido_Armacao);
                _Pedido_ArmacaoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarPedido_Armacao(Pedido_Armacao Pedido_Armacao)
        {
            try
            {
                _Pedido_ArmacaoRepositorio.Atualizar(Pedido_Armacao);
                _Pedido_ArmacaoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Pedido_ArmacaoRepositorio != null)
            {
                _Pedido_ArmacaoRepositorio.Dispose();
            }

        }
    }
}
