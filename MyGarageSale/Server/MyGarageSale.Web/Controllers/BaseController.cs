using MyGarageSale.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGarageSale.Web.Controllers
{
    public class BaseController : Controller
    {


        

        public BaseController()
        {
            var User = new Shared.DTO.UserTO();
            User.Address = "U5 /70";
            User.Email = "cristhyan@outlook.com";
            User.FirstName = "Cristhyan";
            User.Surname = "Cardona";
            User.MobilePhone = "0405593358";
            User.UserID = "cristhyanc";
            User.IsBusy = false;
            MvcApplication.SetCurrentUser(User);
        }

        public void Attention(string message)
        {
            TempData.Add(Alerts.ATTENTION, message);
        }

        public void Success(string message)
        {
            TempData.Add(Alerts.SUCCESS, message);
        }

        public void Information(string message)
        {
            TempData.Add(Alerts.INFORMATION, message);
        }

        public void Error(string message)
        {
            TempData.Add(Alerts.ERROR, message);
        }
    }
}