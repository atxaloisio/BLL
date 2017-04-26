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
    public class Funcao_PerfilBLL : BaseBLL, IDisposable
    {
        IFuncao_PerfilRepositorio _Funcao_PerfilRepositorio;
        public Funcao_PerfilBLL()
        {
            try
            {
                _Funcao_PerfilRepositorio = new Funcao_PerfilRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao_Perfil> getFuncao_Perfil(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Funcao_PerfilRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Funcao_PerfilRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao_Perfil> getFuncao_Perfil(Expression<Func<Funcao_Perfil, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Funcao_PerfilRepositorio.getTotalRegistros();
                return _Funcao_PerfilRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao_Perfil> getFuncao_Perfil(Expression<Func<Funcao_Perfil, bool>> predicate, Expression<Func<Funcao_Perfil, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Funcao_PerfilRepositorio.getTotalRegistros(predicate);
                return _Funcao_PerfilRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao_Perfil> getFuncao_Perfil(Expression<Func<Funcao_Perfil, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Funcao_Perfil, string>>[] ordem)
        {
            try
            {
                totalRecords = _Funcao_PerfilRepositorio.getTotalRegistros(predicate);
                return _Funcao_PerfilRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Funcao_Perfil> getFuncao_Perfil(Expression<Func<Funcao_Perfil, bool>> predicate, bool desc, params Expression<Func<Funcao_Perfil, string>>[] ordem)
        {
            try
            {                
                return _Funcao_PerfilRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarFuncao_Perfil(Funcao_Perfil Funcao_Perfil)
        {
            try
            {
                Funcao_Perfil.inclusao = DateTime.Now;                
                _Funcao_PerfilRepositorio.Adicionar(Funcao_Perfil);
                _Funcao_PerfilRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Funcao_Perfil Localizar(long? id)
        {
            try
            {
                return _Funcao_PerfilRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirFuncao_Perfil(Funcao_Perfil Funcao_Perfil)
        {
            try
            {
                _Funcao_PerfilRepositorio.Deletar(c => c.Id_perfil == Funcao_Perfil.Id_perfil & c.codigo_funcao == Funcao_Perfil.codigo_funcao);
                _Funcao_PerfilRepositorio.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void AlterarFuncao_Perfil(Funcao_Perfil Funcao_Perfil)
        {
            try
            {
                _Funcao_PerfilRepositorio.Atualizar(Funcao_Perfil);
                _Funcao_PerfilRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Funcao_PerfilRepositorio != null)
            {
                _Funcao_PerfilRepositorio.Dispose();
            }

        }
    }
}
