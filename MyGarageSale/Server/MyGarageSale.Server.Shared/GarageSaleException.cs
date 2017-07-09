using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyGarageSale.Server.Shared
{
    [Serializable()]
    public class GarageSaleException : System.Exception
    {
        public GarageSaleException() : base() { }
        public GarageSaleException(string message) : base(GetMessage(message))
        {


        }

        static string GetMessage(string code)
        {
            var mss = HttpContext.GetGlobalResourceObject("LocalizedText", code);
            if (mss != null)
            {
                code = mss.ToString();
            }            
            return code;
        }


        public GarageSaleException(string message, System.Exception inner) : base(GetMessage(message), inner)
        {
            if (inner.GetType() != typeof(GarageSaleException))
            {

                LogErrorHelper.ErrorLog(inner);

                //MethodBase site = inner.TargetSite;
                //string methodName = site.Name;
                //string dllName = site.DeclaringType.ToString();
                //log4net.ILog logger = log4net.LogManager.GetLogger(site.DeclaringType);
                //logger.Error("An error has occurred, Method: " + methodName + ", DLL: " + dllName + ". Error:" + inner.Message, inner);
            }
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected GarageSaleException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}