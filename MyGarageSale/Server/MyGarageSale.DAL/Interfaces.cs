using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MyGarageSale.Shared;
using MyGarageSale.Shared.DTO;

namespace MyGarageSale.DataRepositories
{

    public interface IGenericDataRepository<T> where T : class
    {
        List<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        List<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
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
        List<GarageSaleTO> GetAll();
        GarageSaleTO GetGarageyByID(Guid id);
        List<GarageSaleTO> GetByUserID(string userId);
    }




}
