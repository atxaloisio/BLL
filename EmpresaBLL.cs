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
    public class EmpresaBLL : BaseBLL, IDisposable
    {
        IEmpresaRepositorio _EmpresaRepositorio;
        public EmpresaBLL()
        {
            try
            {
                _EmpresaRepositorio = new EmpresaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Empresa> getEmpresa(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _EmpresaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _EmpresaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Empresa> getEmpresa(Expression<Func<Empresa, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _EmpresaRepositorio.getTotalRegistros();
                return _EmpresaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Empresa> getEmpresa(Expression<Func<Empresa, bool>> predicate, Expression<Func<Empresa, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _EmpresaRepositorio.getTotalRegistros(predicate);
                return _EmpresaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Empresa> getEmpresa(Expression<Func<Empresa, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Empresa, string>>[] ordem)
        {
            try
            {
                totalRecords = _EmpresaRepositorio.getTotalRegistros(predicate);
                return _EmpresaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Empresa> getEmpresa(Expression<Func<Empresa, bool>> predicate, bool desc, params Expression<Func<Empresa, string>>[] ordem)
        {
            try
            {

                return _EmpresaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Empresa> getEmpresa(Expression<Func<Empresa, bool>> predicate)
        {
            try
            {
                return _EmpresaRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarEmpresa(Empresa Empresa)
        {
            try
            {
                _EmpresaRepositorio.Adicionar(Empresa);
                _EmpresaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Empresa Localizar(long? id)
        {
            try
            {
                return _EmpresaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirEmpresa(Empresa Empresa)
        {
            try
            {
                _EmpresaRepositorio.Deletar(c => c == Empresa);
                _EmpresaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarEmpresa(Empresa Empresa)
        {
            try
            {
                _EmpresaRepositorio.Atualizar(Empresa);
                _EmpresaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_EmpresaRepositorio != null)
            {
                _EmpresaRepositorio.Dispose();
            }

        }
    }
}
