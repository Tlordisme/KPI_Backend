using KPI.Auth.ApplicationService.AutheticationModule.Abstract;
using KPI.Auth.ApplicationService.AutheticationModule.Dtos.RoleDto;
using KPI.Auth.Domain;
using KPI.Auth.Infrastructure;
using KPI.Shared.Constant.Common;
using KPI.Shared.Constant.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Auth.ApplicationService.AutheticationModule.Implements
{
    public class RoleService : IRoleService
    {
        private readonly AuthDbContext _context;
        public RoleService(AuthDbContext context) 
        { 
            _context = context;
        }
        public async Task< RoleDto> CreateRole (CreateRoleDto dto)
        {
            var role = new Domain.Role
            {
                Name = dto.RoleName,
                UserType = dto.UserType,
                Description = dto.Description,
                

            };
            _context.Add(role);
            await _context.SaveChangesAsync();


            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                Permissions = Enumerable.Empty<string>(),
                Status = role.Status,
            };

        }
        public async Task<List<RoleDto>> GetAllRole(FilterDto input)
        {
            var query = _context.Roles.AsQueryable();

            // Lọc theo keyword
            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(r =>
                    r.Name.ToLower().Contains(input.Keyword.ToLower()) ||
                    r.Description.ToLower().Contains(input.Keyword.ToLower()));
            }

            var roles = await query
            .OrderBy(r => r.Id)
            .Skip(input.SkipCount())
            .Take(input.PageSize)
            .ToListAsync();

            // Lấy permission
            var roleIds = roles.Select(r => r.Id).ToList();
            var permissionsDict = await _context.RolePermissions
                .Where(rp => roleIds.Contains(rp.RoleId))
                .GroupBy(rp => rp.RoleId)
                .ToDictionaryAsync(g => g.Key, g => g.Select(p => p.PermissionKey).ToList());

            return roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Status = r.Status,
                Permissions = permissionsDict.GetValueOrDefault(r.Id) ?? new List<string>()
            }).ToList();

        }
        public async Task<RoleDto?> GetRoleById(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null) return null;

            return new RoleDto
            {
                Id = role.Id,
                Description = role.Description,
                Status = role.Status,
                Name = role.Name,
                
                
            };
        }

        public Task<IEnumerable<string>> GetAllPermission()
        {
            var keys = typeof(PermissionKeys).GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(string))
                .Select(f => (string)f.GetValue(null)!)
                .ToList()
                .AsEnumerable();
            return Task.FromResult(keys);
        }
        public async Task AssignPermissionToRole(int roleId, string roleName, IEnumerable<string> permissionKeys)
        {
            if (roleId <= 0)
                throw new ArgumentException("RoleId không hợp lệ.");

            if (permissionKeys == null || !permissionKeys.Any())
                throw new ArgumentException("Danh sách permission không hợp lệ.");

            var roleExists = await _context.Roles.AnyAsync(r => r.Id == roleId && r.Name == roleName);
            if (!roleExists)
                throw new InvalidOperationException($"RoleId {roleId} với RoleName '{roleName}' không tồn tại trong hệ thống.");

            // Xóa permission cũ
            var existingPermissions = _context.RolePermissions.Where(rp => rp.RoleId == roleId);
            _context.RolePermissions.RemoveRange(existingPermissions);

            // Thêm permission mới
            var newPermissions = permissionKeys.Select(p => new RolePermission
            {
                RoleId = roleId,
                PermissionKey = p
            });

            await _context.RolePermissions.AddRangeAsync(newPermissions);
            await _context.SaveChangesAsync();
        }


        public async Task RemovePermissionFromRole(int roleId, IEnumerable<string> permissionKeysToRemove)
        {
            if (roleId <= 0)
                throw new ArgumentException("RoleId không hợp lệ.");

            if (permissionKeysToRemove == null || !permissionKeysToRemove.Any())
                throw new ArgumentException("Danh sách permission cần xóa không hợp lệ.");

            // Lấy các permission cần xóa 
            var existingPermissions = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId && permissionKeysToRemove.Contains(rp.PermissionKey))
                .ToListAsync();

            if (!existingPermissions.Any())
                throw new InvalidOperationException($"Role {roleId} không có permission nào trong danh sách cần xóa.");

            _context.RolePermissions.RemoveRange(existingPermissions);
            await _context.SaveChangesAsync();
        }



        public async Task<RolePermissionDto> GetRolePermission(int roleId)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            if (role == null)
                throw new InvalidOperationException($"RoleId {roleId} không tồn tại.");

            var permissions = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => new PermissionDetailDto
                {
                    Key = rp.PermissionKey,
                    Label = rp.PermissionKey
                })
                .ToListAsync();

            return new RolePermissionDto
            {
                RoleId = roleId,
                RoleName = role.Name,
                Permissions = permissions.Select(p => p.Key)
            };
        }
        public async Task DeleteRole(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null)
            {
                throw new InvalidOperationException("Role không tồn tại, không thể xoá.");
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }






    }
}
