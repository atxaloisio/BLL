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
    public class Tipo_LenteBLL : BaseBLL, IDisposable
    {
        ITipo_LenteRepositorio _Tipo_LenteRepositorio;
        public Tipo_LenteBLL()
        {
            try
            {
                _Tipo_LenteRepositorio = new Tipo_LenteRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Lente> getTipo_Lente(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Tipo_LenteRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Tipo_LenteRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Lente> getTipo_Lente(Expression<Func<Tipo_Lente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Tipo_LenteRepositorio.getTotalRegistros();
                return _Tipo_LenteRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Lente> getTipo_Lente(Expression<Func<Tipo_Lente, bool>> predicate, Expression<Func<Tipo_Lente, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Tipo_LenteRepositorio.getTotalRegistros(predicate);
                return _Tipo_LenteRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Lente> getTipo_Lente(Expression<Func<Tipo_Lente, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Tipo_Lente, string>>[] ordem)
        {
            try
            {
                totalRecords = _Tipo_LenteRepositorio.getTotalRegistros(predicate);
                return _Tipo_LenteRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Lente> getTipo_Lente(Expression<Func<Tipo_Lente, bool>> predicate, bool desc, params Expression<Func<Tipo_Lente, string>>[] ordem)
        {
            try
            {

                return _Tipo_LenteRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Lente> getTipo_Lente(Expression<Func<Tipo_Lente, bool>> predicate)
        {
            try
            {
                return _Tipo_LenteRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_LenteView> ToList_Tipo_LenteView(List<Tipo_Lente> lst)
        {
            List<Tipo_LenteView> lstRetorno = new List<Tipo_LenteView>();

            foreach (Tipo_Lente item in lst)
            {
                lstRetorno.Add(new Tipo_LenteView
                {
                    Id = item.Id,
                    descricao = item.descricao,
                    inativo = item.inativo == "S"
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarTipo_Lente(Tipo_Lente Tipo_Lente)
        {
            try
            {
                _Tipo_LenteRepositorio.Adicionar(Tipo_Lente);
                _Tipo_LenteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Tipo_Lente Localizar(long? id)
        {
            try
            {
                return _Tipo_LenteRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirTipo_Lente(Tipo_Lente Tipo_Lente)
        {
            try
            {
                _Tipo_LenteRepositorio.Deletar(c => c == Tipo_Lente);
                _Tipo_LenteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarTipo_Lente(Tipo_Lente Tipo_Lente)
        {
            try
            {
                _Tipo_LenteRepositorio.Atualizar(Tipo_Lente);
                _Tipo_LenteRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Tipo_LenteRepositorio != null)
            {
                _Tipo_LenteRepositorio.Dispose();
            }

        }
    }
}
