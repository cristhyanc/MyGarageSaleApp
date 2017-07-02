using MyGarageSale.Persistence.Configuration;
using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Persistence
{
    public class GarageSaleDataContext : DbContext
    {
       // readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(GarageSaleDataContext));
        private AuditTrailFactory auditFactory;
        private List<tblAudit> auditList = new List<tblAudit>();
        private List<DbEntityEntry> list = new List<DbEntityEntry>();
        protected string UserId { get; set; }

        public GarageSaleDataContext() : base("name=MyGarageSaleEntities")
        {
        }
               
        public GarageSaleDataContext(string userId)
           : base("name=MyGarageSaleEntities")
        { 
            this.UserId = userId;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new GarageSaleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new tblAuditConfiguration());
            //modelBuilder.Configurations.Add(new IncomeCategoryConfiguration());
            //modelBuilder.Configurations.Add(new ExpenseConfiguration());
            //modelBuilder.Configurations.Add(new ExpenseCategoryConfiguration());
            //modelBuilder.Configurations.Add(new PaymentMethodConfiguration());
        }

        public virtual IDbSet<GarageSaleTO> GarageSales { get; set; }
        public virtual IDbSet<tblAudit> tblAudits { get; set; }


        public override int SaveChanges()
        {

            int retVal;
            try
            {
                auditList.Clear();
                list.Clear();
                auditFactory = new AuditTrailFactory(this);
                var entityList = ChangeTracker.Entries().Where(p => p.State == System.Data.Entity.EntityState.Added || p.State == System.Data.Entity.EntityState.Deleted || p.State == System.Data.Entity.EntityState.Modified);
                foreach (var entity in entityList)
                {
                    tblAudit audit = auditFactory.GetAudit(entity);
                    if (audit != null)
                    {
                        audit.UserId = this.UserId;
                        auditList.Add(audit);
                        list.Add(entity);
                    }
                }

                retVal = base.SaveChanges();
                if (auditList.Count > 0)
                {

                    foreach (var audit in auditList)
                    {//add all audits 

                        this.tblAudits.Add(audit);
                    }
                    base.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                //this.logger.Error("SaveChanges", e);
                string strEr = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    strEr = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:";
                    strEr = string.Format(strEr, eve.Entry.Entity.GetType().Name, eve.Entry.State);
                   // this.logger.Error(strEr);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        strEr = "- Property: \"{0}\", Error: \"{1}\"";
                        strEr = string.Format(strEr, ve.PropertyName, ve.ErrorMessage);
                        //this.logger.Error(strEr);
                    }
                }

                throw e;
            }
            catch (Exception ex)
            {
               // this.logger.Error("SaveChanges", ex);
                throw ex;
            }
            return retVal;
        }
    }

    
}
