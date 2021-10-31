using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        public DocenteCursoAdapter docenteCursoData { get; set; }

        public DocenteCursoLogic()
        {
            docenteCursoData = new DocenteCursoAdapter();
        }

        public DocenteCurso GetOne(int id)
        {
            return docenteCursoData.GetOne(id);
        }

        public List<DocenteCurso> GetAll()
        {
            return docenteCursoData.GetAll();
        }

        public void Save(DocenteCurso dc)
        {
            docenteCursoData.Save(dc);
        }

        public void Delete(int id)
        {
            docenteCursoData.Delete(id);
        }


        public Curso BuscarCurso(int idMateria, int idComision)
        {
            return docenteCursoData.BuscarCurso(idMateria, idComision);
        }
    }
}
