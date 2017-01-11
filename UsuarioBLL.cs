using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class UsuarioBLL
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

        public virtual void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.Adicionar(usuario);
                _usuarioRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public virtual Usuario Localizar(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _usuarioRepositorio.Find(id);
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
                _usuarioRepositorio.Atualizar(usuario);
                _usuarioRepositorio.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }
    }
}
