using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.Reflection;
using System.Data.Common;
using System.Data.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using MyGarageSale.Shared;


namespace MyGarageSale.DAL.Model
{
    public class AuditTrailFactory
    {
        private DbContext context;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AuditTrailFactory));
        public AuditTrailFactory(DbContext context)
        {
            this.context = context;
        }

        private bool IsAuditable(object entity)
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(entity.GetType());
            foreach (System.Attribute attr in attrs)
            {
                if (attr is AuditEntity)
                {
                    return true;
                }
            }
            return false;
        }

        public tblAudit GetAudit(DbEntityEntry entry)
        {
            tblAudit audit = new tblAudit();
            try
            {

                if (!IsAuditable(entry.Entity))
                {
                    return null;
                }
                
                audit.AuditId = Guid.NewGuid();
                audit.TableName = GetTableName(entry);
                audit.RevisionStamp = DateTime.Now;
                audit.TableIdValue = GetKeyValue(entry);

                //entry is Added 
                if (entry.State == System.Data.Entity.EntityState.Added)
                {
                    audit.NewData = GetEntryValueInString(entry, false);
                    audit.Actions = Constants.AuditActions.Insert.ToString();
                }
                //entry in deleted
                else if (entry.State == System.Data.Entity.EntityState.Deleted)
                {
                    audit.OldData = GetEntryValueInString(entry, true);
                    audit.Actions = Constants.AuditActions.Deleted.ToString();
                }
                //entry is modified
                else if (entry.State == System.Data.Entity.EntityState.Modified)
                {
                    audit.OldData = GetEntryValueInString(entry, true);
                    audit.NewData = GetEntryValueInString(entry, false);
                    audit.Actions = Constants.AuditActions.Updated.ToString();
                }
            }
            catch (Exception ex)
            {
                this.logger.Error("GetAudit", ex);
                throw ex;
            }
            return audit;
        }
       
        private string GetEntryValueInString(DbEntityEntry entry, bool isOrginal)
        {
            XDocument document = new XDocument();
            try
            {
                IEnumerable<string> PropertyNames = new List<string>();
                object target = Constants.CloneEntity((Object)entry.Entity);
                DbPropertyValues dbValues = null;
                if (isOrginal)
                {
                    PropertyNames = entry.OriginalValues.PropertyNames;
                    dbValues = entry.GetDatabaseValues();
                    if (dbValues == null)
                    {
                        return "";
                    }
                }
                else
                {
                    PropertyNames = entry.CurrentValues.PropertyNames;

                }
                foreach (var propertyName in PropertyNames)
                {
                    object setterValue = null;
                    if (isOrginal)
                    {
                        //Get orginal value 
                        setterValue = dbValues[propertyName];
                    }
                    else
                    {
                        //Get orginal value 
                        setterValue = entry.CurrentValues[propertyName];
                    }

                    PropertyInfo propInfo = target.GetType().GetProperty(propertyName);
                    //update property with orgibal value 
                    if (setterValue == DBNull.Value)
                    {//
                        setterValue = null;
                    }
                    propInfo.SetValue(target, setterValue, null);
                }//end foreach

                //XmlSerializer formatter = new XmlSerializer(target.GetType());
                var formatter = new DataContractSerializer(target.GetType());

                using (XmlWriter xmlWriter = document.CreateWriter())
                {
                    formatter.WriteObject(xmlWriter, target);
                }

            }
            catch (Exception ex)
            {
                this.logger.Error("GetEntryValueInString", ex);
                throw ex;
            }
            return document.Root.ToString();


        }


        public string GetKeyValue(DbEntityEntry entry)
        {
            string id = "";
            try
            {
                var objectStateEntry = ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);

                if (objectStateEntry.EntityKey.EntityKeyValues != null)
                    id = (objectStateEntry.EntityKey.EntityKeyValues[0].Value).ToString();
            }
            catch (Exception ex)
            {
                this.logger.Error("GetKeyValue", ex);
                throw ex;
            }
            return id;
        }

        private string GetTableName(DbEntityEntry dbEntry)
        {
            string tableName = "";
            try
            {
                TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
                tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;
            }
            catch (Exception ex)
            {
                this.logger.Error("GetTableName", ex);
                throw ex;
            }
            return tableName;
        }
    }
}
