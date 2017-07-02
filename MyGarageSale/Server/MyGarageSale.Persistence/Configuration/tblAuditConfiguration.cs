using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Persistence.Configuration
{
    public class tblAuditConfiguration : EntityTypeConfiguration<tblAudit>
    {
        public tblAuditConfiguration()
        {
            HasKey(e => e.AuditId);
            Property(e => e.AuditId).HasColumnName("UserID").HasColumnType("uniqueidentifier");
            Property(e => e.TableName).HasColumnName("TableName").HasColumnType("nvarchar").HasMaxLength(50);
            Property(e => e.UserId).HasColumnName("UserId").HasColumnType("nvarchar").HasMaxLength(130);
            Property(e => e.RevisionStamp).HasColumnName("RevisionStamp").HasColumnType("Date");
            Property(e => e.Actions).HasColumnName("Actions").HasColumnType("nvarchar").HasMaxLength(20);
            Property(e => e.OldData).HasColumnName("OldData").HasColumnType("XML");
            Property(e => e.NewData).HasColumnName("NewData").HasColumnType("XML");
            Property(e => e.ChangedColumns).HasColumnName("ChangedColumns").HasColumnType("nvarchar").HasMaxLength(1000);
            Property(e => e.TableIdValue).HasColumnName("TableIdValue").HasColumnType("nvarchar").HasMaxLength(250);

            ToTable("tblAudit");
        }
    }
}
