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
    public class RotaBLL : BaseBLL, IDisposable
    {
        IRotaRepositorio _RotaRepositorio;
        public RotaBLL()
        {
            try
            {
                _RotaRepositorio = new RotaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Rota> getRota(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _RotaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _RotaRepositorio.Get(p => p.id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Rota> getRota(Expression<Func<Rota, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _RotaRepositorio.getTotalRegistros();
                return _RotaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Rota> getRota(Expression<Func<Rota, bool>> predicate, Expression<Func<Rota, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _RotaRepositorio.getTotalRegistros(predicate);
                return _RotaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Rota> getRota(Expression<Func<Rota, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Rota, string>>[] ordem)
        {
            try
            {
                totalRecords = _RotaRepositorio.getTotalRegistros(predicate);
                return _RotaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Rota> getRota(Expression<Func<Rota, bool>> predicate, bool desc, int page, params Expression<Func<Rota, string>>[] ordem)
        {
            try
            {
        
                return _RotaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Rota> getRota(Expression<Func<Rota, bool>> predicate)
        {
            try
            {
                return _RotaRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<RotaView> ToList_RotaView(List<Rota> lst)
        {
            List<RotaView> lstRetorno = new List<RotaView>();

            foreach (Rota item in lst)
            {
                if (item.cliente != null)
                {
                    lstRetorno.Add(new RotaView()
                    {
                        Id = item.id,
                        Transportadora = item.cliente.nome_fantasia,
                        UF = item.cidade.cUF,
                        Cidade = item.cidade.cNome
                    });
                }
                
            }

            return lstRetorno;

        }

        public virtual void AdicionarRota(Rota Rota)
        {
            try
            {
                _RotaRepositorio.Adicionar(Rota);
                _RotaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Rota Localizar(long? id)
        {
            try
            {
                return _RotaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirRota(Rota Rota)
        {
            try
            {
                _RotaRepositorio.Deletar(c => c == Rota);
                _RotaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarRota(Rota Rota)
        {
            try
            {
                _RotaRepositorio.Atualizar(Rota);
                _RotaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_RotaRepositorio != null)
            {
                _RotaRepositorio.Dispose();
            }

        }
    }
}
