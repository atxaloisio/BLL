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
    public class PerfilBLL : BaseBLL, IDisposable
    {
        IPerfilRepositorio _PerfilRepositorio;
        public PerfilBLL()
        {
            try
            {
                _PerfilRepositorio = new PerfilRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Perfil> getPerfil(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _PerfilRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _PerfilRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Perfil> getPerfil(Expression<Func<Perfil, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _PerfilRepositorio.getTotalRegistros();
                return _PerfilRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Perfil> getPerfil(Expression<Func<Perfil, bool>> predicate, Expression<Func<Perfil, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _PerfilRepositorio.getTotalRegistros(predicate);
                return _PerfilRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Perfil> getPerfil(Expression<Func<Perfil, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Perfil, string>>[] ordem)
        {
            try
            {
                totalRecords = _PerfilRepositorio.getTotalRegistros(predicate);
                return _PerfilRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Perfil> getPerfil(Expression<Func<Perfil, bool>> predicate, bool desc, params Expression<Func<Perfil, string>>[] ordem)
        {
            try
            {
        
                return _PerfilRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Perfil> getPerfil(Expression<Func<Perfil, bool>> predicate)
        {
            try
            {

                return _PerfilRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarPerfil(Perfil Perfil)
        {
            try
            {                
                _PerfilRepositorio.Adicionar(Perfil);
                _PerfilRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Perfil Localizar(long? id)
        {
            try
            {
                return _PerfilRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirPerfil(Perfil Perfil)
        {
            try
            {
                _PerfilRepositorio.Deletar(c => c == Perfil);
                _PerfilRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarPerfil(Perfil Perfil)
        {
            try
            {             
                _PerfilRepositorio.Atualizar(Perfil);
                _PerfilRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_PerfilRepositorio != null)
            {
                _PerfilRepositorio.Dispose();
            }

        }
    }
}
