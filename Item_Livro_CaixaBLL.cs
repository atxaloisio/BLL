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
    public class Item_Livro_CaixaBLL : BaseBLL, IDisposable
    {
        IItem_Livro_CaixaRepositorio _Item_Livro_CaixaRepositorio;
        public Item_Livro_CaixaBLL()
        {
            try
            {
                _Item_Livro_CaixaRepositorio = new Item_Livro_CaixaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Item_Livro_Caixa> getItem_Livro_Caixa(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Item_Livro_CaixaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Item_Livro_CaixaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Item_Livro_Caixa> getItem_Livro_Caixa(Expression<Func<Item_Livro_Caixa, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Item_Livro_CaixaRepositorio.getTotalRegistros();
                return _Item_Livro_CaixaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Item_Livro_Caixa> getItem_Livro_Caixa(Expression<Func<Item_Livro_Caixa, bool>> predicate, Expression<Func<Item_Livro_Caixa, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Item_Livro_CaixaRepositorio.getTotalRegistros(predicate);
                return _Item_Livro_CaixaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Item_Livro_Caixa> getItem_Livro_Caixa(Expression<Func<Item_Livro_Caixa, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Item_Livro_Caixa, string>>[] ordem)
        {
            try
            {
                totalRecords = _Item_Livro_CaixaRepositorio.getTotalRegistros(predicate);
                return _Item_Livro_CaixaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Item_Livro_Caixa> getItem_Livro_Caixa(Expression<Func<Item_Livro_Caixa, bool>> predicate, bool desc, params Expression<Func<Item_Livro_Caixa, string>>[] ordem)
        {
            try
            {

                return _Item_Livro_CaixaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Item_Livro_Caixa> getItem_Livro_Caixa(Expression<Func<Item_Livro_Caixa, bool>> predicate, bool NoTracking = false)
        {
            try
            {
                if (NoTracking)
                {
                    return _Item_Livro_CaixaRepositorio.GetNT(predicate).ToList();
                }
                else
                {
                    return _Item_Livro_CaixaRepositorio.Get(predicate).ToList();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Item_Livro_CaixaView> ToList_Item_Livro_CaixaView(List<Item_Livro_Caixa> lst)
        {
            List<Item_Livro_CaixaView> lstRetorno = new List<Item_Livro_CaixaView>();

            foreach (Item_Livro_Caixa item in lst)
            {
                lstRetorno.Add(new Item_Livro_CaixaView
                {
                    Id = item.Id,
                    Id_livro = item.Id_livro,
                    descricao = item.descricao,
                    documento = item.documento,
                    usuario_inclusao = item.usuario_inclusao,
                    valor = item.valor,
                    tipo = item.tipo == "E"? "Entrada" : "Saida" 
                });

            }

            return lstRetorno;

        }

        public virtual List<Item_Livro_CaixaView> ToList_Item_Livro_CaixaView(ICollection<Item_Livro_Caixa> lst)
        {
            List<Item_Livro_CaixaView> lstRetorno = new List<Item_Livro_CaixaView>();

            foreach (Item_Livro_Caixa item in lst)
            {
                lstRetorno.Add(new Item_Livro_CaixaView
                {
                    Id = item.Id,
                    Id_livro = item.Id_livro,
                    descricao = item.descricao,
                    documento = item.documento,
                    usuario_inclusao = item.usuario_inclusao,
                    valor = item.valor,
                    tipo = item.tipo == "E" ? "Entrada" : "Saida"
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarItem_Livro_Caixa(Item_Livro_Caixa Item_Livro_Caixa)
        {
            try
            {
                _Item_Livro_CaixaRepositorio.Adicionar(Item_Livro_Caixa);
                _Item_Livro_CaixaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Item_Livro_Caixa Localizar(long? id)
        {
            try
            {
                return _Item_Livro_CaixaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirItem_Livro_Caixa(Item_Livro_Caixa Item_Livro_Caixa)
        {
            try
            {
                _Item_Livro_CaixaRepositorio.Deletar(c => c == Item_Livro_Caixa);
                _Item_Livro_CaixaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarItem_Livro_Caixa(Item_Livro_Caixa Item_Livro_Caixa)
        {
            try
            {
                _Item_Livro_CaixaRepositorio.Atualizar(Item_Livro_Caixa);
                _Item_Livro_CaixaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Item_Livro_CaixaRepositorio != null)
            {
                _Item_Livro_CaixaRepositorio.Dispose();
            }

        }

        public static void IncluirLancamento(Item_Livro_Caixa pItem_Livro_Caixa, Usuario usuario)
        {
            //Obter o lançamento aberto
            Item_Livro_CaixaBLL ilcBLL = new Item_Livro_CaixaBLL();
            try
            {
                ilcBLL.UsuarioLogado = usuario;
                ilcBLL.AdicionarItem_Livro_Caixa(pItem_Livro_Caixa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static void ExcluirLancamento(Item_Livro_Caixa pItem_Livro_Caixa, Usuario usuario)
        {
            //Obter o lançamento aberto
            Item_Livro_CaixaBLL ilcBLL = new Item_Livro_CaixaBLL();
            try
            {
                ilcBLL.UsuarioLogado = usuario;
                ilcBLL.ExcluirItem_Livro_Caixa(pItem_Livro_Caixa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
