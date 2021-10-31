using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanesAdapter _planData;
        public PlanesAdapter PlanData
        {
            get { return _planData; }
            set { _planData = value; }
        }
        public PlanLogic()
        {
            PlanData = new PlanesAdapter();
        }

        public Business.Entities.Plan GetOne(int id)
        {
            return PlanData.GetOne(id);
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();

        }

        public void Save(Plan p)
        {
            PlanData.Save(p);
        }

        public void Delete(int id)
        {
            PlanData.Delete(id);
        }
    }
}
