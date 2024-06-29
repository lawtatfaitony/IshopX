using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AspNetUserRolesRole = new HashSet<AspNetUserRoles>();
            AspNetUserRolesRoleId1Navigation = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Discriminator { get; set; }

        public virtual ICollection<AspNetUserRoles> AspNetUserRolesRole { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRolesRoleId1Navigation { get; set; }
    }
}
