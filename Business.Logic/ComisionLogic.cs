using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;


namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private Data.Database.ComisionAdapter _ComisionData;

        public Data.Database.ComisionAdapter ComisionData
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }
        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter(); //inicializo la prop ComisionData (de tipo ComisionAdapter) con una instancia de ComisionAdapter aca...osea dentro del constructor sin parametros.
        }

        public Business.Entities.Comision GetOne(int id)
        {
            return ComisionData.GetOne(id);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();

        }

        public void Save(Business.Entities.Comision comi)
        {
            ComisionData.Save(comi);
        }

        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }





    }
}
