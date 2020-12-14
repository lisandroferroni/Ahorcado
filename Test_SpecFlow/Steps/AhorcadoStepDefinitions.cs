using TechTalk.SpecFlow;
using Ahorcado.Controllers;
using Ahorcado.Models;
using Newtonsoft.Json;
using Ahorcado.Util;
using FluentAssertions;

namespace Test_SpecFlow.Steps
{
    [Binding]
    public sealed class AhorcadoStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Ahorcado.Ahorcado _ahorcado { get; set; }
        private readonly AhorcadoController _ahorcadoControlador = new AhorcadoController();
        private Result _resultado { get; set; }

        public AhorcadoStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("la palabra a adivinar es (.*)")]
        public void DadaLaPrimerPalabra(string palabra)
        {
            PalabraInput palabraInput = new PalabraInput() { Palabra = palabra };
            _ahorcadoControlador.InicializarAhorcadoMultijugador(palabraInput);
        }

        [When("se arriesga la letra (.*)")]
        public void CuandoSeArriesgaLaLetra(string letraArriesgada)
        {
            ArriesgaLetraInput arriesgaLetraInput = new ArriesgaLetraInput() { Letra = letraArriesgada[0] };
            _resultado = JsonConvert.DeserializeObject<Result>(_ahorcadoControlador.ArriesgaLetra(arriesgaLetraInput));
        }

        [When("se arriesga la palabra (.*)")]
        public void CuandoSeArriesgaLaPalabra(string palabraArriesgada)
        {
            PalabraInput palabraInput = new PalabraInput() { Palabra = palabraArriesgada };
            _resultado = JsonConvert.DeserializeObject<Result>(_ahorcadoControlador.ArriesgaPalabra(palabraInput));
        }

        [Then("el resultado deberia ser (.*)")]
        public void ElResultadoDeberiaSer(string resultado)
        {
            _resultado.Value.Should().Be(resultado);
        }

        [Then("el estado de juego deberia ser (.*)")]
        public void ElEstadoDeJuegoDeberiaSer(string resultado)
        {
            _resultado = JsonConvert.DeserializeObject<Result>(_ahorcadoControlador.GetEstadoJuego());
            _resultado.Value.Should().Be(resultado);
        }
    }
}
