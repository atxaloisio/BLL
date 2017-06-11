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
    public class Pedido_Otica_ParcelasBLL : BaseBLL, IDisposable
    {
        IPedido_Otica_ParcelasRepositorio _Pedido_Otica_ParcelasRepositorio;
        public Pedido_Otica_ParcelasBLL()
        {
            try
            {
                _Pedido_Otica_ParcelasRepositorio = new Pedido_Otica_ParcelasRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_Parcelas> getPedido_Otica_Parcelas(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Pedido_Otica_ParcelasRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Pedido_Otica_ParcelasRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_Parcelas> getPedido_Otica_Parcelas(Expression<Func<Pedido_Otica_Parcelas, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_Otica_ParcelasRepositorio.getTotalRegistros();
                return _Pedido_Otica_ParcelasRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_Parcelas> getPedido_Otica_Parcelas(Expression<Func<Pedido_Otica_Parcelas, bool>> predicate, Expression<Func<Pedido_Otica_Parcelas, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Pedido_Otica_ParcelasRepositorio.getTotalRegistros(predicate);
                return _Pedido_Otica_ParcelasRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_Parcelas> getPedido_Otica_Parcelas(Expression<Func<Pedido_Otica_Parcelas, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Pedido_Otica_Parcelas, string>>[] ordem)
        {
            try
            {
                totalRecords = _Pedido_Otica_ParcelasRepositorio.getTotalRegistros(predicate);
                return _Pedido_Otica_ParcelasRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_Parcelas> getPedido_Otica_Parcelas(Expression<Func<Pedido_Otica_Parcelas, bool>> predicate, bool desc, params Expression<Func<Pedido_Otica_Parcelas, string>>[] ordem)
        {
            try
            {

                return _Pedido_Otica_ParcelasRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica_Parcelas> getPedido_Otica_Parcelas(Expression<Func<Pedido_Otica_Parcelas, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (NoTracking)
                {
                    return _Pedido_Otica_ParcelasRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _Pedido_Otica_ParcelasRepositorio.Get(predicate).ToList();
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<ParcelaView> ToList_Pedido_OticaParcelaView(ICollection<Pedido_Otica_Parcelas> lst)
        {
            List<ParcelaView> lstRetorno = new List<ParcelaView>();

            foreach (Pedido_Otica_Parcelas item in lst)
            {
                lstRetorno.Add(new ParcelaView
                {
                    Id = item.Id,
                    DtPagamento = item.data_pagamento,
                    DtVencimento = item.data_vencimento,
                    Id_Pedido_Otica = item.Id_pedido_otica,
                    NrParcela = item.numero_parcela,
                    Pago = item.pago == "S",
                    Percentual = item.percentual,
                    Valor = item.valor,
                    FormaPagamento = item.forma_pagamento,
                    Usuario = item.usuario_pagamento,
                    NrDias = item.quantidade_dias                    
                });
            }
             
            return lstRetorno;

        }

        public virtual void AdicionarPedido_Otica_Parcelas(Pedido_Otica_Parcelas Pedido_Otica_Parcelas)
        {
            try
            {
                _Pedido_Otica_ParcelasRepositorio.Adicionar(Pedido_Otica_Parcelas);
                _Pedido_Otica_ParcelasRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Pedido_Otica_Parcelas Localizar(long? id)
        {
            try
            {
                return _Pedido_Otica_ParcelasRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirPedido_Otica_Parcelas(Pedido_Otica_Parcelas Pedido_Otica_Parcelas)
        {
            try
            {
                _Pedido_Otica_ParcelasRepositorio.Deletar(c => c == Pedido_Otica_Parcelas);
                _Pedido_Otica_ParcelasRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void ExcluirPedido_Otica_Parcelas(long Id_Pedido_Otica)
        {
            try
            {
                _Pedido_Otica_ParcelasRepositorio.Deletar(c => c.Id_pedido_otica == Id_Pedido_Otica);
                _Pedido_Otica_ParcelasRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarPedido_Otica_Parcelas(Pedido_Otica_Parcelas Pedido_Otica_Parcelas)
        {
            try
            {
                _Pedido_Otica_ParcelasRepositorio.Atualizar(Pedido_Otica_Parcelas);
                _Pedido_Otica_ParcelasRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Retorna uma coleção de parcelas conforme a codição de pagamento "parcela" selecionada no pedido.
        /// </summary>
        /// <param name="condicao_pagamento"></param>
        /// <param name="totalValor"></param>
        /// <param name="dtEmissao"></param>
        /// <returns>ICollection<Pedido_Parcelas></returns>
        public ICollection<Pedido_Otica_Parcelas> GerarParcelas(long? condicao_pagamento, decimal? totalValor, DateTime dtEmissao)
        {
            const int percentual = 100;
            ParcelaBLL parcelaBLL = new ParcelaBLL();
            Parcela parcela = parcelaBLL.Localizar(condicao_pagamento);

            ICollection<Pedido_Otica_Parcelas> Pedido_ParcelasList = new List<Pedido_Otica_Parcelas>();

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
                    Pedido_Otica_Parcelas parc = new Pedido_Otica_Parcelas();
                    DateTime dtVenc = dtEmissao.AddDays(nrDias);
                    parc.data_vencimento = dtVenc.ToShortDateString();
                    parc.numero_parcela = 0;
                    parc.percentual = percentual;
                    parc.quantidade_dias = nrDias;
                    parc.valor = totalValor;

                    Pedido_ParcelasList.Add(parc);
                }
            }
            else if ((parcela.codigo.Contains("S")) ||
                    (parcela.codigo.Contains("T")) ||
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
                        Pedido_Otica_Parcelas parc = new Pedido_Otica_Parcelas();
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
                            parc.numero_parcela = i + 1;
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
                            Pedido_Otica_Parcelas parc = new Pedido_Otica_Parcelas();
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
                                Pedido_Otica_Parcelas parc = new Pedido_Otica_Parcelas();

                                DateTime dtVenc = dtEmissao.AddMonths(i + 1);
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

        public void Dispose()
        {
            if (_Pedido_Otica_ParcelasRepositorio != null)
            {
                _Pedido_Otica_ParcelasRepositorio.Dispose();
            }

        }
    }
}
