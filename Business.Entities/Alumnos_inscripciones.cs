using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Alumnos_Inscripciones : BusinessEntity
    {
        public int Id_inscripcion { get; set; }

        public int Id_alumno { get; set; }

        public int Id_curso { get; set; }

        public string Condicion { get; set; }

        public int Nota { get; set; }
    }
}
