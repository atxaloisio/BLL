using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Configuration;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using Utils;
using LinqKit;


namespace BLL
{
    public class Pedido_OticaBLL : BaseBLL, IDisposable
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
                Pedido_OticaView pedido = new Pedido_OticaView();
                pedido.id = item.Id;
                pedido.codigo = item.codigo;

                if (item.pedido_otica_infoadic.Count() > 0)
                {
                    pedido.os = item.pedido_otica_infoadic.FirstOrDefault().ordem_servico;
                    pedido.laboratorio = item.pedido_otica_infoadic.FirstOrDefault().laboratorio;
                }

                if (item.cliente != null)
                {
                    pedido.cliente = item.cliente.nome_fantasia;
                }

                if (item.parcela != null)
                {
                    pedido.codicao_pagamento = item.parcela.descricao;
                }

                if (item.vendedor != null)
                {
                    pedido.vendedor = item.vendedor.nome;
                }

                if (item.data_emissao != null)
                {
                    pedido.DtEmissao = item.data_emissao;
                }

                if (item.itempedido_otica.Count() > 0)
                {
                    decimal Total = 0;
                    Total = item.itempedido_otica.Sum(p => p.valor_total);
                    pedido.Total = Total;
                }

                if (item.status != null)
                {
                    pedido.Status = Enumerados.GetStringValue((StatusPedido)item.status);
                    if (!string.IsNullOrEmpty(item.usuario_alteracao))
                    {
                        pedido.usuario = item.usuario_alteracao;
                    }
                }

                else if (!string.IsNullOrEmpty(item.usuario_inclusao))
                {
                    pedido.usuario = item.usuario_inclusao;
                }

                pedido.Cancelado = item.cancelado == "S";

