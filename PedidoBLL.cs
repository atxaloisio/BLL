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

        public virtual List<Pedido> getPedido(Expression<Func<Pedido, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Pedido, string>>[] ordem)
        {
            try
            {
                totalRecords = _PedidoRepositorio.getTotalRegistros(predicate);
                return _PedidoRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido> getPedido(Expression<Func<Pedido, bool>> predicate, bool desc, params Expression<Func<Pedido, string>>[] ordem)
        {
            try
            {        
                return _PedidoRepositorio.Get(predicate, desc, ordem).ToList();
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

        /// <summary>
        /// Retorna uma coleção de parcelas conforme a codição de pagamento "parcela" selecionada no pedido.
        /// </summary>
        /// <param name="condicao_pagamento"></param>
        /// <param name="totalValor"></param>
        /// <param name="dtEmissao"></param>
        /// <returns>ICollection<Pedido_Parcelas></returns>
        public ICollection<Pedido_Parcelas> GerarParcelas(long? condicao_pagamento, decimal? totalValor, DateTime dtEmissao)
        {
            const int percentual = 100;
            ParcelaBLL parcelaBLL = new ParcelaBLL();
            Parcela parcela = parcelaBLL.Localizar(condicao_pagamento);

            ICollection<Pedido_Parcelas> Pedido_ParcelasList = new List<Pedido_Parcelas>();

            //Vamos tratar pelo codigo.

            if ((parcela.codigo.Contains("A")) || (parcela.codigo.Contains("B")))
            {
                //A ou B usamos o delimitador espaço
                //Aqui vamos gerar uma parcela com vencimento especificado pelo numero de dias.
                //para isso temos que quebrar a string do campo descrição e pegar o registro da 2ª posição do array.
                char[] delimiterChars = { ' ' };
                
                string[] words = parcela.descricao.Split(delimiterChars);

                if (words.Length > 1)
                {
                    int nrDias = Convert.ToInt16(words[1]);
                    Pedido_Parcelas parc = new Pedido_Parcelas();
                    DateTime dtVenc = dtEmissao.AddDays(nrDias);
                    parc.data_vencimento = dtVenc.ToShortDateString();
                    parc.numero_parcela = 0;
                    parc.percentual = percentual;
                    parc.quantidade_dias = nrDias;
                    parc.valor = totalValor;

                    Pedido_ParcelasList.Add(parc);
                }                
            }
            else if ((parcela.codigo.Contains("S"))|| 
                    (parcela.codigo.Contains("T"))|| 
                    (parcela.codigo.Contains("U")))
            {
                //S,T ou U usamos o delimitatador "/"
                char[] delimiterChars = { '/' };

                string[] words = parcela.descricao.Split(delimiterChars);

                int nrParcelas = 1;
                if (parcela.parcelas != null)
                {
                    nrParcelas = Convert.ToInt32(parcela.parcelas);
                }

                if (words.Length > 1)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        Pedido_Parcelas parc = new Pedido_Parcelas();
                        if (words[i] == "A Vista")
                        {                            
                            parc.data_vencimento = dtEmissao.ToShortDateString();                                                        
                            parc.quantidade_dias = 0;                            
                        }
                        else
                        {
                            int nrDias = Convert.ToInt16(words[i]);
                            DateTime dtVenc = dtEmissao.AddDays(nrDias);
                            parc.data_vencimento = dtVenc.ToShortDateString();
                            parc.numero_parcela = i+1;                            
                            parc.quantidade_dias = nrDias;                            
                        }

                        parc.numero_parcela = i + 1;
                        parc.percentual = percentual / nrParcelas;                       
                        parc.valor = totalValor / nrParcelas;


                        Pedido_ParcelasList.Add(parc);
                    }                                                                                
                }
            }
            else if (StringExtensions.IsNumeric(parcela.codigo))
            {
                //codigos numericos iniciados com 0 ou 999
                //Aqui vamos gerar sempre uma parcela para o dia informado na venda e as subsequentes se houver.
                //vamos usar a propriedade parcelas.

                switch (parcela.codigo)
                {
                    case "000":
                    case "999":
                        {
                            //Geramos uma parcela a vista.
                            Pedido_Parcelas parc = new Pedido_Parcelas();
                            parc.data_vencimento = dtEmissao.ToShortDateString();
                            parc.numero_parcela = 0;
                            parc.percentual = percentual;
                            parc.quantidade_dias = 0;
                            parc.valor = totalValor;

                            Pedido_ParcelasList.Add(parc);
                        }
                        break;    
                    default:
                        {
                            //Geramos conforme o numero de parcelas informado.
                            int nrParcelas = 1;
                            if (parcela.parcelas != null)
                            {
                                nrParcelas = Convert.ToInt32(parcela.parcelas);
                            }

                            for (int i = 0; i < nrParcelas; i++)
                            {
                                Pedido_Parcelas parc = new Pedido_Parcelas();

                                DateTime dtVenc = dtEmissao.AddMonths(i+1);
                                TimeSpan nrDias = dtVenc - dtEmissao;
                                parc.data_vencimento = dtVenc.ToShortDateString();
                                parc.numero_parcela = i + 1;
                                parc.percentual = percentual / nrParcelas;
                                parc.valor = totalValor / nrParcelas;
                                parc.quantidade_dias = nrDias.Days;

                                Pedido_ParcelasList.Add(parc);
                            }
                        }
                        break;
                }
                
            }


            //Sempre vamos retornar mesmo que seja uma parcela a vista.
            return Pedido_ParcelasList;
        }
    }
}
