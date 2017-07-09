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
using MyGarageSale.Server.Shared;
namespace MyGarageSale.Web.Controllers.Garage
{
    public class GarageSaleController : BaseController
    {

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(BaseController));
        private IGarageSale _service;

        public GarageSaleController()
        {
            _service = (IGarageSale)System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IGarageSale));
        }

        public GarageSaleController(IGarageSale service)
        {
            _service = service;
        }

        // GET: GarageSale
        public ActionResult Index()
        {
            GarageSaleViewModel viewModel = new GarageSaleViewModel();
            viewModel.GarageSales = _service.GetAll();

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
                    string serverpath = Server.MapPath("~") ;

                    if (!System.IO.Directory.Exists(serverpath + "/" + model.GarageSale.User.UserID))
                    {
                        System.IO.Directory.CreateDirectory(serverpath + "/" + model.GarageSale.User.UserID);
                    }

                    model.GarageSale.UrlImage   = ConfigurationManager.AppSettings["urlImages"].ToString() + "/" + model.GarageSale.User.UserID  + "/" + Guid.NewGuid().ToString()  +"." + model.archivo.ContentType.Split('/')[1].ToString();
                    serverpath = serverpath + "/" + model.GarageSale.UrlImage;
                    model.archivo.SaveAs(serverpath);
                }


               if ( _service.Add(model.GarageSale))
                {
                    this.Success("saved!");
                }
                else
                {
                    this.Attention("Could not being saved");
                }
                
                
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message);
               // LogErrorHelper.ErrorLog(ex);
                this.Error("Opps, there is a problem");
            }
            return View(model);
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
