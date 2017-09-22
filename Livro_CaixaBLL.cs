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
    public class Livro_CaixaBLL : BaseBLL, IDisposable
    {
        ILivro_CaixaRepositorio _Livro_CaixaRepositorio;
        public Livro_CaixaBLL()
        {
            try
            {
                _Livro_CaixaRepositorio = new Livro_CaixaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Livro_Caixa> getLivro_Caixa(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Livro_CaixaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Livro_CaixaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Livro_Caixa> getLivro_Caixa(Expression<Func<Livro_Caixa, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Livro_CaixaRepositorio.getTotalRegistros();
                return _Livro_CaixaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Livro_Caixa> getLivro_Caixa(Expression<Func<Livro_Caixa, bool>> predicate, Expression<Func<Livro_Caixa, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Livro_CaixaRepositorio.getTotalRegistros(predicate);
                return _Livro_CaixaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Livro_Caixa> getLivro_Caixa(Expression<Func<Livro_Caixa, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Livro_Caixa, string>>[] ordem)
        {
            try
            {
                totalRecords = _Livro_CaixaRepositorio.getTotalRegistros(predicate);
                return _Livro_CaixaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Livro_Caixa> getLivro_Caixa(Expression<Func<Livro_Caixa, bool>> predicate, bool desc, params Expression<Func<Livro_Caixa, string>>[] ordem)
        {
            try
            {

                return _Livro_CaixaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Livro_Caixa> getLivro_Caixa(Expression<Func<Livro_Caixa, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (NoTracking)
                {
                    return _Livro_CaixaRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _Livro_CaixaRepositorio.Get(predicate).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Livro_CaixaView> ToList_Livro_CaixaView(List<Livro_Caixa> lst)
        {
            List<Livro_CaixaView> lstRetorno = new List<Livro_CaixaView>();

            foreach (Livro_Caixa item in lst)
            {
                lstRetorno.Add(new Livro_CaixaView
                {
                    Id = item.Id                    
                });
            }

            return lstRetorno;

        }

        public virtual List<Livro_CaixaView> ToList_Livro_CaixaView(ICollection<Livro_Caixa> lst)
        {
            List<Livro_CaixaView> lstRetorno = new List<Livro_CaixaView>();

            foreach (Livro_Caixa item in lst)
            {
                lstRetorno.Add(new Livro_CaixaView
                {
                    Id = item.Id
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarLivro_Caixa(Livro_Caixa Livro_Caixa)
        {
            try
            {
                Livro_Caixa.inclusao = DateTime.Now;
                Livro_Caixa.usuario_inclusao = UsuarioLogado.nome;
                _Livro_CaixaRepositorio.Adicionar(Livro_Caixa);
                _Livro_CaixaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Livro_Caixa Localizar(long? id)
        {
            try
            {
                return _Livro_CaixaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public virtual void ExcluirLivro_Caixa(Livro_Caixa Livro_Caixa)
        {
            try
            {
                _Livro_CaixaRepositorio.Deletar(c => c == Livro_Caixa);
                _Livro_CaixaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarLivro_Caixa(Livro_Caixa Livro_Caixa)
        {
            try
            {
                Livro_Caixa.alteracao = DateTime.Now;
                Livro_Caixa.usuario_alteracao = UsuarioLogado.nome;
                _Livro_CaixaRepositorio.Atualizar(Livro_Caixa);
                _Livro_CaixaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Livro_CaixaRepositorio != null)
            {
                _Livro_CaixaRepositorio.Dispose();
            }

        }
    }
}
