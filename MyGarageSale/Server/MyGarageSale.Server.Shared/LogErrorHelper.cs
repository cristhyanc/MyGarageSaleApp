using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageSale.Server.Shared
{
   public class LogErrorHelper
    {

        public static void ErrorLog( System.Exception inner)
        {
            try
            {
                MethodBase site = inner.TargetSite;
                string methodName = site.Name;
                string dllName = site.DeclaringType.ToString();
                log4net.ILog logger = log4net.LogManager.GetLogger(site.DeclaringType);
                logger.Error("An error has occurred, Method: " + methodName + ", DLL: " + dllName + ". Error:" + inner.Message, inner);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
