using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Shared.Constant.Permission
{
    public static class PositionTypes
    {
        public const int Admin = 1;
        public const int Rector = 2;          // Hiệu trưởng
        public const int ViceRector = 3;      // Phó Hiệu trưởng
        public const int Dean = 4;            // Trưởng khoa
        public const int DepartmentHead = 5;  // Trưởng phòng
        public const int Staff = 6;           // Nhân viên

        public static Dictionary<int, string> Position = new Dictionary<int, string>()
        {
            { Admin, "Admin" },
            { Rector, "Hiệu trưởng" },
            { ViceRector, "Phó Hiệu trưởng" },
            { Dean, "Trưởng khoa" },
            { DepartmentHead, "Trưởng phòng" },
            { Staff, "Nhân viên" }
        };
    };

   
}
