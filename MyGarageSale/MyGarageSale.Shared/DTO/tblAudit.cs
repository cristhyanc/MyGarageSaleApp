using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Shared.DTO
{
   public class tblAudit
    {
        public System.Guid AuditId { get; set; }
        public System.DateTime RevisionStamp { get; set; }
        public string TableName { get; set; }
        public string UserId { get; set; }
        public string Actions { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
        public string ChangedColumns { get; set; }
        public string TableIdValue { get; set; }
    }
}
