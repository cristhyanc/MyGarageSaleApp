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

        public bool Add(GarageSaleTO newBranch)
        {           
            try
            {
                IGarageRepository repo = new GarageRepository(this.UserId);
                return repo.Add(newBranch);
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleAddError", ex);
            }
            
        }

        public bool Delete(Guid branchId)
        {
            try
            {
                IGarageRepository repo = new GarageRepository(this.UserId);
                return repo.Delete(branchId);
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleDeleteError", ex);
            }
        }

        public bool Update(GarageSaleTO branch)
        {
            try
            {
                IGarageRepository repo = new GarageRepository(this.UserId);
                return repo.Update(branch);
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
