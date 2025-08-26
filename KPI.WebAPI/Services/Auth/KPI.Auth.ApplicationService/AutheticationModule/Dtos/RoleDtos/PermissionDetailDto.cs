using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Auth.ApplicationService.AutheticationModule.Dtos.RoleDto
{
    public class PermissionDetailDto
    {
        public string Key { get; set; } = null!;
        public string? ParentKey { get; set; }
        public string? Label { get; set; }
        public string? Icon { get; set; }
    }
}
