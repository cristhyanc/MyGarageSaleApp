using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Services
{
    public class MessageService
    {
        public static void DisplayOkAlert(string title, string msn)
        {
            try
            {
                App.Current.MainPage.DisplayAlert(title, msn, "Ok");
            }
            catch (Exception ex)
            {
                LogService.RecordError(ex, "", "MessageService", "DisplayOkAlert");
            }

        }

        public static bool DisplayYesNoAlert(string title, string msn)
        {
            bool answer = false;
            try
            {
                answer = App.Current.MainPage.DisplayAlert(title, msn, "Yes", "No").GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                LogService.RecordError(ex, "", "MessageService", "DisplayYesNoAlert");
            }

            return answer;

        }
    }
}
