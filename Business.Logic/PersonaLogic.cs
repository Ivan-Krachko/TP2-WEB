using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private Data.Database.PersonaAdapter _PersonaData;

        public Data.Database.PersonaAdapter PersonaData
        {
            get
            {
                return _PersonaData;
            }
            set
            {
                _PersonaData = value;
            }
        }

        public PersonaLogic()
        {
            PersonaData = new Data.Database.PersonaAdapter();
            //creamos una instancia de PersonaAdapter y la asignamos a una variable/atributo de tipo PersonaAdapter.
        }
        public Business.Entities.Persona GetOne(int id)
        {
            return PersonaData.GetOne(id);
        }

        public List<Business.Entities.Persona> GetAll()
        {
            return PersonaData.GetAll();

        }

        public void Save(Business.Entities.Persona perso)
        {
            PersonaData.Save(perso);
        }

        public void Delete(int id)
        {
            PersonaData.Delete(id);
        }

        public List<Business.Entities.Persona> RecuperarPorfesores()
        {
            return PersonaData.RecuperarProfesores();
        }
    }
}
