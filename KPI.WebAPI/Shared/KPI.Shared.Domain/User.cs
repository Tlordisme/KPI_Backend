using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Shared.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public int UnitId { get; set; }
        public string Position { get; set; }
        public string Role { get; set; }
    }
}
