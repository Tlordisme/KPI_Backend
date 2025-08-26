using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Shared.Constant.Common
{
    public class PageResult<T>
    {
        public IEnumerable<T>? Item { get; set; }
        public int TotalItem { get; set; }
    }
}
