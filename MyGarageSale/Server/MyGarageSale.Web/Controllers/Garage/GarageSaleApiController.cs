using MyGarageSale.Services.Garage;
using MyGarageSale.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MyGarageSale.Web.Controllers.Garage
{

    public class GarageSaleApiController: ApiController
    {
        private IGarageSale _repository;

        public GarageSaleApiController(IGarageSale repository)
        {
            _repository = repository;
        }


        [System.Web.Mvc.HttpGet]
        public IEnumerable<GarageSaleTO> GetAll()

        {
            IList<GarageSaleTO> result = null;
            result = _repository.GetAll();
            if (result!=null)
            {
                return result.ToArray();
            }
           
            return null;

        }

        [System.Web.Mvc.HttpGet]
        public GarageSaleTO GetGarageyByID(Guid garageId)
        {
            GarageSaleTO result = null;
            result = _repository.GetGarageyByID(garageId);            
            return result;
        }

        [System.Web.Mvc.HttpGet]
        public IEnumerable<GarageSaleTO> GetGarageSalesByUser(string user)
        {
            IList<GarageSaleTO> result = null;
            result = _repository.GetByUserID(user);
            return result;
        }

        [System.Web.Mvc.HttpPut]
        public HttpResponseMessage PutGarageSale(Guid id, GarageSaleTO garageSale)
        {
            garageSale.GarageSaleID = id;           
            //    throw new HttpResponseException(HttpStatusCode);           

            var response = Request.CreateResponse<GarageSaleTO>(System.Net.HttpStatusCode.OK, garageSale);
            return response;
        }

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Post(GarageSaleTO garageSale)
        {
            HttpResponseMessage response = Request.CreateResponse<GarageSaleTO>(System.Net.HttpStatusCode.NotAcceptable, garageSale);
            if (_repository.Add(garageSale))
            {
                response = Request.CreateResponse<GarageSaleTO>(System.Net.HttpStatusCode.Created, garageSale);
            }          

            return response;
        }

    }
}