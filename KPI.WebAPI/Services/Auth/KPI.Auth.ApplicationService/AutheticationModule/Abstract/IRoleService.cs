using KPI.Auth.ApplicationService.AutheticationModule.Dtos.RoleDto;
using KPI.Shared.Constant.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Auth.ApplicationService.AutheticationModule.Abstract
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllRole(FilterDto input);
        Task<RoleDto> CreateRole(CreateRoleDto dto);
        Task<RoleDto?> GetRoleById(int roleId);
        Task<RolePermissionDto> GetRolePermission(int roleId);
        Task<IEnumerable<string>> GetAllPermission();
        Task AssignPermissionToRole(int roleId, string roleName, IEnumerable<string> permissionKeys);
        Task RemovePermissionFromRole(int roleId, IEnumerable<string> permissionKeysToRemove);
        Task DeleteRole(int roleId);
    }
}
