using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Shared.DTO
{
    [Table("tblAudit")]
    public class tblAudit
    {
        [Key]
        public System.Guid AuditId { get; set; }

       
        public System.DateTime RevisionStamp { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string TableName { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(130)]
        public string UserId { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        public string Actions { get; set; }

        [Column(TypeName = "XML")]
        public string OldData { get; set; }

        [Column(TypeName = "XML")]
        public string NewData { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(1000)]
        public string ChangedColumns { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(250)]
        public string TableIdValue { get; set; }
    }
}
