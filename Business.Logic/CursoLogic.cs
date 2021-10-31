using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {

        public CursoAdapter CursoData { get; set; }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public Business.Entities.Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();

        }

        public void Save(Curso cur)
        {
            CursoData.Save(cur);
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }
    }
}
