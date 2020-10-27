using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            return Ahorcado.Instance.GetPalabra();
        }

        // GET: api/<AhorcadoController>
        [HttpGet()]
        [ActionName("palabra")]
        public string GetPalabra()
        {
            return Ahorcado.Instance.GetPalabra();
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
