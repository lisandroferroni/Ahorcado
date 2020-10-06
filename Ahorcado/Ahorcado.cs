using Ahorcado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ahorcado
{
    public class Ahorcado
    {
        //TODO: pasar el hardcode al lado de tests
        public string PALABRA = "palabra";
        private string EstadoJuego { get; set; }
        public Usuario Usuario { get; set; }
        public List<char> LetrasCorrectas = new List<char>();
        public List<char> LetrasIncorrectas = new List<char>();

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

        public bool? ArriesgaLetra(char letra)
        {

            if (PALABRA.Contains(letra))
            {
                LetrasCorrectas.Add(letra);
                return true;
            }
            else
            {
                LetrasIncorrectas.Add(letra);
                return false;
            }
        }

        public bool Gano()
        {
            List<char> datalist = new List<char>();
            datalist.AddRange(PALABRA);
            var result = datalist.OrderBy(s => s).Distinct().SequenceEqual(LetrasCorrectas.OrderBy(s => s).Distinct());
            if (result) EstadoJuego = "Ganaste!";
            return result;
        }

        public bool? ContieneLetraCorrecta(char letra)
        {
            return LetrasCorrectas.Contains(letra);
        }

        public bool? ContieneLetraIncorrecta(char letra)
        {
            return LetrasIncorrectas.Contains(letra);
        }

        public void SetNombreUsuario(string nombre)
        {
            Usuario = new Usuario() { Nombre = nombre };
        }

        public string GetNombreUsuario()
        {
            try
            {
                return Usuario.GetNombre();
            }
            catch
            {
                return "";
            }
        }
    }
}
