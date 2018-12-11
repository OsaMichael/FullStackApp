using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Infrastructure.Entities
{
    public partial class Employee
    {
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

        public virtual Role Role { get; set; }

        
       
    }
}
