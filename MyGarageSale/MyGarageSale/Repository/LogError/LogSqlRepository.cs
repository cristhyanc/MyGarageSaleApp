using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Repository.LogError
{
    public class LogSqlRepository : ILogRepository
    {
        ISqlService sqlService;

        public LogSqlRepository()
        {
            sqlService = new SqlService();
        }


        public bool RecordError(string detail)
        {
            try
            {
                LogErrorTO error = new LogErrorTO();               
                error.Details = detail;
                error.QueuedData = DateTime.Now.ToUniversalTime();
                error.Sent = false;
                return sqlService.SaveData<LogErrorTO>(error);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
