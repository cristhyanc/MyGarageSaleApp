using Microsoft.Practices.Unity;
using MyGarageSale.Services.Garage;
using MyGarageSale.Shared;
using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyGarageSale.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            container.RegisterType<IGarageSale, GarageSale>(new HierarchicalLifetimeManager());
            container.RegisterInstance<IGarageSale>(new GarageSale());
            // container.RegisterType<IGarageSale, GarageSale>(new HierarchicalLifetimeManager());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);          

            
        }

        private const  string currentSessionData= "currentSessionData";



        public static General SessionData
        {
            get
            {
                General info=new General ();
                if (HttpContext.Current.Session[currentSessionData] != null)
                {
                    info=(General)HttpContext.Current.Session[currentSessionData];
                }
                return info;
            }           
        }

        public static void SetCurrentUser(UserTO user)
        {
            var general = SessionData;
            general.User = user;
            HttpContext.Current.Session[currentSessionData] = general;
        }
    }
}