                lstRetorno.Add(pedido);

            }

            return lstRetorno;

        }

        public virtual List<Pedido_LaboratorioView> ToList_Pedido_LaboratorioView(List<Pedido_Otica> lst)
        {
            List<Pedido_LaboratorioView> lstRetorno = new List<Pedido_LaboratorioView>();

            foreach (Pedido_Otica item in lst)
            {
                Pedido_LaboratorioView pedido = new Pedido_LaboratorioView();
                pedido.id = item.Id;
                pedido.codigo = item.codigo;
                pedido.numero_pedido_cliente = item.numero_pedido_cliente;
                if (item.caixa != null)
                {
                    pedido.numero_caixa = item.caixa.numero;
                }

                if (item.cliente != null)
                {
                    pedido.cliente = item.cliente.nome_fantasia;
                }

                if (item.parcela != null)
                {
                    pedido.codicao_pagamento = item.parcela.descricao;
                }

                if (item.vendedor != null)
                {
                    pedido.vendedor = item.vendedor.nome;
                }

                if (item.transportadora != null)
                {
                    pedido.transportadora = item.transportadora.nome_fantasia;
                }

                if (item.data_emissao != null)
                {
                    pedido.DtEmissao = item.data_emissao;
                }

                if (item.data_fechamento != null)
                {
                    pedido.DtFechamento = item.data_fechamento;
                }

                if (item.status != null)
                {
                    pedido.Status = Enumerados.GetStringValue((StatusPedido)item.status);
                    if (!string.IsNullOrEmpty(item.usuario_alteracao))
                    {
                        pedido.usuario = item.usuario_alteracao;
                    }
                }

                else if (!string.IsNullOrEmpty(item.usuario_inclusao))
                {
                    pedido.usuario = item.usuario_inclusao;
                }

                pedido.Cancelado = item.cancelado == "S";


                lstRetorno.Add(pedido);

            }

            return lstRetorno;

        }

        public virtual List<Pedido_OticaAgrupaView> ToList_Pedido_OticaAgrupaView(List<Pedido_Otica> lst)
        {
            List<Pedido_OticaAgrupaView> lstRetorno = new List<Pedido_OticaAgrupaView>();

            foreach (Pedido_Otica item in lst)
            {
                lstRetorno.Add(new Pedido_OticaAgrupaView
                {
                    Agrupa = item.agrupado == "S",
                    id_pedido_omie = item.pedido != null ? item.pedido.id : 0,
                    numero_pedido_omie = item.pedido != null ? item.pedido.numero_pedido : string.Empty,
                    id = item.Id,
                    codigo = item.codigo,
                    cliente = item.cliente.nome_fantasia,
                    codicao_pagamento = item.parcela.descricao,
                    DtEmissao = item.data_emissao,
                    DtFechamento = item.data_fechamento,
                    Status = Enumerados.GetStringValue((StatusPedido)item.status)
                });
            }

            return lstRetorno;

        }

        public virtual List<Pedido_OticaParcelaView> ToList_Pedido_OticaParcelaView(List<Pedido_Otica> lst)
        {
            List<Pedido_OticaParcelaView> lstRetorno = new List<Pedido_OticaParcelaView>();

            foreach (Pedido_Otica item in lst)
            {
                lstRetorno.Add(new Pedido_OticaParcelaView
                {
                    id = item.Id,
                    codigo = item.codigo,
                    cliente = item.cliente.nome_fantasia,
                    codicao_pagamento = item.parcela.descricao,
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
                List<Pedido_Otica> PedidoOticaList;
                if (UsuarioLogado.Id_filial != null)
                {
                    PedidoOticaList = _Pedido_OticaRepositorio.GetTodos(p => p.Id_filial == UsuarioLogado.Id_filial, ordem, desc, page, pageSize).ToList();
                }
                else
                {
                    PedidoOticaList = _Pedido_OticaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
                }

                return PedidoOticaList;
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
                if (UsuarioLogado.Id_filial != null)
                {
                    predicate = predicate.And(p => p.Id_filial == UsuarioLogado.Id_filial);
                }
                totalRecords = _Pedido_OticaRepositorio.getTotalRegistros(predicate.Expand());

                return _Pedido_OticaRepositorio.Get(predicate.Expand(), ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica> getPedido_Otica(Expression<Func<Pedido_Otica, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Pedido_Otica, string>>[] ordem)
        {
            try
            {                
                if (UsuarioLogado.Id_filial != null)
                {
                    predicate = predicate.And(p => p.Id_filial == UsuarioLogado.Id_filial);
                }
                totalRecords = _Pedido_OticaRepositorio.getTotalRegistros(predicate.Expand());
                return _Pedido_OticaRepositorio.Get(predicate.Expand(), desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica> getPedido_Otica(Expression<Func<Pedido_Otica, bool>> predicate, bool desc, params Expression<Func<Pedido_Otica, string>>[] ordem)
        {
            try
            {
                if (UsuarioLogado.Id_filial != null)
                {
                    predicate = predicate.And(p => p.Id_filial == UsuarioLogado.Id_filial);
                }
                return _Pedido_OticaRepositorio.Get(predicate.Expand(), desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Pedido_Otica> getPedido_Otica(Expression<Func<Pedido_Otica, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (UsuarioLogado.Id_filial != null)
                {
                    predicate = predicate.And(p => p.Id_filial == UsuarioLogado.Id_filial);
                }

                if (NoTracking)
                {
                    return _Pedido_OticaRepositorio.GetNT(predicate.Expand()).ToList();
                }
                else
                {
                    return _Pedido_OticaRepositorio.Get(predicate.Expand()).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int getTotalRegistro()
        {
            try
            {
                return _Pedido_OticaRepositorio.getTotalRegistros();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int getTotalRegistro(Expression<Func<Pedido_Otica, bool>> predicate)
        {
            try
            {
                if (UsuarioLogado.Id_filial != null)
                {
                    predicate = predicate.And(p => p.Id_filial == UsuarioLogado.Id_filial);
                }
                return _Pedido_OticaRepositorio.getTotalRegistros(predicate.Expand());
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
                #region Parcela Pedido

                decimal? totalValor = 0;
                totalValor = Pedido_Otica.itempedido_otica.Sum(p => p.valor_total);

                Pedido_Otica_ParcelasBLL popBLL = new Pedido_Otica_ParcelasBLL();

                if (totalValor > 0)
                {
                    Pedido_Otica.pedido_otica_parcelas = popBLL.GerarParcelas(Pedido_Otica.condicao_pagamento, totalValor, DateTime.Now);
                }
                #endregion


                Pedido_Otica.inclusao = DateTime.Now;
                Pedido_Otica.usuario_inclusao = UsuarioLogado.nome;
                Pedido_Otica.codigo = Utils.Sequence.GetNextVal("sq_pedido_otica_sequence");

                if (UsuarioLogado.Id_empresa != null)
                {
                    Pedido_Otica.Id_empresa = UsuarioLogado.Id_empresa;
                }


                if (UsuarioLogado.Id_filial != null)
                {
                    Pedido_Otica.Id_filial = UsuarioLogado.Id_filial;
                }


                _Pedido_OticaRepositorio.Adicionar(Pedido_Otica);
                _Pedido_OticaRepositorio.Commit();
                GravarArquivo(Pedido_Otica);
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

        public virtual decimal? CalcularBasePedido_Otica(string strEsf, string strCil)
        {
            const int positiva = 6;
            const int negativa = -6;
            decimal? retorno = null;
            decimal esf = 0;
            decimal cil = 0;
            try
            {
                if ((!string.IsNullOrEmpty(strEsf)) & (!string.IsNullOrEmpty(strCil)))
                {
                    strEsf = strEsf.Replace(".", ",");
                    strCil = strCil.Replace(".", ",");

                    if (strEsf.Substring(0, 1) == "+")
                    {
                        esf = Convert.ToDecimal(strEsf.Substring(1, strEsf.Length - 1));
                        cil = Convert.ToDecimal(strCil.Substring(1, strCil.Length - 1));

                    }
                    else if (strEsf.Substring(0, 1) == "-")
                    {
                        esf = Convert.ToDecimal(strEsf.Substring(1, strEsf.Length - 1));
                        cil = Convert.ToDecimal(strCil.Substring(1, strCil.Length - 1));
                        esf = esf * -1;
                    }

                    if (esf > 0)
                    {
                        if (cil < 0)
                        {
                            cil = cil * 1;
                        }

                        retorno = ((esf - cil) / 2) + positiva;
                        retorno = Math.Round(Convert.ToDecimal(retorno));
                    }
                    else
                    {
                        //if (cil > 0)
                        //{
                        //    cil = cil * -1;
                        //}
                        retorno = ((esf - cil) / 2) - negativa;
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public virtual void AlterarPedido_Otica(Pedido_Otica Pedido_Otica)
        {
            #region ItemPedido
            try
            {
                ItemPedido_OticaBLL itemPedido_OticaBLL = new ItemPedido_OticaBLL();

                //lista de itens do banco
                ICollection<ItemPedido_Otica> itemPedido_OticaDB = itemPedido_OticaBLL.getItemPedido_Otica(p => p.Id_pedido_otica == Pedido_Otica.Id);
                ICollection<ItemPedido_Otica> itemPedido_OticaTela = Pedido_Otica.itempedido_otica;

                foreach (ItemPedido_Otica item in itemPedido_OticaTela)
                {
                    //Marca todos com ID = 0 como adicionados.
                    if (item.Id == 0)
                    {
                        item.state = EstadoEntidade.Added;
                    }
                    else
                    {
                        item.state = EstadoEntidade.Modified;
                    }
                }

                //marcar todas como alteradas e verifica se ele existe na lista da tela.
                foreach (ItemPedido_Otica item in itemPedido_OticaDB)
                {

                    if (itemPedido_OticaTela.FirstOrDefault(p => p.Id == item.Id) == null)
                    {
                        //clonar o item para marca-lo para exclusão
                        ItemPedido_Otica clone = new ItemPedido_Otica()
                        {
                            Id = item.Id,
                            Id_pedido_otica = item.Id_pedido_otica,
                            Id_produto = item.Id_produto,
                            quantidade = item.quantidade,
                            valor_unitario = item.valor_unitario,
                            percentual_desconto = item.percentual_desconto,
                            valor_desconto = item.valor_desconto,
                            valor_total = item.valor_total,
                            unidade = item.unidade
                        };

                        clone.state = EstadoEntidade.Deleted;

                        itemPedido_OticaTela.Add(clone);
                    }
                }
                #endregion

                #region Parcela Pedido
                List<Pedido_Otica> poList = getPedido_Otica(p => p.Id == Pedido_Otica.Id, true);

                Pedido_Otica pedBanco = null;

                if (poList.Count() > 0)
                {
                    pedBanco = poList.First();
                }

                decimal? totalValor = 0;
                totalValor = Pedido_Otica.itempedido_otica.Where(c => c.state != EstadoEntidade.Deleted).Sum(p => p.valor_total);

                Pedido_Otica_ParcelasBLL popBLL = new Pedido_Otica_ParcelasBLL();

                bool RemoveParcela = false;

                if (pedBanco != null)
                {
                    RemoveParcela = pedBanco.condicao_pagamento != Pedido_Otica.condicao_pagamento;
                    decimal totalBanco = 0;
                    totalBanco = pedBanco.itempedido_otica.Sum(p => p.valor_total);
                    if (totalValor != totalBanco)
                    {
                        RemoveParcela = true;
                    }

                }

                ICollection<Pedido_Otica_Parcelas> parcelasList = new List<Pedido_Otica_Parcelas>();
                if (RemoveParcela)
                {
                    parcelasList = Pedido_Otica.pedido_otica_parcelas;

                    if (parcelasList.Count == 0)
                    {
                        parcelasList = popBLL.getPedido_Otica_Parcelas(p => p.Id_pedido_otica == Pedido_Otica.Id, true);
                    }

                    if (totalValor > 0)
                    {
                        Pedido_Otica.pedido_otica_parcelas = popBLL.GerarParcelas(Pedido_Otica.condicao_pagamento, totalValor, DateTime.Now);
                    }

                }
                //else if (!RemoveParcela)
                //{
                //    parcelasList = popBLL.getPedido_Otica_Parcelas(p => p.Id_pedido_otica == Pedido_Otica.Id, true);
                //}

                foreach (Pedido_Otica_Parcelas item in parcelasList)
                {
                    item.state = EstadoEntidade.Deleted;
                    Pedido_Otica.pedido_otica_parcelas.Add(item);
                }

                #endregion

                Pedido_Otica.alteracao = DateTime.Now;
                Pedido_Otica.usuario_alteracao = UsuarioLogado.nome;
                _Pedido_OticaRepositorio.Atualizar(Pedido_Otica);
                _Pedido_OticaRepositorio.Commit();
                GravarArquivo(Pedido_Otica);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GravarArquivo(Pedido_Otica pedido)
        {
            bool IntGenLab = false;
            string CaminhoArquivos = string.Empty;
            string NomeArq = string.Empty;
            string[] TextoArq = new string[31];

            const int CAIXA = 0;
            const int OLHO = 1;
            const int CLIENTE = 2;
            const int ESF_OD = 3;
            const int CIL_OD = 4;
            const int EIXO_OD = 5;
            const int ADICAO_OD = 6;
            const int ESF_OE = 7;
            const int CIL_OE = 8;
            const int EIXO_OE = 9;
            const int ADICAO_OE = 10;
            const int PRISMA1_OD = 11;
            const int EIXO_PRISMA1_OD = 12;
            const int PRISMA2_OD = 13;
            const int EIXO_PRISMA2_OD = 14;
            const int PRISMA1_OE = 15;
            const int EIXO_PRISMA1_OE = 16;
            const int PRISMA2_OE = 17;
            const int EIXO_PRISMA2_OE = 18;
            const int DP_LONGE_OD = 19;
            const int DP_PERTO_OD = 20;
            const int DP_LONGE_OE = 21;
            const int DP_PERTO_OE = 22;
            const int DCOTP_OD = 23;
            const int APA_OD = 24;
            const int DCOTP_OE = 25;
            const int APA_OE = 26;
            const int DESCH_OD = 27;
            const int DESCH_OE = 28;
            const int DESCV_OD = 29;
            const int DESCV_OE = 30;

            for (int Index = 0; Index < TextoArq.Length; Index++)
            {
                TextoArq[Index] = string.Empty;
            }

            IntGenLab = Convert.ToBoolean(Parametro.GetParametro("intGenLab"));


            if (IntGenLab)
            {
                CaminhoArquivos = Parametro.GetParametro("strPathFileLab");

                if (pedido.caixa != null)
                {
                    TextoArq[CAIXA] = pedido.caixa.numero;
                }
                else
                {
                    TextoArq[CAIXA] = "0";
                }

                //1 ambos , 2 Direito, 3 esquerdo

                if ((!string.IsNullOrEmpty(pedido.od_gl_esf) && (!string.IsNullOrEmpty(pedido.oe_gl_esf))))
                {
                    TextoArq[OLHO] = "1";
                }
                else if ((!string.IsNullOrEmpty(pedido.od_gl_esf) && (string.IsNullOrEmpty(pedido.oe_gl_esf))))
                {
                    TextoArq[OLHO] = "2";
                }
                else if ((string.IsNullOrEmpty(pedido.od_gl_esf) && (!string.IsNullOrEmpty(pedido.oe_gl_esf))))
                {
                    TextoArq[OLHO] = "3";
                }

                ClienteBLL clienteBLL = new ClienteBLL();
                pedido.cliente = clienteBLL.Localizar(pedido.Id_cliente);

                if (pedido.cliente != null)
                {
                    string codCliente = string.Empty;
                    if (pedido.cliente.codigo_cliente_integracao.Length <= 3)
                    {
                        codCliente = pedido.cliente.codigo_cliente_integracao.PadLeft(pedido.cliente.codigo_cliente_integracao.Length + 1, '0');
                    }
                    else
                    {
                        codCliente = pedido.cliente.codigo_cliente_integracao;
                    }

                    TextoArq[CLIENTE] = "\"" + pedido.cliente.nome_fantasia + ";" + codCliente + ";" + pedido.numero_pedido_cliente + "\"";
                }


                TextoArq[ESF_OD] = pedido.od_gl_esf;
                TextoArq[CIL_OD] = pedido.od_gl_cil;
                TextoArq[EIXO_OD] = pedido.od_eixo.ToString();
                TextoArq[ADICAO_OD] = pedido.od_adicao.ToString();
                TextoArq[ESF_OE] = pedido.oe_gl_esf;
                TextoArq[CIL_OE] = pedido.oe_gl_cil;
                TextoArq[EIXO_OE] = pedido.oe_eixo.ToString();
                TextoArq[ADICAO_OE] = pedido.oe_adicao.ToString();
                TextoArq[PRISMA1_OD] = pedido.od_prisma_valor;
                TextoArq[EIXO_PRISMA1_OD] = pedido.od_prisma_eixo.ToString();
                TextoArq[PRISMA2_OD] = string.Empty;
                TextoArq[EIXO_PRISMA2_OD] = string.Empty;
                TextoArq[PRISMA1_OE] = pedido.oe_prisma_valor;
                TextoArq[EIXO_PRISMA1_OE] = pedido.oe_prisma_eixo.ToString();
                TextoArq[PRISMA2_OE] = string.Empty;
                TextoArq[EIXO_PRISMA2_OE] = string.Empty;
                TextoArq[DP_LONGE_OD] = pedido.od_dnp_longe;
                TextoArq[DP_PERTO_OD] = pedido.od_dnp_perto;
                TextoArq[DP_LONGE_OE] = pedido.oe_dnp_longe;
                TextoArq[DP_PERTO_OE] = pedido.oe_dnp_perto;
                TextoArq[DCOTP_OD] = string.Empty;
                TextoArq[APA_OD] = pedido.od_alt;
                TextoArq[DCOTP_OE] = string.Empty;
                TextoArq[APA_OE] = pedido.oe_alt;
                TextoArq[DESCH_OD] = pedido.od_dech;
                TextoArq[DESCH_OE] = pedido.oe_dech;
                TextoArq[DESCV_OD] = string.Empty;
                TextoArq[DESCV_OE] = string.Empty;


                string linha = string.Empty;

                foreach (var item in TextoArq)
                {
                    if (string.IsNullOrEmpty(linha))
                    {
                        linha += item;
                    }
                    else
                    {
                        linha += "," + item;
                    }

                }

                NomeArq = pedido.codigo.ToString();

                if (string.IsNullOrEmpty(CaminhoArquivos))
                {
                    CaminhoArquivos = @"C:\temp\";
                }

                File.WriteAllText(@CaminhoArquivos + @"\" + NomeArq, linha);
            }
        }

        public void AtualizarStatusPedido(long? id, StatusPedido status)
        {
            try
            {
                Pedido_Otica pedido_Otica = Localizar(id);
                if (pedido_Otica != null)
                {
                    pedido_Otica.status = (int)status;
                    AlterarPedido_Otica(pedido_Otica);
                }
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
