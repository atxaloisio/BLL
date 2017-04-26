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
    public class Vendedor_LocalidadeBLL : BaseBLL, IDisposable
    {
        IVendedor_LocalidadeRepositorio _Vendedor_LocalidadeRepositorio;
        public Vendedor_LocalidadeBLL()
        {
            try
            {
                _Vendedor_LocalidadeRepositorio = new Vendedor_LocalidadeRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor_Localidade> getVendedor_Localidade(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Vendedor_LocalidadeRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Vendedor_LocalidadeRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor_Localidade> getVendedor_Localidade(Expression<Func<Vendedor_Localidade, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Vendedor_LocalidadeRepositorio.getTotalRegistros();
                return _Vendedor_LocalidadeRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor_Localidade> getVendedor_Localidade(Expression<Func<Vendedor_Localidade, bool>> predicate, Expression<Func<Vendedor_Localidade, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Vendedor_LocalidadeRepositorio.getTotalRegistros(predicate);
                return _Vendedor_LocalidadeRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor_Localidade> getVendedor_Localidade(Expression<Func<Vendedor_Localidade, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Vendedor_Localidade, string>>[] ordem)
        {
            try
            {
                totalRecords = _Vendedor_LocalidadeRepositorio.getTotalRegistros(predicate);
                return _Vendedor_LocalidadeRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor_Localidade> getVendedor_Localidade(Expression<Func<Vendedor_Localidade, bool>> predicate, bool desc, params Expression<Func<Vendedor_Localidade, string>>[] ordem)
        {
            try
            {
         
                return _Vendedor_LocalidadeRepositorio.Get(predicate,desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public virtual List<Vendedor_Localidade> getVendedor_Localidade(Expression<Func<Vendedor_Localidade, bool>> predicate)
        {
            try
            {
                return _Vendedor_LocalidadeRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Vendedor_LocalidadeView> ToList_Vendedor_LocalidadeView(List<Vendedor_Localidade> lst)
        {
            List<Vendedor_LocalidadeView> lstRetorno = new List<Vendedor_LocalidadeView>();

            foreach (Vendedor_Localidade item in lst)
            {
                if (item.vendedor != null)
                {
                    lstRetorno.Add(new Vendedor_LocalidadeView()
                    {
                        Id = item.Id,
                        vendedor = item.vendedor.nome,
                        UF = item.cidade.cUF,
                        Cidade = item.cidade.cNome
                    });
                }

            }

            return lstRetorno;

        }

        public virtual void AdicionarVendedor_Localidade(Vendedor_Localidade Vendedor_Localidade)
        {
            try
            {
                _Vendedor_LocalidadeRepositorio.Adicionar(Vendedor_Localidade);
                _Vendedor_LocalidadeRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Vendedor_Localidade Localizar(long? id)
        {
            try
            {
                return _Vendedor_LocalidadeRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirVendedor_Localidade(Vendedor_Localidade Vendedor_Localidade)
        {
            try
            {
                _Vendedor_LocalidadeRepositorio.Deletar(c => c == Vendedor_Localidade);
                _Vendedor_LocalidadeRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarVendedor_Localidade(Vendedor_Localidade Vendedor_Localidade)
        {
            try
            {
                _Vendedor_LocalidadeRepositorio.Atualizar(Vendedor_Localidade);
                _Vendedor_LocalidadeRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Vendedor_LocalidadeRepositorio != null)
            {
                _Vendedor_LocalidadeRepositorio.Dispose();
            }

        }
    }
}
