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
    public class TagBLL : BaseBLL, IDisposable
    {
        ITagRepositorio _TagRepositorio;
        public TagBLL()
        {
            try
            {
                _TagRepositorio = new TagRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tag> getTag(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _TagRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _TagRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tag> getTag(string ptag)
        {
            try
            {
                return _TagRepositorio.GetNT(p => p.tag1.Contains(ptag)).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tag> getTag(Expression<Func<Tag, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _TagRepositorio.getTotalRegistros();
                return _TagRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tag> getTag(Expression<Func<Tag, bool>> predicate, Expression<Func<Tag, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _TagRepositorio.getTotalRegistros(predicate);
                return _TagRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tag> getTag(Expression<Func<Tag, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Tag, string>>[] ordem)
        {
            try
            {
                totalRecords = _TagRepositorio.getTotalRegistros(predicate);
                return _TagRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tag> getTag(Expression<Func<Tag, bool>> predicate, bool desc, params Expression<Func<Tag, string>>[] ordem)
        {
            try
            {
                
                return _TagRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void AdicionarTag(Tag Tag)
        {
            try
            {
                Tag.inclusao = DateTime.Now;
                _TagRepositorio.Adicionar(Tag);
                _TagRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Tag Localizar(long? id)
        {
            try
            {
                return _TagRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirTag(Tag Tag)
        {
            try
            {
                _TagRepositorio.Deletar(c => c == Tag);
                _TagRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarTag(Tag Tag)
        {
            try
            {
                Tag.alteracao = DateTime.Now;
                _TagRepositorio.Atualizar(Tag);
                _TagRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_TagRepositorio != null)
            {
                _TagRepositorio.Dispose();
            }

        }
    }
}
