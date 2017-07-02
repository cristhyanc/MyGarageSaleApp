using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Repository.LogError
{
    public class LogRepository : ILogRepository
    {

        ILogRepository logSqlRepository;


        public bool RecordError(string detail)
        {
            try
            {

            }
            catch (Exception ex)
            {
                logSqlRepository = new LogSqlRepository();
                logSqlRepository.RecordError(ex.Message);
            }
            return true;
        }
    }
}
