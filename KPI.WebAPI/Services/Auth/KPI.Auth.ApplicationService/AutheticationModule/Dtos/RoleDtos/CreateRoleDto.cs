using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Auth.ApplicationService.AutheticationModule.Dtos.RoleDto
{
    public class CreateRoleDto
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int UserType { get; set; }

    }
}
