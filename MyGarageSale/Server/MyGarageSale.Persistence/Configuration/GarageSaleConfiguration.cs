using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Persistence.Configuration
{
   public class GarageSaleConfiguration : EntityTypeConfiguration<GarageSaleTO>
    {
        public GarageSaleConfiguration()
        {
            HasKey(e => e.GarageSaleID);

            Property(e => e.GarageSaleID).HasColumnName("GarageSaleID").HasColumnType("uniqueidentifier");
            Property(e => e.Title).HasColumnName("Title");
            Property(e => e.EventDate).HasColumnName("EventDate").HasColumnType("Date");
            Property(e => e.Description).HasColumnName("Description");
            Property(e => e.UrlImage).HasColumnName("UrlImage");
            Property(e => e.Status).HasColumnName("Status");
            Property(e => e.UserID).HasColumnName("UserID");
            Property(e => e.Address).HasColumnName("Address");

            HasRequired(e => e.Owner).WithMany().HasForeignKey(e => e.UserID);

            ToTable("tblGarageSale");
        }
    }
}
