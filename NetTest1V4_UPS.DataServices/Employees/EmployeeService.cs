using NetTest1V4_UPS.DataServices.Base;
using NetTest1V4_UPS.DataServices.Exceptions;
using NetTest1V4_UPS.Models;
using System;
using System.Threading.Tasks;

namespace NetTest1V4_UPS.DataServices.Employees
{
    public class EmployeeService : DataService<Employee>, IEmployeeService
    {
        public EmployeeService(ServiceAdapter serviceAdapter)
            : base(serviceAdapter)
        {

        }

        protected override string getResourceName()
        {
            return "users";
        }

        public override Task<CreateResult> Create(Employee model)
        {
            if (model.Gender != "male" && model.Gender != "female")
                throw new InvalidGenderException();

            return base.Create(model);
        }

        public override void Edit(Employee model)
        {
            if (model.Id == 0)
                throw new ArgumentOutOfRangeException();

            base.Edit(model);
        }

        public override Task<RemoveResult> Remove(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException();

            return base.Remove(id);
        }
    }
}