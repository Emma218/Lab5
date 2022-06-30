using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5.Controllers;
using System.Web.Mvc;
using Lab5.Models;

namespace UniTestLab8.Controllers
{
    [TestClass]
    public class PlanetasControllerTest
    {
        [TestMethod]
        public void TestCrearPlanetaViewResultNotNull() //Valida si la vista asociada existe
        {
            // Arrange: inicializa o crea todas las dependencias
            PlanetasController planetasController = new PlanetasController();

            // Act: ejecuta el metodo
            ActionResult vista = planetasController.crearPlaneta();

            // Assert: verifica el funcionamiento correcto (en este caso que la vista es correcta)
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestCrearPlanetaViewResult() //Valida si la vista es correcta
        {
            // Arrange
            PlanetasController planetasController = new PlanetasController();

            // Act
            ViewResult vista = planetasController.crearPlaneta() as ViewResult;

            // Assert: verifica el funcionamiento correcto (en este caso que la vista es correcta)
            Assert.AreEqual("crearPlaneta", vista.ViewName);
        }

        //Pruebas integradas
        [TestMethod]
        public void EditarPlanetaIdValidoVistaNoNulo()
        {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();

            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void EditarPlanetaValidoModeloRetornadoNoEsNulo() // Verificar si existe el modelo con id = 1 en la base
        {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();

            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;

            //Assert
            Assert.IsNotNull(vista.Model);
        }

        [TestMethod]
        public void EditarPlanetaConIdNoExistenteRedirectToLP() // Verificar si existe el modelo con id = 1 en la base
        {
            //Arrange
            int idInvalido = -1;
            PlanetasController planetasController = new PlanetasController();

            //Act
            RedirectToRouteResult vista = planetasController.editarPlaneta(idInvalido) as RedirectToRouteResult;

            //Assert
            Assert.AreEqual("listadoDePlanetas", vista.RouteValues["action"]);
        }


        [TestMethod]
        public void EditarPlanetaElModeloEnviadoEsCorrecto()
        {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;
            PlanetaModel planeta = vista.Model as PlanetaModel;
            //Assert
            Assert.IsNotNull(planeta);
            Assert.AreEqual(1, planeta.numeroAnillos);
            Assert.AreEqual("Tierra", planeta.nombre);
        }

        [TestMethod]
        public void ViewEditarPlaneta()
        {
            // Arrange: 
            PlanetasController planetasController = new PlanetasController();

            // Act: 
            ActionResult view = planetasController.editarPlaneta(1);

            // Assert: 
            Assert.IsNotNull(view);
        }



    }
}
