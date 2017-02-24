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
    public class Motivo_EntregaBLL : IDisposable
    {
        IMotivo_EntregaRepositorio _Motivo_EntregaRepositorio;
        public Motivo_EntregaBLL()
        {
            try
            {
                _Motivo_EntregaRepositorio = new Motivo_EntregaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Motivo_Entrega> getMotivo_Entrega(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Motivo_EntregaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Motivo_EntregaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Motivo_Entrega> getMotivo_Entrega(Expression<Func<Motivo_Entrega, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Motivo_EntregaRepositorio.getTotalRegistros();
                return _Motivo_EntregaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Motivo_Entrega> getMotivo_Entrega(Expression<Func<Motivo_Entrega, bool>> predicate, Expression<Func<Motivo_Entrega, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Motivo_EntregaRepositorio.getTotalRegistros(predicate);
                return _Motivo_EntregaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarMotivo_Entrega(Motivo_Entrega Motivo_Entrega)
        {
            try
            {
                Motivo_Entrega.inclusao = DateTime.Now;
                _Motivo_EntregaRepositorio.Adicionar(Motivo_Entrega);
                _Motivo_EntregaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Motivo_Entrega Localizar(long? id)
        {
            try
            {
                return _Motivo_EntregaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirMotivo_Entrega(Motivo_Entrega Motivo_Entrega)
        {
            try
            {
                _Motivo_EntregaRepositorio.Deletar(c => c == Motivo_Entrega);
                _Motivo_EntregaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarMotivo_Entrega(Motivo_Entrega Motivo_Entrega)
        {
            try
            {
                Motivo_Entrega.alteracao = DateTime.Now;
                _Motivo_EntregaRepositorio.Atualizar(Motivo_Entrega);
                _Motivo_EntregaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Motivo_EntregaRepositorio != null)
            {
                _Motivo_EntregaRepositorio.Dispose();
            }

        }
    }
}
