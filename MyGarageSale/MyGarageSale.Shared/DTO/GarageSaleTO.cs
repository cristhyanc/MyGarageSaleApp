using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Shared.DTO
{
    [AuditEntity]
    public class GarageSaleTO
    {
        public System.Guid GarageSaleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public string UserID { get; set; }
        public UserTO Owner { get; set; }
        public DateTime EventDate { get; set; }
        public Constants.Status Status { get; set; }
        public string Address { get; set; }


        
    }
}
