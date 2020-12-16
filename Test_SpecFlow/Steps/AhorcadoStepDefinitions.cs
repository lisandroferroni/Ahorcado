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
            chromeDriver = new ChromeDriver(@"C:\Users\fan_a\Desktop");
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
            var waitRender = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(2));
            waitRender.Until(ExpectedConditions.ElementIsVisible(By.Id("mat-input-0")));
            searchInputBox.SendKeys(letraArriesgada);
            var waitRenderButton = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(2));
            waitRenderButton.Until(ExpectedConditions.ElementIsVisible(By.Id("buttonJuegoPorLetra")));
            var botonAdivinarPalabra = chromeDriver.FindElementById("buttonJuegoPorLetra");
            botonAdivinarPalabra.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        [When("se arriesga la palabra (.*)")]
        public void CuandoSeArriesgaLaPalabra(string palabraArriesgada)
        {
            var searchInputBox = chromeDriver.FindElementById("mat-input-1");
            var waitRender = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(2));
            waitRender.Until(ExpectedConditions.ElementIsVisible(By.Id("mat-input-1")));
            searchInputBox.SendKeys(palabraArriesgada);
            var waitRenderButton = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(2));
            waitRenderButton.Until(ExpectedConditions.ElementIsVisible(By.Id("buttonJuegoPorPalabra")));
            var botonAdivinarPalabra = chromeDriver.FindElementById("buttonJuegoPorPalabra");
            botonAdivinarPalabra.Click();
        }

        [Then("el resultado deberia ser (.*)")]
        public void ElResultadoDeberiaSer(string resultado)
        {
            var waitEstadoDeJuego = new WebDriverWait(chromeDriver, System.TimeSpan.FromSeconds(10));
            waitEstadoDeJuego.Until(ExpectedConditions.ElementIsVisible(By.Id("estadoDeJuego")));
            var textoEstadoDeJuego = chromeDriver.FindElementById("estadoDeJuego");
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
