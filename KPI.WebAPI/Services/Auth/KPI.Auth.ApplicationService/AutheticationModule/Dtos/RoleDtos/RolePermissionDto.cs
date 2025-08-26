

namespace KPI.Auth.ApplicationService.AutheticationModule.Dtos.RoleDto
{
    public class RolePermissionDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public IEnumerable<string> Permissions { get; set; } = Enumerable.Empty<string>();
    }
}
