using MyGarageSale.Shared;
using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Services.Garage
{
    public interface IGarageSale
    {
        bool Add(GarageSaleTO newGarageSale);

        bool  Delete(Guid garageId);

        bool Update(GarageSaleTO garageSale);

        IList<GarageSaleTO> GetAll();

        IList<GarageSaleTO> GetByUserID(string userId);

        GarageSaleTO GetGarageyByID(Guid id);
    }
}
