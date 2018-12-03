using FullStackApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Core.Business
{
    public class EmployeeModel : Model
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string DateEmployed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string NextOfSkin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }


        public EmployeeModel()
        {

        }
        public EmployeeModel(Employee employee)
        {
            this.Assign(employee);
        }

        public Employee Create(EmployeeModel model)
        {
            return new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Department = model.Department,
                Position = model.Position,
                DateEmployed = model.DateEmployed,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy

            };
        }
        public Employee Edit(Employee entity, EmployeeModel model)
        {
            entity.EmployeeId = model.EmployeeId;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Department = model.Department;
            entity.Position = model.Position;
            entity.DateEmployed = model.DateEmployed;
            entity.Address = model.Address;
            entity.DateOfBirth = model.DateOfBirth;
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = model.ModifiedBy;

            return entity;

        }
    }
}
