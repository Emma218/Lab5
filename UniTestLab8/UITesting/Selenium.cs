using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace UnitTestLab7.UITesting
{
    [TestClass]
    public class Selenium
    {
        IWebDriver driver;
        [TestMethod]
        public void PruebaIngresoCrearPlanetas()
        {
            ///Arrange
            /// Crea el driver de Chrome
            driver = new ChromeDriver();
            string URL = "*******la url de su apliación**********";
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL indicada
            driver.Url = URL;
            ///Assert
            
            IWebElement enlaceCrearPlantea = driver.FindElement(By.Id("test"));
            enlaceCrearPlantea.Click();
            IWebElement h1 = driver.FindElement(By.Id("tituloTest"));

            Assert.AreEqual("Formulario de creación de planetas", h1.Text);

           
        }

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

    }
}