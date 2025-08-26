using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Domain
{
    public class KPIDefinition
    {
        public int Id { get; set; }
        public string KpiName { get; set; } // Ví dụ: Tổng số giờ giảng dạy
        public string KpiCategory { get; set; } // Loại: Giờ chuẩn, NCKH, Khác
        public string AppliesTo { get; set; } // Áp dụng cho: Giảng viên, Chuyên viên
        public decimal? DefaultWeight { get; set; }
        public decimal? DefaultTarget { get; set; }
    }
}
