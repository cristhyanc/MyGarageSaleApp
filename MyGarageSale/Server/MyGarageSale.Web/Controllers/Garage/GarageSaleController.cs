using MyGarageSale.Services.Garage;
using MyGarageSale.Shared.DTO;
using MyGarageSale.Web.Models;
using MyGarageSale.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGarageSale.Web.Controllers.Garage
{
    public class GarageSaleController : Controller
    {


        private IGarageSale _repository;

        public GarageSaleController()
        {
            _repository = (IGarageSale)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IGarageSale));
        }

        //public GarageSaleController()
        //{
           
        //}

        // GET: GarageSale
        public ActionResult Index()
        {
            GarageSaleViewModel viewModel = new GarageSaleViewModel();           
            viewModel.GarageSales = _repository.GetAll();           

            return View(viewModel);
        }

        // GET: GarageSale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GarageSale/Create
        public ActionResult Create()
        {
            var viewModel = new CreateGarageSaleViewModel();
            return View(viewModel);
        }

        // POST: GarageSale/Create
        [HttpPost]
        public ActionResult Create(CreateGarageSaleViewModel model)
        {
            try
            {
                if (model.archivo != null)
                {
                    string serverpath = Server.MapPath("~") + ConfigurationManager.AppSettings["urlImages"].ToString();
                    model.GarageSale.UrlImage   = DateTime.Now.ToString("yyyyMMdd") + "_" + model.GarageSale.Owner.UserID  + "." + model.archivo.ContentType.Split('/')[1].ToString();
                    model.archivo.SaveAs(serverpath +"/" + model.GarageSale.UrlImage );
                }

                return View(model);
                // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GarageSale/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GarageSale/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GarageSale/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GarageSale/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
