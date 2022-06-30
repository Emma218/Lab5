using Lab5.Handlers;
using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class PlanetasController : Controller
    {
       
        public ActionResult listadoDePlanetas()
        {
            PlanetasHandler accesoDatos = new PlanetasHandler();
            ViewBag.planetas = accesoDatos.obtenerTodoslosPlanetas();
            return View();
        }

      
        public ActionResult crearPlaneta()
        {
            return View("crearPlaneta");
        }

       
        [HttpPost]
        public ActionResult crearPlaneta(PlanetaModel planeta)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PlanetasHandler accesoDatos = new PlanetasHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.crearPlaneta(planeta);

                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El planeta" + " " + planeta.nombre + " fue creado con exito :)";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear el planeta :c";
                return View();
            }
        }


        [HttpGet]
        public ActionResult editarPlaneta(int ? identificador)
        {
            ActionResult vista;
            try
            {
                PlanetasHandler accesoDatos = new PlanetasHandler();
                PlanetaModel planetaModificar = accesoDatos.obtenerTodoslosPlanetas().Find(smodel => smodel.id == identificador);
                if (planetaModificar == null)
                {
                    vista = RedirectToAction("listadoDePlanetas");
                }
                else
                {
                    vista = View(planetaModificar);
                }
            }
            catch
            {
                vista = RedirectToAction("listadoDePlanetas");
            }
            return vista;
        }


        [HttpPost]
        public ActionResult editarPlaneta(PlanetaModel planeta)
        {
            try
            {
                PlanetasHandler accesoDatos = new PlanetasHandler();
                accesoDatos.modificarPlaneta(planeta);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible modificar el planeta :c";
                return View();
            }
        }

        [HttpGet]
        public FileResult accederArchivo(int identificador)
        {
            PlanetasHandler accesoDatos = new PlanetasHandler();
            var tupla = accesoDatos.descargarContenido(identificador);
            return File(tupla.Item1, tupla.Item2);
           
        }
    }
}
