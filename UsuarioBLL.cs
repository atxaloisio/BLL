using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using Utils; 


namespace BLL
{
    public class UsuarioBLL : BaseBLL, IDisposable
    {
        IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioBLL()
        {
            try
            {
                _usuarioRepositorio = new UsuarioRepositorio();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public virtual List<Usuario> getUsuario(int Id = -1)
        {
            try
            {
                if (Id == -1)
                {
                    return _usuarioRepositorio.GetTodos().ToList();
                }
                else
                {                    
                    return _usuarioRepositorio.Get(p => p.Id == Id).ToList();                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public virtual List<Usuario> getUsuario(Expression<Func<Usuario, string>> ordem, bool desc, int page, int pageSize,out int totalRecords)
        {
            try
            {
                totalRecords = _usuarioRepositorio.getTotalRegistros();                    
                return _usuarioRepositorio.GetTodos(ordem,desc,page,pageSize).ToList();                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Usuario> getUsuario(Expression<Func<Usuario, bool>> predicate, Expression<Func<Usuario, string>> ordem, bool desc, int page, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = _usuarioRepositorio.getTotalRegistros(predicate);
                return _usuarioRepositorio.Get(predicate, ordem, desc, page, pageSize).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Usuario> getUsuario(Expression<Func<Usuario, bool>> predicate, bool desc, int page, int pageSize, out int totalRecords, params Expression<Func<Usuario, string>>[] ordem)
        {
            try
            {
                totalRecords = _usuarioRepositorio.getTotalRegistros(predicate);
                return _usuarioRepositorio.Get(predicate, desc, page, pageSize, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<Usuario> getUsuario(Expression<Func<Usuario, bool>> predicate, bool desc, int page, params Expression<Func<Usuario, string>>[] ordem)
        {
            try
            {         
                return _usuarioRepositorio.Get(predicate, desc, ordem).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public virtual List<Usuario> getUsuario(Expression<Func<Usuario, bool>> predicate)
        {
            try
            {
                return _usuarioRepositorio.Get(predicate).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual List<UsuarioView> ToList_UsuarioView(List<Usuario> lst)
        {
            List<UsuarioView> lstRetorno = new List<UsuarioView>();

            foreach (Usuario item in lst)
            {
                if (item != null)
                {
                    lstRetorno.Add(new UsuarioView()
                    {
                        Id = item.Id,
                        nome = item.nome,
                        email = item.email,
                        perfil = item.perfil.nome,
                        inativo = item.inativo == "S"
                    });
                }

            }

            return lstRetorno;

        }

        public virtual void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                usuario.inclusao = DateTime.Now;
                _usuarioRepositorio.Adicionar(usuario);
                _usuarioRepositorio.Commit();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public virtual Usuario Localizar(long? id)
        {
            try
            {
                return _usuarioRepositorio.Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public virtual Usuario loginSistema(string email, string password)
        {            
            Usuario usuario = new Usuario();
            usuario.email = email;
            usuario.password = Crypto.Codificar(password);
            try
            {
                return _usuarioRepositorio.GetUsuarioPorLoginSenha(usuario);                
            }
            catch (Exception)
            {
                throw;                
            }           
        }

        public virtual void ExcluirUsuario(Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.Deletar(c => c == usuario);
                _usuarioRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        public virtual void AlterarUsuario(Usuario usuario)
        {
            try
            {
                usuario.alteracao = DateTime.Now;
                _usuarioRepositorio.Atualizar(usuario);
                _usuarioRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        public void Dispose()
        {
            if (_usuarioRepositorio != null)
            {
                _usuarioRepositorio.Dispose();
            }
            
        }
    }
}
