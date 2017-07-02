using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Repository
{
    public interface ISqlService
    {
        Boolean DeleteData<T>(T data);
        Boolean SaveData<T>(T data);
        Task<Boolean> DeleteDataAsync<T>(T data);
        Task<Boolean> SaveDataAsync<T>(T data);
    }
}
