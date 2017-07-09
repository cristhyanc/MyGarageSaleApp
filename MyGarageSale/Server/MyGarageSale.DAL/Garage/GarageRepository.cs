using MyGarageSale.Server.Shared;
using MyGarageSale.Shared;
using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.DataRepositories.Garage
{

    public class GarageRepository : GenericDataRepository<GarageSaleTO>, IGarageRepository
    {

        public GarageRepository(string userId) : base(userId)
        {

        }
       


        public bool Add(params GarageSaleTO[] items)
        {
            try
            {
                if (items != null & items.Length > 0)
                {
                    
                    for (int i = 0; i < items.Length; i++)
                    { 
                        items[i].GarageSaleID = Guid.NewGuid();

                        Context.Users.Attach(items[i].User);
                    }

                    base.Add(items);

                }
                return true;
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleAddError", ex);
            }
        }

        public bool Update(params GarageSaleTO[] items)
        {
            try
            {
                if (items != null & items.Length > 0)
                {
                    GarageSaleTO old;
                 
                    for (int i = 0; i < items.Length; i++)
                    {
                        old = GetGarageyByID(items[i].GarageSaleID);
                        if (old == null )
                        {
                            throw new GarageSaleException("GarageSaleConcurrenceProblem");
                        }                       
                       
                    }
                    base.Update(items);

                }
                return true;
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleUpdateError", ex);
            }
        }

        public bool Delete(Guid GarageSaleID)
        {
            try
            {
                var item = GetGarageyByID(GarageSaleID);
                if (item != null)
                {                                       
                    base.Remove(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleRemoveError", ex);
            }
        }

        public GarageSaleTO GetGarageyByID(Guid id)
        {
            try
            {
                GarageSaleTO result = base.GetSingle(x => x.GarageSaleID == id);               
                return result;
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleGetGarageyByIDError", ex);
            }
        }

        public List<GarageSaleTO> GetAll()
        {
            try
            {
                List<GarageSaleTO> result = (from tb in base.GetAll()
                                             where tb.Status == Constants.Status.Active
                                             select tb).ToList();               
                return result;
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleGetAllError", ex);
            }
        }

        public List<GarageSaleTO> GetByUserID(string userId)
        {
            try
            {
                List<GarageSaleTO> result = (from tb in base.GetAll()
                                             where tb.Status == Constants.Status.Active &&
                                             tb.UserID.Equals(userId)
                                             select tb).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new GarageSaleException("GarageSaleGetByUserIDError", ex);
            }
        }


    }
}
