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
    public class Contas_PagarBLL : BaseBLL, IDisposable
    {
        IContas_PagarRepositorio _Contas_PagarRepositorio;
        public Contas_PagarBLL()
        {
            try
            {
                _Contas_PagarRepositorio = new Contas_PagarRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Contas_Pagar> getContas_Pagar(long? Id = -1, bool NoTracking = false)
        {
            try
            {
                if (Id == -1)
                {
                    return _Contas_PagarRepositorio.GetTodos().ToList();
                }
                else
                {
                    if (NoTracking)
                    {
                        return _Contas_PagarRepositorio.GetNT(p => p.Id == Id).ToList();
                    }
                    else
                    {
                        return _Contas_PagarRepositorio.Get(p => p.Id == Id).ToList();
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Contas_Pagar> getContas_Pagar(Expression<Func<Contas_Pagar, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Contas_PagarRepositorio.getTotalRegistros();
                return _Contas_PagarRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Contas_Pagar> getContas_Pagar(Expression<Func<Contas_Pagar, bool>> predicate, Expression<Func<Contas_Pagar, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Contas_PagarRepositorio.getTotalRegistros(predicate);
                return _Contas_PagarRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Contas_Pagar> getContas_Pagar(Expression<Func<Contas_Pagar, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Contas_Pagar, string>>[] ordem)
        {
            try
            {
                totalRecords = _Contas_PagarRepositorio.getTotalRegistros(predicate);
                return _Contas_PagarRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Contas_Pagar> getContas_Pagar(Expression<Func<Contas_Pagar, bool>> predicate, bool desc, params Expression<Func<Contas_Pagar, string>>[] ordem)
        {
            try
            {

                return _Contas_PagarRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Contas_Pagar> getContas_Pagar(Expression<Func<Contas_Pagar, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (NoTracking)
                {
                    return _Contas_PagarRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _Contas_PagarRepositorio.Get(predicate).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Contas_PagarView> ToList_Contas_PagarView(List<Contas_Pagar> lst)
        {
            List<Contas_PagarView> lstRetorno = new List<Contas_PagarView>();

            foreach (Contas_Pagar item in lst)
            {
                lstRetorno.Add(new Contas_PagarView
                {
                    Id = item.Id,                    
                    Documento = item.Documento,
                    fornecedor = item.cliente.nome_fantasia,
                    pago = item.pago == "S",
                    previsao = item.previsao,
                    valor = item.valor,
                    vencimento = item.vencimento,
                    pagamento = item.pagamento
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarContas_Pagar(Contas_Pagar Contas_Pagar)
        {
            try
            {
                Contas_Pagar.inclusao = DateTime.Now;

                if (UsuarioLogado.Id_empresa != null)
                {
                    Contas_Pagar.Id_empresa = UsuarioLogado.Id_empresa;
                }

                if (UsuarioLogado.Id_filial != null)
                {
                    Contas_Pagar.Id_filial = UsuarioLogado.Id_filial;
                }

                Contas_Pagar.usuario_inclusao = UsuarioLogado.nome;

                _Contas_PagarRepositorio.Adicionar(Contas_Pagar);
                _Contas_PagarRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Contas_Pagar Localizar(long? id)
        {
            try
            {
                return _Contas_PagarRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirContas_Pagar(Contas_Pagar Contas_Pagar)
        {
            try
            {
                _Contas_PagarRepositorio.Deletar(c => c == Contas_Pagar);
                _Contas_PagarRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarContas_Pagar(Contas_Pagar Contas_Pagar)
        {
            try
            {
                Contas_Pagar.alteracao = DateTime.Now;
                Contas_Pagar.usuario_alteracao = UsuarioLogado.nome;
                _Contas_PagarRepositorio.Atualizar(Contas_Pagar);
                _Contas_PagarRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Contas_PagarRepositorio != null)
            {
                _Contas_PagarRepositorio.Dispose();
            }

        }
    }
}
