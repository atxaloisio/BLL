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
    public class ClienteBLL : BaseBLL, IDisposable
    {
        IClienteRepositorio _ClienteRepositorio;
        public ClienteBLL()
        {
            try
            {
                _ClienteRepositorio = new ClienteRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(long? Id = -1, bool NoTracking = false)
        {
            try
            {
                if (Id == -1)
                {
                    return _ClienteRepositorio.GetTodos().ToList();
                }
                else
                {
                    if (NoTracking)
                    {
                        return _ClienteRepositorio.GetNT(p => p.Id == Id).ToList();
                    }
                    else
                    {
                        return _ClienteRepositorio.Get(p => p.Id == Id).ToList();
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(Expression<Func<Cliente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ClienteRepositorio.getTotalRegistros();
                return _ClienteRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(Expression<Func<Cliente, bool>> predicate, Expression<Func<Cliente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ClienteRepositorio.getTotalRegistros(predicate);
                return _ClienteRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(Expression<Func<Cliente, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Cliente, string>>[] ordem)
        {
            try
            {
                totalRecords = _ClienteRepositorio.getTotalRegistros(predicate);
                return _ClienteRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(Expression<Func<Cliente, bool>> predicate, bool desc, params Expression<Func<Cliente, string>>[] ordem)
        {
            try
            {
                
                return _ClienteRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente> getCliente(Expression<Func<Cliente, bool>> predicate, bool NoTracking = false)
        {
            try
            {                
                if (NoTracking)
                {
                    return _ClienteRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _ClienteRepositorio.Get(predicate).ToList();
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<ClienteView> ToList_ClienteView(List<Cliente> lst)
        {
            List<ClienteView> lstRetorno = new List<ClienteView>();

            foreach (Cliente item in lst)
            {
                lstRetorno.Add(new ClienteView
                {
                    Id = item.Id,
                    bairro = item.bairro,
                    cep = item.cep,
                    cidade = item.cidade,
                    cnpj_cpf = item.cnpj_cpf,
                    codigo_cliente_integracao = item.codigo_cliente_integracao,
                    complemento = item.complemento,
                    email = item.email,
                    endereco = item.endereco,
                    endereco_numero = item.endereco_numero,
                    estado = item.estado,                    
                    nome_fantasia = item.nome_fantasia,
                    razao_social = item.razao_social,
                    telefone1_ddd = item.telefone1_ddd,
                    telefone1_numero = item.telefone1_numero,
                    contato = item.contato,
                    inscricao_estadual = item.inscricao_estadual,
                    inscricao_municipal = item.inscricao_municipal
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarCliente(Cliente Cliente)
        {
            try
            {
                Cliente.inclusao = DateTime.Now;
                _ClienteRepositorio.Adicionar(Cliente);
                _ClienteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Cliente Localizar(long? id)
        {
            try
            {
                return _ClienteRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCliente(Cliente Cliente)
        {
            try
            {
                _ClienteRepositorio.Deletar(c => c == Cliente);
                _ClienteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCliente(Cliente Cliente)
        {
            try
            {
                Cliente.alteracao = DateTime.Now;
                _ClienteRepositorio.Atualizar(Cliente);
                _ClienteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_ClienteRepositorio != null)
            {
                _ClienteRepositorio.Dispose();
            }

        }
    }
}
