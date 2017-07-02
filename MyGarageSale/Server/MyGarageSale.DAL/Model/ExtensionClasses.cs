using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using MyGarageSale.Shared;

namespace MyGarageSale.DAL.Model
{
    class ExtensionClasses
    {
    }

    public partial class Entities
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Entities));
        private AuditTrailFactory auditFactory;
        private List<tblAudit> auditList = new List<tblAudit>();
        private List<DbEntityEntry> list = new List<DbEntityEntry>();
        protected string UserId { get; set; }

        public Entities(string userId)
           : base("MyGarageSaleEntities")
        {
            this.UserId = userId;
        }


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
                    if(audit!=null)
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
                this.logger.Error("SaveChanges", e);
                string strEr = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    strEr = "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:";
                    strEr = string.Format(strEr, eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    this.logger.Error(strEr);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        strEr = "- Property: \"{0}\", Error: \"{1}\"";
                        strEr = string.Format(strEr, ve.PropertyName, ve.ErrorMessage);
                        this.logger.Error(strEr);
                    }
                }

                throw e;
            }
            catch (Exception ex)
            {
                this.logger.Error("SaveChanges", ex);
                throw ex;
            }
            return retVal;
        }
    }
        
    
    [AuditEntity]
    public partial class tblItem
    { }

}
