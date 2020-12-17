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
        public string Palabra { get; set; }
        public string EstadoJuego { get; set; }
        public Usuario Usuario { get; set; }
        public static Ahorcado Instance { get; private set; }
        public int IntentosRestantes { get; set; }

        public List<char> LetrasCorrectas = new List<char>();
        public List<char> LetrasIncorrectas = new List<char>();
        public const int NUMERO_INTENTOS = 4;


        public List<char> GetLetrasCorrectas()
        {
            return this.LetrasCorrectas;
        }
        public List<char> GetLetrasIncorrectas()
        {
            return LetrasIncorrectas;
        }
        public Ahorcado()
        {
            Palabra = Palabras.GetPalabraAleatoria();
            EstadoJuego = "En juego";
            IntentosRestantes = NUMERO_INTENTOS;
        }

        public Ahorcado(string palabra)
        {
            Palabra = palabra;
            EstadoJuego = "En juego";
            IntentosRestantes = NUMERO_INTENTOS;
        }

        public static void Init(string palabra = "")
        {
            Instance = palabra == "" ? new Ahorcado() : new Ahorcado(palabra);
        }

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
                IntentosRestantes--;
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
            if (IntentosRestantes == 0) EstadoJuego = "Perdiste!";
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

        public string GetPalabraEnJuego()
        {
            var palabraEnJuego = new char[Palabra.Length];
            int posicion = 0;

            foreach (var caracter in Palabra.ToCharArray())
            {
                palabraEnJuego[posicion] = this.LetrasCorrectas.Contains(caracter) ? caracter : '_';
                posicion++;
            }

            return new string(palabraEnJuego);
        }
    }
}