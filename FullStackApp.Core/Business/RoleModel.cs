using FullStackApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Core.Business
{
    public class RoleModel : Model
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string RoleName { get; set; }

        public virtual UserModel User { get; set; }
        public ICollection<PermissionModel> Permissions { get; set; } = new List<PermissionModel>();
        public virtual ICollection<EmployeeModel> employees { get; set; }

        public RoleModel()
        {
            new UserModel();
            new HashSet<EmployeeModel>();
        }

        public RoleModel(Role role)
        {
            this.Assign(role);
            User = new UserModel();
            employees = new HashSet<EmployeeModel>();

        }
        public Role CreateRole(RoleModel model)
        {
            return new Role()
            {
                UserId = model.UserId,
                RoleName = model.RoleName
            };
        }

        public Role Edit(Role entity, RoleModel model)
        {
            entity.RoleId = model.RoleId; 
            entity.RoleName = model.RoleName;
            entity.UserId = model.UserId;

            return entity;
        }
    }
}
