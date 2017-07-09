using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MyGarageSale.Shared.App_GlobalResources;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGarageSale.Shared.DTO
{
    [AuditEntity]
    [Table("tblGarageSale")]
    public class GarageSaleTO
    {
        [Key]
        public System.Guid GarageSaleID { get; set; }

        [Display(Name = "lbl_GarageTitle", ResourceType = typeof(Resource))]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "lbl_GarageDescription", ResourceType = typeof(Resource))]
        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Display(Name = "lbl_GarageUrlImage", ResourceType = typeof(Resource))]
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string UrlImage { get; set; }


        public string UserID { get; set; }

        public UserTO User { get; set; }

        [Display(Name = "lbl_GarageEventDate", ResourceType = typeof(Resource))]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resource),
                                        ErrorMessageResourceName = "Error_Type_Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EventDate { get; set; }

        public Constants.Status Status { get; set; }

        [Display(Name = "lbl_GarageAddress", ResourceType = typeof(Resource))]
        [Column(TypeName = "nvarchar")]
        [MaxLength(500)]
        [Required]
        public string Address { get; set; }
        
        
    }
}
