using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio8.Handler;
using Laboratorio8.Models;

namespace Laboratorio8.Controllers
{
    public class ProductsController : Controller
    {
        private ProductHandler AccessProductsData;

        public ProductsController()
        {
            AccessProductsData = new ProductHandler();
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProducts()
        {
            var products = AccessProductsData.GetAll();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}