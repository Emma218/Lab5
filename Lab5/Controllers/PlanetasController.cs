using Lab5.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class PlanetasController : Controller
    {
        // GET: Planetas
        public ActionResult listadoDePlanetas()
        {
            PlanetasHandler accesoDatos = new PlanetasHandler();
            ViewBag.planetas = accesoDatos.obtenerTodoslosPlanetas();
            return View();
        }
    }
}