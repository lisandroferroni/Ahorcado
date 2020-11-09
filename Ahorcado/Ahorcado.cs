using Ahorcado.Models;
using Ahorcado.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ahorcado
{
    public class Ahorcado : IAhorcado
    {
        public Ahorcado()
        {
            Palabra = Palabras.GetPalabraAleatoria();
            EstadoJuego = "En juego";
        }

        public Ahorcado(string palabra)
        {
            Palabra = palabra;
            EstadoJuego = "En juego";
        }

        public static Ahorcado Instance { get; private set; }

        public static void Init(string palabra = "")
        {
            Instance = palabra == "" ? new Ahorcado() : new Ahorcado(palabra);
        }

        public string Palabra { get; set; }
        public string EstadoJuego { get; set; }
        public Usuario Usuario { get; set; }
        public List<char> LetrasCorrectas = new List<char>();
        public List<char> LetrasIncorrectas = new List<char>();

        public bool ArriesgaPalabra(string palabra)
        {
            var resultado = palabra.Equals(Palabra);
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

        public bool ArriesgaLetra(char letra)
        {
            bool result;
            if (Palabra.Contains(letra))
            {
                LetrasCorrectas.Add(letra);
                
                result = true;
            }
            else
            {
                LetrasIncorrectas.Add(letra);
                result = false;
            }
            Gano();
            return result;
        }

        public bool Gano()
        {
            List<char> datalist = new List<char>();
            datalist.AddRange(Palabra);

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

        public string GetPalabra()
        {
            return this.Palabra;
        }

        public int GetLongitudPalabra()
        {
            return this.Palabra.Length;
        }
    }
}
