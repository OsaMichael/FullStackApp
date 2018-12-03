using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Infrastructure.Entities
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public int PermissionName { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();

    }
}
