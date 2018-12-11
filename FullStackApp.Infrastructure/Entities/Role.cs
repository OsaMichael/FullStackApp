using FullStackApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Infrastructure.Entities
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();
        public ICollection<Employee> Employees { get; set; } 


        public Role()
        {
            this.Employees = new HashSet<Employee>();
        }
    }
}
