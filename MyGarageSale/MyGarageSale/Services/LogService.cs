using MyGarageSale.Repository.LogError;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Services
{
    public class LogService
    {

        public static void RecordError(Exception exc, string msn = null, string module = null, string methode = null)
        {
            ILogRepository logRepository;

            try
            {

                if (string.IsNullOrEmpty(msn))
                {
                    msn = "Looks like there was an error in the last action, our team will check it";
                }

                string detail = msn;

                if (!string.IsNullOrEmpty(module))
                {
                    detail += ",   Module: " + module;
                }

                if (!string.IsNullOrEmpty(methode))
                {
                    detail += ",   Methode: " + methode;
                }

                detail += exc.Message + "  ";

                if (!string.IsNullOrEmpty(exc.StackTrace))
                {
                    detail += exc.StackTrace;
                }

                //if (CrossConnectivity.Current.IsConnected)
                bool coneect = false;
                if (coneect)
                {
                    logRepository = new LogRepository();
                }
                else
                {
                    logRepository = new LogSqlRepository();
                }

                logRepository.RecordError(detail);

                if (App.Current.MainPage != null)
                {
                    App.Current.MainPage.DisplayAlert("Oops, We have a problem", msn, "Ok");
                }

            }
            catch (Exception ex)
            {
                logRepository = new LogSqlRepository();
                logRepository.RecordError(ex.Message);
            }
        }
    }
}
