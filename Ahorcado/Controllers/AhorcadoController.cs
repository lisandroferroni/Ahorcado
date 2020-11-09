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
            Result result = new Result { Success = true, Value = Ahorcado.Instance.GetPalabra(), Info = "ABC" };
            string json = JsonConvert.SerializeObject(result);
            return json;
        }

        [HttpPost]
        [ActionName("arriesgaPalabra")]
        public string ArriesgaPalabra([FromBody] PalabraInput palabra)
        {
            return JsonConvert.SerializeObject(
                new Result
                {
                    Success = true,
                    Value = Ahorcado.Instance.ArriesgaPalabra(palabra.Palabra).ToString(),
                    Info = Ahorcado.Instance.EstadoJuego
                });
        }

        // GET: api/<AhorcadoController>
        [HttpGet()]
        [ActionName("palabra")]
        public string GetPalabra()
        {
            return Ahorcado.Instance.GetPalabra();
        }

        [HttpPost]
        [ActionName("arriesgaLetra")]
        public bool ArriesgaLetra([FromBody] char letra)
        {
            return Ahorcado.Instance.ArriesgaLetra(letra);
        }        

        [HttpGet()]
        [ActionName("estado")]
        public string GetEstadoJuego()
        {
            return Ahorcado.Instance.MostrarEstadoJuego();
        }

        // GET api/<AhorcadoController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AhorcadoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //// PUT api/<AhorcadoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AhorcadoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
