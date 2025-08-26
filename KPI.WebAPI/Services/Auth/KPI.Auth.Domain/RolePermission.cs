using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPI.Auth.Domain
{
    [Table("RolePermissions")]
    public class RolePermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoleId { get; set; }

        [Required, MaxLength(128)]
        public string PermissionKey { get; set; } = null!;

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
    }
}
