using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private Data.Database.UsuarioAdapter _usuarioData;
        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _usuarioData; }
            set { _usuarioData = value; }
        }
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public Business.Entities.Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();

        }

        public void Save(Business.Entities.Usuario User)
        {
            UsuarioData.Save(User);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public Persona BuscaPersonaxNombApeEm(string nombre, string apellido, string mail)
        {
            return UsuarioData.BuscaPersonaxNombApeEm(nombre, apellido, mail);
        }

        public void CargarIDPersona(string nombreUser, string apellidoUser, string emailUser, int idPersona)
        {
            UsuarioData.CargarIDPersona(nombreUser, apellidoUser, emailUser, idPersona);
        }

        public Persona BuscaPersona(int idUsuario)
        {
            return UsuarioData.BuscarPersona(idUsuario);
        }

        public void ActualizarPersona(string nombreUsuario, string apellidoUsuario, string email, int idPersona)
        {
            UsuarioData.ActualizarPersona(nombreUsuario, apellidoUsuario, email, idPersona);
        }
    }
}
