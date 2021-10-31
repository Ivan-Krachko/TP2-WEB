using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        public string DescPlan { get; set; }

        public int IDEspecialidad { get; set; }
    }
}
