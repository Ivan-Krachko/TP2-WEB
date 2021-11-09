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

        public Business.Entities.Persona BuscarPersona(int id)
        {
            return UsuarioData.BuscarPersona(id);
        }
    }
}
