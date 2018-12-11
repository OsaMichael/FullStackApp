using FullStackApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Core.Business
{
    public class EmployeeModel : Model
    {
        [Key]
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
 
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

        public virtual RoleModel Role { get; set; }
        public virtual UserModel User { get; set; }
        public EmployeeModel()
        {
            new RoleModel();
            new UserModel();
        }
        public EmployeeModel(Employee employee)
        {
            this.Assign(employee);
            Role = new RoleModel();
            User = new UserModel();
        }

        public Employee Create(EmployeeModel model)
        {
            return new Employee
            {
                RoleId =(int) model.RoleId,
                UserId = model.UserId,
                Name = model.Name,
      
                Department = model.Department,
                Position = model.Position,
                NextOfSkin = model.NextOfSkin,
                DateEmployed = model.DateEmployed,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy

            };
        }
        public Employee Edit(Employee entity, EmployeeModel model)
        {
            entity.RoleId = (int)model.RoleId;
            entity.UserId = model.UserId;
            entity.EmployeeId = model.EmployeeId;
            entity.Name = model.Name;
   
            entity.Department = model.Department;
            entity.Position = model.Position;
            entity.DateEmployed = model.DateEmployed;
            entity.Address = model.Address;        
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = model.ModifiedBy;

            return entity;

        }
    }
}
