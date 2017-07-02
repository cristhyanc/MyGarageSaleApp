using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Repository.LogError
{
    interface ILogRepository
    {
        bool RecordError(string detail);

    }
}
