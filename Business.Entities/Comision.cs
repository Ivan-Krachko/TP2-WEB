using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        private string _descComision;
        private int _anioEspecialidad;

        public string DescComision
        {
            get
            {
                return _descComision;
            }
            set
            {
                _descComision = value;
            }
        }
        public int AnioEspecialidad
        {
            get
            {
                return _anioEspecialidad;
            }
            set
            {
                _anioEspecialidad = value;
            }
        }
        public int IdPlan { get; set; }

    }
}
