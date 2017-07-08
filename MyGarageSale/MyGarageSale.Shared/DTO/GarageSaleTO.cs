using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MyGarageSale.Shared.App_GlobalResources;

namespace MyGarageSale.Shared.DTO
{
    [AuditEntity]
    public class GarageSaleTO
    {
        public System.Guid GarageSaleID { get; set; }

        [Display(Name = "lbl_GarageTitle", ResourceType = typeof(Resource))]        
        public string Title { get; set; }

        [Display(Name = "lbl_GarageDescription", ResourceType = typeof(Resource))]
        public string Description { get; set; }

        [Display(Name = "lbl_GarageUrlImage", ResourceType = typeof(Resource))]
        public string UrlImage { get; set; }
        public string UserID { get; set; }
        public UserTO Owner { get; set; }

        [Display(Name = "lbl_GarageEventDate", ResourceType = typeof(Resource))]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resource),
                                        ErrorMessageResourceName = "Error_Type_Date")]
        public DateTime EventDate { get; set; }

        public Constants.Status Status { get; set; }

        [Display(Name = "lbl_GarageAddress", ResourceType = typeof(Resource))]
        public string Address { get; set; }


        
    }
}
