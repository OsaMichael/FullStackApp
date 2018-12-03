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
        public string Name { get; set; }
        public ICollection<PermissionModel> Permissions { get; set; } = new List<PermissionModel>();

        public RoleModel()
        {

        }

        public RoleModel(Role role)
        {
            this.Assign(role);

        }
        public Role CreateRole(RoleModel model)
        {
            return new Role()
            {
                Name = Name
            };
        }

        public Role Edit(Role entity, RoleModel model)
        {
            entity.RoleId = model.RoleId; 
            entity.Name = model.Name;

            return entity;
        }
    }
}
