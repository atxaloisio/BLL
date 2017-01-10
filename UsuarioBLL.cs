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
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public virtual List<Usuario> getUsuario(int Id = -1)
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

        public virtual void AdicionarUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Adicionar(usuario);
            _usuarioRepositorio.Commit();
        }

        public virtual Usuario Localizar(int id)
        {
            return _usuarioRepositorio.Find(id);
        }

        public virtual void ExcluirUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Deletar(c => c == usuario);
            _usuarioRepositorio.Commit();
        }

        public virtual void AlterarUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Atualizar(usuario);
            _usuarioRepositorio.Commit();
        }
    }
}
