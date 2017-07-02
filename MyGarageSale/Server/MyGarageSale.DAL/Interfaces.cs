using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MyGarageSale.Shared;
using MyGarageSale.Shared.DTO;

namespace MyGarageSale.DataRepositories
{

    public interface IGenericDataRepository<T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        bool Add(params T[] items);
        bool Update(params T[] items);
        bool Remove(params T[] items);
    }

    public interface IGarageRepository : IGenericDataRepository<GarageSaleTO>
    {
        bool Add(params GarageSaleTO[] items);
        bool Update(params GarageSaleTO[] items);
        bool Delete(Guid GarageSaleID);
        IList<GarageSaleTO> GetAll();
        GarageSaleTO GetGarageyByID(Guid id);
        IList<GarageSaleTO> GetByUserID(string userId);
    }




}
