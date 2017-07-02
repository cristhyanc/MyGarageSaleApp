using MyGarageSale.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Services.Customer
{
    
    public interface ICustomer
    {
        Constants.CodeReturns AddCustomer();

        Constants.CodeReturns DeleteCustomer();

        Constants.CodeReturns UpdateCustomer();
    }
}
