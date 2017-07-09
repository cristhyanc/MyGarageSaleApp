using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGarageSale.Web.ViewModel
{
    public class CreateGarageSaleViewModel
    {
        public HttpPostedFileBase archivo { get; set; }
        public MyGarageSale.Shared.DTO.GarageSaleTO GarageSale { get; set; }

        public CreateGarageSaleViewModel()
        {
            GarageSale = new Shared.DTO.GarageSaleTO();
            GarageSale.EventDate = DateTime.Now.AddDays(10);
            GarageSale.User = new Shared.DTO.UserTO();
            GarageSale.User = MvcApplication.SessionData.User;
            GarageSale.UserID = GarageSale.User.UserID;

        }
    }
}