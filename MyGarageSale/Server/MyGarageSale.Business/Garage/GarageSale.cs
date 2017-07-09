using MyGarageSale.Shared;
using MyGarageSale.Shared.DTO;
using MyGarageSale.DataRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGarageSale.DataRepositories.Garage;
using MyGarageSale.Server.Shared;

namespace MyGarageSale.Services.Garage
{
    public class GarageSale : General, IGarageSale
    {
        


        //public GarageSale(string userId) : base(userId)
        //{

        //}

        public GarageSale() : base("cristhyan")
        {

        }

        public bool Add(GarageSaleTO newgarage)
        {           
            try
            {
                IGarageRepository repo = new GarageRepository(this.UserId);
                newgarage.Status = Constants.Status.Active;
                return repo.Add(newgarage);
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleAddError", ex);
            }
            
        }

        public bool Delete(Guid garageId)
        {
            try
            {
                IGarageRepository repo = new GarageRepository(this.UserId);
                return repo.Delete(garageId);
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleDeleteError", ex);
            }
        }

        public bool Update(GarageSaleTO garage)
        {
            try
            {
                IGarageRepository repo = new GarageRepository(this.UserId);
                return repo.Update(garage);
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleUpdateError", ex);
            }
        }

        public List<GarageSaleTO> GetAll()
        {
            List<GarageSaleTO> result = new List<GarageSaleTO>();
            try
            {
                IGarageRepository repo = new GarageRepository(this.UserId);
                result = repo.GetAll();
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleGetAll", ex);
            }
            return result;
        }

        public List<GarageSaleTO> GetByUserID(string userId)
        {
            List<GarageSaleTO> result = new List<GarageSaleTO>();
            try
            {
                IGarageRepository repo = new GarageRepository(this.UserId);
                result = repo.GetByUserID(userId);
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleGetByUserIDError", ex);
            }
            return result;
        }

        public GarageSaleTO GetGarageyByID(Guid id)
        {            
            try
            {
                IGarageRepository repo = new GarageRepository(this.UserId);
                return repo.GetGarageyByID(id);
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleGetGarageyByIDError", ex);
            }
        }
    }
}
