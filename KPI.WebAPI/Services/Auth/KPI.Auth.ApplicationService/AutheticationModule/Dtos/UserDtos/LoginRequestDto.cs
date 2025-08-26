using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Auth.ApplicationService.AutheticationModule.Dtos.RoleDto
{
    public class LoginRequestDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
