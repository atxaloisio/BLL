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
    public class ItemPedido_OticaBLL : BaseBLL, IDisposable
    {
        IItemPedido_OticaRepositorio _ItemPedido_OticaRepositorio;
        public ItemPedido_OticaBLL()
        {
            try
            {
                _ItemPedido_OticaRepositorio = new ItemPedido_OticaRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<ItemPedido_Otica> getItemPedido_Otica(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _ItemPedido_OticaRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _ItemPedido_OticaRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<ItemPedido_Otica> getItemPedido_Otica(Expression<Func<ItemPedido_Otica, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ItemPedido_OticaRepositorio.getTotalRegistros();
                return _ItemPedido_OticaRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<ItemPedido_Otica> getItemPedido_Otica(Expression<Func<ItemPedido_Otica, bool>> predicate, Expression<Func<ItemPedido_Otica, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _ItemPedido_OticaRepositorio.getTotalRegistros(predicate);
                return _ItemPedido_OticaRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<ItemPedido_Otica> getItemPedido_Otica(Expression<Func<ItemPedido_Otica, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<ItemPedido_Otica, string>>[] ordem)
        {
            try
            {
                totalRecords = _ItemPedido_OticaRepositorio.getTotalRegistros(predicate);
                return _ItemPedido_OticaRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<ItemPedido_Otica> getItemPedido_Otica(Expression<Func<ItemPedido_Otica, bool>> predicate, bool desc, params Expression<Func<ItemPedido_Otica, string>>[] ordem)
        {
            try
            {        
                return _ItemPedido_OticaRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<ItemPedido_Otica> getItemPedido_Otica(Expression<Func<ItemPedido_Otica, bool>> predicate)
        {
            try
            {
                return _ItemPedido_OticaRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarItemPedido_Otica(ItemPedido_Otica ItemPedido_Otica)
        {
            try
            {
                _ItemPedido_OticaRepositorio.Adicionar(ItemPedido_Otica);
                _ItemPedido_OticaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual ItemPedido_Otica Localizar(long? id)
        {
            try
            {
                return _ItemPedido_OticaRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirItemPedido_Otica(ItemPedido_Otica ItemPedido_Otica)
        {
            try
            {
                _ItemPedido_OticaRepositorio.Deletar(c => c == ItemPedido_Otica);
                _ItemPedido_OticaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public virtual void AlterarItemPedido_Otica(ItemPedido_Otica ItemPedido_Otica)
        {
            try
            {
                _ItemPedido_OticaRepositorio.Atualizar(ItemPedido_Otica);
                _ItemPedido_OticaRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_ItemPedido_OticaRepositorio != null)
            {
                _ItemPedido_OticaRepositorio.Dispose();
            }

        }
    }
}
