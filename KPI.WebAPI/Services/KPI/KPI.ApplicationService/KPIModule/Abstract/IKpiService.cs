using KPI.ApplicationService.KPIModule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.ApplicationService.KPIModule.Abstract
{
    public interface IKpiService
    {
        //KPI TEMPLATE
        Task<List<KpiTemplateDto>> GetAllAsync();
        Task<KpiTemplateDto?> GetByIdAsync(int id);
        Task<KpiTemplateDto> CreateAsync(CreateKpiTemplateDto dto);









        //KPI ITEM
        //Lấy toàn bộ KPI items trong hệ thống.
        Task<List<KpiItemDto>> GetAllItemsAsync();
        //Lấy chi tiết KPI item theo Id.
        Task<KpiItemDto?> GetItemByIdAsync(int id);
        //Tạo mới một KPI item gắn với người dùng tạo.
        Task<KpiItemDto> CreateItemAsync(CreateKpiItemDto dto, int userId);
        //Cập nhật thông tin KPI item theo Id.
        Task<KpiItemDto> UpdateItemAsync(int id, UpdateKpiItemDto dto, int userId);
        //Đánh dấu xóa mềm KPI item (Deleted = true).
        Task<bool> DeleteItemAsync(int id, int userId);
        //Lấy danh sách KPI items mà chính user đã tạo.
        Task<List<KpiItemDto>> GetItemsByCreatorAsync(int userId);

    }
}
