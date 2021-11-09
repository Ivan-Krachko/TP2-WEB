using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private MateriasAdapter _materiaData;
        public MateriasAdapter MateriaData
        {
            get { return _materiaData; }
            set { _materiaData = value; }
        }
        public MateriaLogic()
        {
            MateriaData = new MateriasAdapter();
        }

        public Business.Entities.Materia GetOne(int id)
        {
            return MateriaData.GetOne(id);
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();

        }

        public void Save(Materia mat)
        {
            MateriaData.Save(mat);
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }

        public List<Materia> BuscarMateriaxPersona(int id)
        {
            return MateriaData.BuscarMateriaxPersona(id);
        }
    }
}
