using MyGarageSale.Shared;
using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.DataRepositories.Repository
{
    //public class BranchRepository : GenericDataRepository<tblBranch>, IBranchRepository
    //{

    //    protected readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(BranchRepository));

    //    public BranchRepository(string userId, string connectionStringName) : base(userId, connectionStringName)
    //    {

    //    }

        //public Constants.CodeReturns Add(params BranchTO[] itemsTo)
        //{
        //    try
        //    {
        //        if (itemsTo != null & itemsTo.Length > 0)
        //        {
        //            tblBranch[] items = new tblBranch[itemsTo.Length];
        //            for (int i = 0; i < itemsTo.Length; i++)
        //            {
        //                itemsTo[i].UpdateSec = 1;
        //                items[i] = FromTOtoDB(itemsTo[i]);
        //                //items[i].IdBranch = Guid.NewGuid();
        //            }
        //            base.Add(items);

        //        }
        //        return Constants.CodeReturns.Successful;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.Error("Add", ex);
        //        throw ex;
        //    }
        //}

        //public Constants.CodeReturns Update(params BranchTO[] itemsTo)
        //{
        //    try
        //    {
        //        if (itemsTo != null & itemsTo.Length > 0)
        //        {
        //            BranchTO old;
        //            tblBranch[] items = new tblBranch[itemsTo.Length];
        //            for (int i = 0; i < itemsTo.Length; i++)
        //            {
        //                old = GetBranchById(itemsTo[i].IdBranch);
        //                if(old==null || old.UpdateSec != itemsTo[i].UpdateSec )
        //                {
        //                    return Constants.CodeReturns.concurrenceProblem ;
        //                }
        //                items[i] = FromTOtoDB(itemsTo[i]);
        //               // items[i].updateSec += 1;
        //            }
        //            base.Update(items);

        //        }
        //        return Constants.CodeReturns.Successful;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.Error("Update", ex);
        //        throw ex;
        //    }
        //}

        //public Constants.CodeReturns Remove(params BranchTO[] itemsTo)
        //{
        //    try
        //    {
        //        if (itemsTo != null & itemsTo.Length > 0)
        //        {
        //            tblBranch[] items = new tblBranch[itemsTo.Length];
        //            for (int i = 0; i < itemsTo.Length; i++)
        //            {
        //                items[i] = FromTOtoDB(itemsTo[i]);
        //            }
        //            base.Remove(items);

        //        }
        //        return Constants.CodeReturns.Successful;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.Error("Remove", ex);
        //        throw ex;
        //    }
        //}

        //public BranchTO GetBranchById(Guid id)
        //{
        //    try
        //    {
        //        BranchTO result = new BranchTO();

        //        tblBranch origResul = base.GetSingle(x => x.IdBranch == id);
        //        if (origResul != null)
        //        {
        //            result = FromDBtoTO(origResul);
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.Error("GetBranchById", ex);
        //        throw ex;
        //    }
        //}

        //public IList<BranchTO> GetAll()
        //{
        //    try
        //    {
        //        List<BranchTO> result = new List<BranchTO>();
        //        IList<tblBranch> origResult = base.GetAll();
        //        result = (from tb in origResult select FromDBtoTO(tb)).ToList();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.logger.Error("GetAll", ex);
        //        throw ex;
        //    }
        //}

        //private tblBranch FromTOtoDB(BranchTO orig)
        //{
        //    tblBranch result = new tblBranch();
        //    result.Address = orig.Address;
        //    result.Email = orig.Email;
        //    result.IdCity = orig.IdCity;
        //    result.LaneLine = orig.LaneLine;
        //    result.MobilePhone = orig.MobilePhone;
        //    result.Name = orig.Name;
        //    result.IdBranch = orig.IdBranch;
        //    result.updateSec = orig.UpdateSec;
        //    result.Status = (int)orig.Status;
        //    return result;
        //}

        //private BranchTO FromDBtoTO(tblBranch orig)
        //{
        //    BranchTO result = new BranchTO();
        //    result.Address = orig.Address;
        //    result.Email = orig.Email;
        //    result.IdCity = orig.IdCity;
        //    result.LaneLine = orig.LaneLine;
        //    result.MobilePhone = orig.MobilePhone;
        //    result.Name = orig.Name;
        //    result.IdBranch = orig.IdBranch;
        //    result.UpdateSec = orig.updateSec;
        //    result.Status = (Constants.Status)orig.Status;
        //    return result;
        //}
//    }
}
