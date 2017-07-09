using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Shared.DTO
{
    [AuditEntity]
    [Table("tblUser")]
    public class UserTO: MainViewModel
    {
        [Key]
        public string UserID { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(15)]
        public string MobilePhone { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(300)]
        [Required]
        public string Email { get; set; }
       

        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string UrlProfile { get; set; }

        [NotMapped]
        public string FullName { get
            { return FirstName + " " + Surname; } }
    }
}
