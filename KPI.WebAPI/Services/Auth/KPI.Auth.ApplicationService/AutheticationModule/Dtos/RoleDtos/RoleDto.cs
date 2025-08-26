using KPI.Auth.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Auth.ApplicationService.AutheticationModule.Dtos.RoleDto
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public IEnumerable<string> Permissions { get; set; } = Enumerable.Empty<string>();


    }
}
