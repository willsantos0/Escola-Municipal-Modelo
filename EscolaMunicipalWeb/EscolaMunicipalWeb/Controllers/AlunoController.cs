using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscolaMunicipalWeb.Controllers
{
    public class AlunoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Página Inicial";

            ViewData["urlApi"] =
                  ConfigurationManager.AppSettings["urlApi"];

            return View();
        }
    }
}
