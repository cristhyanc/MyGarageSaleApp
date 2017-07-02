using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Persistence.Configuration
{
  public  class UserConfiguration : EntityTypeConfiguration<UserTO>
    {
        public UserConfiguration()
        {
            HasKey(e => e.UserID);
            Property(e => e.UserID).HasColumnName("UserID").HasColumnType("nvarchar").HasMaxLength(128);
            Property(e => e.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(250);
            Property(e => e.Surname).HasColumnName("Surname").HasColumnType("nvarchar").HasMaxLength(250);
            // Property(e => e.EventDate).HasColumnName("EventDate").HasColumnType("Date");
            Property(e => e.Address).HasColumnName("Address").HasColumnType("nvarchar").HasMaxLength(250);
            Property(e => e.MobilePhone).HasColumnName("MobilePhone").HasColumnType("nvarchar").HasMaxLength(50);
            Property(e => e.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(100);

            ToTable("tblUser");
        }
    }
}
