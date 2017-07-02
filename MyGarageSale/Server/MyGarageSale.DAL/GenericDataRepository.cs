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
      
        public GenericDataRepository(string userId)
        {
            this.userID = userId;
          
        }

        public GenericDataRepository()
        {

        }

        public virtual bool Add(params T[] items)
        {
            using (var context = new GarageSaleDataContext(this.userID))
            {

                foreach (T item in items)
                {                    
                    context.Entry(item).State = EntityState.Added;
                }

                context.SaveChanges();
            }
            return true;
        }


        public virtual bool Update(params T[] items)
        {
            using (var context = new GarageSaleDataContext(this.userID))
            {

                foreach (T item in items)
                {

                    context.Entry(item).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            return true;
        }




        public virtual bool Remove(params T[] items)
        {
            using (var context = new GarageSaleDataContext(this.userID))
            {

                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
            return true;
        }

        public virtual List<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new GarageSaleDataContext(this.userID))
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            return list;
        }

        public virtual List<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new GarageSaleDataContext(this.userID))
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new GarageSaleDataContext(this.userID))
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }
    }
}
