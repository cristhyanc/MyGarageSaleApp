using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using MyGarageSale.Shared;
using MyGarageSale.Persistence;

namespace MyGarageSale.DataRepositories
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        private string userID = "";
        protected  GarageSaleDataContext Context;
        public GenericDataRepository(string userId)
        {
            this.userID = userId;
             Context = new GarageSaleDataContext(this.userID);
        }

        public GenericDataRepository()
        {
             Context = new GarageSaleDataContext(this.userID);
        }

        public virtual bool Add(params T[] items)
        {
           

                foreach (T item in items)
                {                    
                    Context.Entry(item).State = EntityState.Added;
                }

                Context.SaveChanges();
          
            return true;
        }     

        public virtual bool Update(params T[] items)
        {
           

                foreach (T item in items)
                {

                    Context.Entry(item).State = EntityState.Modified;
                }
                Context.SaveChanges();
          
            return true;
        }




        public virtual bool Remove(params T[] items)
        {
            

                foreach (T item in items)
                {
                    Context.Entry(item).State = EntityState.Deleted;
                }
                Context.SaveChanges();
           
            return true;
        }

        public virtual List<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
           
                IQueryable<T> dbQuery = Context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            
            return list;
        }

        public virtual List<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            
                IQueryable<T> dbQuery = Context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
           
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
           
                IQueryable<T> dbQuery = Context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
           
            return item;
        }
    }
}
