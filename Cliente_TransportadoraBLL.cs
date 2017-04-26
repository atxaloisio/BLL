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
    public class Cliente_TransportadoraBLL : BaseBLL, IDisposable
    {
        ICliente_TransportadoraRepositorio _Cliente_TransportadoraRepositorio;
        public Cliente_TransportadoraBLL()
        {
            try
            {
                _Cliente_TransportadoraRepositorio = new Cliente_TransportadoraRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Transportadora> getCliente_Transportadora(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Cliente_TransportadoraRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Cliente_TransportadoraRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Transportadora> getCliente_Transportadora(Expression<Func<Cliente_Transportadora, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Cliente_TransportadoraRepositorio.getTotalRegistros();
                return _Cliente_TransportadoraRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Transportadora> getCliente_Transportadora(Expression<Func<Cliente_Transportadora, bool>> predicate, Expression<Func<Cliente_Transportadora, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Cliente_TransportadoraRepositorio.getTotalRegistros(predicate);
                return _Cliente_TransportadoraRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Transportadora> getCliente_Transportadora(Expression<Func<Cliente_Transportadora, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Cliente_Transportadora, string>>[] ordem)
        {
            try
            {
                totalRecords = _Cliente_TransportadoraRepositorio.getTotalRegistros(predicate);
                return _Cliente_TransportadoraRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Transportadora> getCliente_Transportadora(Expression<Func<Cliente_Transportadora, bool>> predicate, bool desc,params Expression<Func<Cliente_Transportadora, string>>[] ordem)
        {
            try
            {       
                return _Cliente_TransportadoraRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_Transportadora> getCliente_Transportadora(Expression<Func<Cliente_Transportadora, bool>> predicate)
        {
            try
            {
                return _Cliente_TransportadoraRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Cliente_TransportadoraView> ToList_Cliente_TransportadoraView(List<Cliente_Transportadora> lst)
        {
            List<Cliente_TransportadoraView> lstRetorno = new List<Cliente_TransportadoraView>();

            foreach (Cliente_Transportadora item in lst)
            {
                lstRetorno.Add(new Cliente_TransportadoraView()
                {
                    id = item.Id,
                    cliente = item.Cliente.nome_fantasia,
                    transportdora = item.Transportadora.nome_fantasia
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarCliente_Transportadora(Cliente_Transportadora Cliente_Transportadora)
        {
            try
            {
                
                _Cliente_TransportadoraRepositorio.Adicionar(Cliente_Transportadora);
                _Cliente_TransportadoraRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Cliente_Transportadora Localizar(long? id)
        {
            try
            {
                return _Cliente_TransportadoraRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirCliente_Transportadora(Cliente_Transportadora Cliente_Transportadora)
        {
            try
            {
                _Cliente_TransportadoraRepositorio.Deletar(c => c == Cliente_Transportadora);
                _Cliente_TransportadoraRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarCliente_Transportadora(Cliente_Transportadora Cliente_Transportadora)
        {
            try
            {
                
                _Cliente_TransportadoraRepositorio.Atualizar(Cliente_Transportadora);
                _Cliente_TransportadoraRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Cliente_TransportadoraRepositorio != null)
            {
                _Cliente_TransportadoraRepositorio.Dispose();
            }

        }
    }
}
