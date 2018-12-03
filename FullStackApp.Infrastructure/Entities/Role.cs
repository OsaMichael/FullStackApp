﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Infrastructure.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new HashSet<RolePermission>();

    }
}
