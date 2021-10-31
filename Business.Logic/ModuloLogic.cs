using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        private ModuloAdapter _moduloData;
        public ModuloAdapter ModuloData
        {
            get { return _moduloData; }
            set { _moduloData = value; }
        }
        public ModuloLogic()
        {
            ModuloData = new ModuloAdapter();
        }

        public Business.Entities.Modulo GetOne(int id)
        {
            return ModuloData.GetOne(id);
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();

        }

        public void Save(Modulo mat)
        {
            ModuloData.Save(mat);
        }

        public void Delete(int id)
        {
            ModuloData.Delete(id);
        }
    }
}
