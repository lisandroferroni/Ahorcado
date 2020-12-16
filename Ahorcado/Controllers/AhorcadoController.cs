using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ahorcado.Models;
using Ahorcado.Util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ahorcado.Controllers
{
    [Route("api/Ahorcado/{action}")]
    [ApiController]
    public class AhorcadoController : ControllerBase
    {
        // GET: api/<AhorcadoController>
        [HttpGet]
        [ActionName("inicio")]
        public string InicializarAhorcado()
        {
            Ahorcado.Init();
            Result result = new Result { Success = true, Value = Ahorcado.Instance.GetPalabra(), Info = "Juego inicializado" };
            string json = JsonConvert.SerializeObject(result);
            return json;
        }

        [HttpPost]
        [ActionName("inicioMultijugador")]
        public string InicializarAhorcadoMultijugador([FromBody] PalabraInput request)
        {
            Ahorcado.Init(request.Palabra);
            Result result = new Result { Success = true, Value = Ahorcado.Instance.GetPalabra(), Info = "Juego Multijugador inicializado" };
            string json = JsonConvert.SerializeObject(result);
            return json;
        }

        [HttpPost]
        [ActionName("arriesgaPalabra")]
        public string ArriesgaPalabra([FromBody] PalabraInput request)
        {
            return JsonConvert.SerializeObject(
                new Result
                {
                    Success = true,
                    Value = Ahorcado.Instance.ArriesgaPalabra(request.Palabra).ToString(),
                    Info = Ahorcado.Instance.MostrarEstadoJuego()
                });
        }

        [HttpPost]
        [ActionName("arriesgaLetra")]
        public string ArriesgaLetra([FromBody] ArriesgaLetraInput request)
        {
            return JsonConvert.SerializeObject(
                new Result
                {
                    Success = true,
                    Value = Ahorcado.Instance.ArriesgaLetra(request.Letra).ToString(),
                    Info = Ahorcado.Instance.MostrarEstadoJuego()
                });
        }

        [HttpGet()]
        [ActionName("estado")]
        public string GetEstadoJuego()
        {
            return JsonConvert.SerializeObject(
                new Result
                {
                    Success = true,
                    Value = Ahorcado.Instance.MostrarEstadoJuego(),
                    Info = Ahorcado.Instance.MostrarEstadoJuego()
                });
        }

        [HttpGet()]
        [ActionName("palabra")]
        public string GetPalabra()
        {
            return Ahorcado.Instance.GetPalabra();
        }

        [HttpGet()]
        [ActionName("longitudPalabra")]
        public string GetLongitudPalabra()
        {
            return Ahorcado.Instance.GetPalabra();
        }

        [HttpGet()]
        [ActionName("intentosRestantes")]
        public int GetNumeroIntentos()
        {
            return Ahorcado.Instance.IntentosRestantes;
        }

        [HttpGet()]
        [ActionName("letrasCorrectas")]
        public List<char> GetLetrasCorrectas()
        {
            return Ahorcado.Instance.GetLetrasCorrectas();
        }

        [HttpGet()]
        [ActionName("letrasIncorrectas")]
        public List<char> GetLetrasIncorrectas()
        {
            return Ahorcado.Instance.GetLetrasIncorrectas();
        }

        [HttpGet()]
        [ActionName("palabraEnJuego")]
        public string GetPalabraEnJuego()
        {
            return Ahorcado.Instance.GetPalabraEnJuego();
        }
    }
}
