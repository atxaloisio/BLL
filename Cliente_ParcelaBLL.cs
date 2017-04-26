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
    public class Cliente_ParcelaBLL : BaseBLL, IDisposable
    {
        ICliente_ParcelaRepositorio _Cliente_ParcelaRepositorio;
        public Cliente_ParcelaBLL()
        {
            try
            {
                _Cliente_ParcelaRepositorio = new Cliente_ParcelaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Parcela> getCliente_Parcela(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Cliente_ParcelaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Cliente_ParcelaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Parcela> getCliente_Parcela(Expression<Func<Cliente_Parcela, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Cliente_ParcelaRepositorio.getTotalRegistros();
                return _Cliente_ParcelaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Parcela> getCliente_Parcela(Expression<Func<Cliente_Parcela, bool>> predicate, Expression<Func<Cliente_Parcela, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Cliente_ParcelaRepositorio.getTotalRegistros(predicate);
                return _Cliente_ParcelaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Parcela> getCliente_Parcela(Expression<Func<Cliente_Parcela, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Cliente_Parcela, string>>[] ordem)
        {
            try
            {
                totalRecords = _Cliente_ParcelaRepositorio.getTotalRegistros(predicate);
                return _Cliente_ParcelaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Parcela> getCliente_Parcela(Expression<Func<Cliente_Parcela, bool>> predicate, bool desc,params Expression<Func<Cliente_Parcela, string>>[] ordem)
        {
            try
            {
                
                return _Cliente_ParcelaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Parcela> getCliente_Parcela(Expression<Func<Cliente_Parcela, bool>> predicate)
        {
            try
            {
                return _Cliente_ParcelaRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_ParcelaView> ToList_Cliente_ParcelaView(List<Cliente_Parcela> lst)
        {
            List<Cliente_ParcelaView> lstRetorno = new List<Cliente_ParcelaView>();

            foreach (Cliente_Parcela item in lst)
            {
                lstRetorno.Add(new Cliente_ParcelaView()
                {
                    id = item.Id,                    
                    cliente = item.cliente.nome_fantasia,
                    codicao_pagamento = item.descricao                    
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarCliente_Parcela(Cliente_Parcela Cliente_Parcela)
        {
            try
            {
                Cliente_Parcela.inclusao = DateTime.Now;
                _Cliente_ParcelaRepositorio.Adicionar(Cliente_Parcela);
                _Cliente_ParcelaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Cliente_Parcela Localizar(long? id)
        {
            try
            {
                return _Cliente_ParcelaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCliente_Parcela(Cliente_Parcela Cliente_Parcela)
        {
            try
            {
                _Cliente_ParcelaRepositorio.Deletar(c => c == Cliente_Parcela);
                _Cliente_ParcelaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCliente_Parcela(Cliente_Parcela Cliente_Parcela)
        {
            try
            {
                Cliente_Parcela.alteracao = DateTime.Now;
                _Cliente_ParcelaRepositorio.Atualizar(Cliente_Parcela);
                _Cliente_ParcelaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Cliente_ParcelaRepositorio != null)
            {
                _Cliente_ParcelaRepositorio.Dispose();
            }

        }
    }
}
