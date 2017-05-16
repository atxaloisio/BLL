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
    public class Tipo_ArmacaoBLL : BaseBLL, IDisposable
    {
        ITipo_ArmacaoRepositorio _Tipo_ArmacaoRepositorio;
        public Tipo_ArmacaoBLL()
        {
            try
            {
                _Tipo_ArmacaoRepositorio = new Tipo_ArmacaoRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Armacao> getTipo_Armacao(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _Tipo_ArmacaoRepositorio.GetTodos().ToList();
                }
                else
                {
                    return _Tipo_ArmacaoRepositorio.Get(p => p.Id == Id).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Armacao> getTipo_Armacao(Expression<Func<Tipo_Armacao, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Tipo_ArmacaoRepositorio.getTotalRegistros();
                return _Tipo_ArmacaoRepositorio.GetTodos(ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Armacao> getTipo_Armacao(Expression<Func<Tipo_Armacao, bool>> predicate, Expression<Func<Tipo_Armacao, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _Tipo_ArmacaoRepositorio.getTotalRegistros(predicate);
                return _Tipo_ArmacaoRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Armacao> getTipo_Armacao(Expression<Func<Tipo_Armacao, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Tipo_Armacao, string>>[] ordem)
        {
            try
            {
                totalRecords = _Tipo_ArmacaoRepositorio.getTotalRegistros(predicate);
                return _Tipo_ArmacaoRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Armacao> getTipo_Armacao(Expression<Func<Tipo_Armacao, bool>> predicate, bool desc, params Expression<Func<Tipo_Armacao, string>>[] ordem)
        {
            try
            {

                return _Tipo_ArmacaoRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_Armacao> getTipo_Armacao(Expression<Func<Tipo_Armacao, bool>> predicate)
        {
            try
            {
                return _Tipo_ArmacaoRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Tipo_ArmacaoView> ToList_Tipo_ArmacaoView(List<Tipo_Armacao> lst)
        {
            List<Tipo_ArmacaoView> lstRetorno = new List<Tipo_ArmacaoView>();

            foreach (Tipo_Armacao item in lst)
            {
                lstRetorno.Add(new Tipo_ArmacaoView
                {
                    Id = item.Id,
                    descricao = item.descricao,
                    inativo = item.inativo == "S"
                });
            }

            return lstRetorno;

        }

        public virtual void AdicionarTipo_Armacao(Tipo_Armacao Tipo_Armacao)
        {
            try
            {
                _Tipo_ArmacaoRepositorio.Adicionar(Tipo_Armacao);
                _Tipo_ArmacaoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual Tipo_Armacao Localizar(long? id)
        {
            try
            {
                return _Tipo_ArmacaoRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void ExcluirTipo_Armacao(Tipo_Armacao Tipo_Armacao)
        {
            try
            {
                _Tipo_ArmacaoRepositorio.Deletar(c => c == Tipo_Armacao);
                _Tipo_ArmacaoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void AlterarTipo_Armacao(Tipo_Armacao Tipo_Armacao)
        {
            try
            {
                _Tipo_ArmacaoRepositorio.Atualizar(Tipo_Armacao);
                _Tipo_ArmacaoRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            if (_Tipo_ArmacaoRepositorio != null)
            {
                _Tipo_ArmacaoRepositorio.Dispose();
            }

        }
    }
}
