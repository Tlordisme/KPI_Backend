using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Auth.ApplicationService.AutheticationModule.Dtos.UserDto
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string[]? Permissions { get; set; }

    }
}
