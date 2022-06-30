using Lab5.Handlers;
using Lab5.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
namespace UniTestLab8.Mocks
{
    [TestClass]
    public class PlanetasMock
    {
        [TestMethod]
        public void AgregarMultiplesPlanetasVariosUsuarios()
        {
            ThreadStart usuario1 = new ThreadStart(SimulacionUsuarioCreandoPlanetas);
            ThreadStart usuario2 = new ThreadStart(SimulacionUsuarioCreandoPlanetas);
            Thread hilo1 = new Thread(usuario1);
            Thread hilo2 = new Thread(usuario2);
            hilo1.Start();
            hilo2.Start();
            hilo1.Join();
            hilo2.Join();
        }
        public void SimulacionUsuarioCreandoPlanetas()
        {
            //Arrange
            MyTestPostedFileBase archivoTest = new MyTestPostedFileBase(new
           System.IO.MemoryStream(), "/test.file", "TestFile");
            PlanetaModel planeta = new PlanetaModel
            {
                nombre = "Test-planeta",
                numeroAnillos = 100,
                archivo = archivoTest,
                tipo = "De prueba"
            };
            PlanetasHandler db = new PlanetasHandler();
            bool exitoAlCrear = false;
            for (int intento = 0; intento < 10; ++intento)
            {
                //Act
                exitoAlCrear = db.crearPlaneta(planeta);
                //Assert
                Assert.IsTrue(exitoAlCrear);
            }
        }

        public void MultiplesPlanetasVariosUsuariosModificando()
        {
            ThreadStart usuario1 = new ThreadStart(SimulacionUsuarioModificandoPlanetas);
            ThreadStart usuario2 = new ThreadStart(SimulacionUsuarioModificandoPlanetas);
            Thread hilo1 = new Thread(usuario1);
            Thread hilo2 = new Thread(usuario2);
            hilo1.Start();
            hilo2.Start();
            hilo1.Join();
            hilo2.Join();
        }
        public void SimulacionUsuarioModificandoPlanetas()
        {
            //Arrange
            MyTestPostedFileBase archivoTest = new MyTestPostedFileBase(new
           System.IO.MemoryStream(), "/test.file", "TestFile");
            PlanetaModel planeta = new PlanetaModel
            {
                nombre = "Planeta-Modificado",
                numeroAnillos = 21,
                archivo = archivoTest,
                tipo = "De Modificar"
            };
            PlanetasHandler db = new PlanetasHandler();
            bool exitoAlModificar = false;
            for (int intento = 0; intento < 10; ++intento)
            {
                //Act
                exitoAlModificar = db.modificarPlaneta(planeta);
                //Assert
                Assert.IsTrue(exitoAlModificar);
            }
        }
    }
}
