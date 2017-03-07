using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using Utils;


namespace BLL
{
    public class Pedido_OticaBLL : IDisposable
    {
        IPedido_OticaRepositorio _Pedido_OticaRepositorio;
        public Pedido_OticaBLL()
        {
            try
            {
                _Pedido_OticaRepositorio = new Pedido_OticaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica> getPedido_Otica(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Pedido_OticaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Pedido_OticaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_OticaView> ToList_Pedido_OticaView(List<Pedido_Otica> lst)
        {
            List<Pedido_OticaView> lstRetorno = new List<Pedido_OticaView>();

            foreach (Pedido_Otica item in lst)
            {
                lstRetorno.Add(new Pedido_OticaView {
                    id = item.Id,
                    codigo = item.codigo,
                    cliente = item.cliente.nome_fantasia,
                    codicao_pagamento = item.formaspagvenda.cDescricao,
                    DtEmissao = item.data_emissao,
                    DtFechamento = item.data_fechamento,
                    Status = Enumerados.GetStringValue((StatusPedido)item.status)                    
                });
            }

            return lstRetorno;

        }

        public virtual List<Pedido_Otica> getPedido_Otica(Expression<Func<Pedido_Otica, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_OticaRepositorio.getTotalRegistros();
                return _Pedido_OticaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica> getPedido_Otica(Expression<Func<Pedido_Otica, bool>> predicate, Expression<Func<Pedido_Otica, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_OticaRepositorio.getTotalRegistros(predicate);
                return _Pedido_OticaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarPedido_Otica(Pedido_Otica Pedido_Otica)
        {
            try
            {
                Pedido_Otica.inclusao = DateTime.Now;
                Pedido_Otica.codigo = Utils.Sequence.GetNextVal("sq_pedido_otica_sequence");
                _Pedido_OticaRepositorio.Adicionar(Pedido_Otica);
                _Pedido_OticaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Pedido_Otica Localizar(long? id)
        {
            try
            {
                return _Pedido_OticaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirPedido_Otica(Pedido_Otica Pedido_Otica)
        {
            try
            {
                _Pedido_OticaRepositorio.Deletar(c => c == Pedido_Otica);
                _Pedido_OticaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarPedido_Otica(Pedido_Otica Pedido_Otica)
        {
            try
            {
                Pedido_Otica.alteracao = DateTime.Now;
                _Pedido_OticaRepositorio.Atualizar(Pedido_Otica);
                _Pedido_OticaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Pedido_OticaRepositorio != null)
            {
                _Pedido_OticaRepositorio.Dispose();
            }

        }
    }
}
