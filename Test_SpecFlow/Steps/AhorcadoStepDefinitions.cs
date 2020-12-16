using TechTalk.SpecFlow;
using Ahorcado.Controllers;
using Ahorcado.Models;
using Newtonsoft.Json;
using Ahorcado.Util;
using FluentAssertions;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using System.Threading;
using System;
using System.IO;
using System.Reflection;
using ExpectedConditions = OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace Test_SpecFlow.Steps
{
    [Binding]
    public sealed class AhorcadoStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Ahorcado.Ahorcado _ahorcado { get; set; }
        private readonly AhorcadoController _ahorcadoControlador = new AhorcadoController();
        private Result _resultado { get; set; }
        private ChromeDriver chromeDriver; 

        public AhorcadoStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            chromeDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Given("Navegue a la url del ahorcado")]
        public void NavegaAElSitioWeb()
        {
            chromeDriver.Navigate().GoToUrl("https://ahorcadofrontend.azurewebsites.net/");
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("ahorcado"));
        }

        [Given("hago click en el boton por palabra")]
        public void ClickEnBotonPorPalabra()
        {
            var botonPorPalabra = chromeDriver.FindElementById("buttonToggleTipoJuegoPorPalabra");
            botonPorPalabra.Click();
        }

        [Given("hago click en el boton por letra")]
        public void ClickEnBotonPorLetra()
        {
            var botonPorPalabra = chromeDriver.FindElementById("buttonToggleTipoJuegoPorLetra");
            botonPorPalabra.Click();
        }

        [When("se arriesga la letra (.*)")]
        public void CuandoSeArriesgaLaLetra(string letraArriesgada)
        {
            var searchInputBox = chromeDriver.FindElementById("mat-input-0");
            var waitRender = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(10));
            waitRender.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("mat-input-0")));
            searchInputBox.SendKeys(letraArriesgada);
            var botonAdivinarPalabra = chromeDriver.FindElementById("buttonJuegoPorLetra");
            var waitRenderButton = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(10));
            waitRenderButton.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("buttonJuegoPorLetra")));
            botonAdivinarPalabra.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        [When("se arriesga la palabra (.*)")]
        public void CuandoSeArriesgaLaPalabra(string palabraArriesgada)
        {
            var searchInputBox = chromeDriver.FindElementById("mat-input-1");
            var waitRender = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(10));
            waitRender.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("mat-input-1")));
            searchInputBox.SendKeys(palabraArriesgada);

            var botonAdivinarPalabra = chromeDriver.FindElementById("buttonJuegoPorPalabra");
            var waitRenderButton = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(10));
            waitRenderButton.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("buttonJuegoPorPalabra")));
            botonAdivinarPalabra.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
        [Given("establezco el tipo de juego (.*)")]
        public void EstablezcoElTipoDeJuego(string tipoJuego)
        { 
            var waitRenderButton = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(10)); 
            if (tipoJuego=="PorPalabra")
            {
                waitRenderButton.Until(ExpectedConditions.ElementIsVisible(By.Id("buttonToggleTipoJuegoPorPalabra")));
                var botonAdivinarPalabra = chromeDriver.FindElementById("buttonToggleTipoJuegoPorPalabra");
                botonAdivinarPalabra.Click();
            }
            else if (tipoJuego == "PorLetra")
            {
                waitRenderButton.Until(ExpectedConditions.ElementIsVisible(By.Id("buttonToggleTipoJuegoPorLetra")));
                var botonAdivinarLetra = chromeDriver.FindElementById("buttonToggleTipoJuegoPorLetra");
                botonAdivinarLetra.Click();
            }
        }

        [When("se arriesga automaticamente la palabra a adivinar")]
        public void CuandoSeArriesgaLaPalabraAutomaticamente()
        {
            var waitMostrarPalabraAAdivinar = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(10));
            waitMostrarPalabraAAdivinar.Until(ExpectedConditions.ElementIsVisible(By.Id("ButtonFlagPalabraAAdivinar")));
            var botonMostrarPalabraAAdivinar = chromeDriver.FindElementById("ButtonFlagPalabraAAdivinar");
            botonMostrarPalabraAAdivinar.Click();

            var waitPalabraAAdivinar = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(10));
            waitPalabraAAdivinar.Until(ExpectedConditions.ElementIsVisible(By.Id("PalabraAAdivinar")));
            var textoPalabraAAdivinar = chromeDriver.FindElementById("PalabraAAdivinar");

            CuandoSeArriesgaLaPalabra(textoPalabraAAdivinar.Text);
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        [Then("el resultado deberia ser (.*)")]
        public void ElResultadoDeberiaSer(string resultado)
        {
            var waitEstadoDeJuego = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(10));
            waitEstadoDeJuego.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("estadoDeJuego")));
            var textoEstadoDeJuego = chromeDriver.FindElementById("estadoDeJuego");
            Assert.IsTrue(textoEstadoDeJuego.Text.Contains(resultado));
        }

        [Then("los intentos restantes deberian ser (.*)")]
        public void LosIntentosRestantesDeberianSer(string resultado)
        {
            var textoEstadoDeJuego = chromeDriver.FindElementById("CantidadIntentosRestantes");
            Assert.IsTrue(textoEstadoDeJuego.Text.Contains(resultado));
        }

        [Then("el estado de juego deberia ser (.*)")]
        public void ElEstadoDeJuegoDeberiaSer(string resultado)
        {
            _resultado = JsonConvert.DeserializeObject<Result>(_ahorcadoControlador.GetEstadoJuego());
            _resultado.Value.Should().Be(resultado);
        }
    }
}
