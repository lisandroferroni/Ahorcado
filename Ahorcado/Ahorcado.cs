using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ahorcado
{
    public class Ahorcado
    {
        public const string PALABRA = "palabra";

        private string EstadoJuego { get; set; }


        public bool ArriesgaPalabra(string palabra)
        {
            var resultado = palabra.Equals(PALABRA);
            if (resultado)
                EstadoJuego = "Ganaste!";
            else
                EstadoJuego = "Perdiste!";
            return resultado;
        }

        public string MostrarEstadoJuego()
        {
            Console.WriteLine(EstadoJuego);
            return EstadoJuego;
        }

    }
}
