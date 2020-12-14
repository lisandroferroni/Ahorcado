using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ahorcado.Util
{
    public static class Palabras
    {
        public static List<string> ListaPalabras = new List<string>()
        {
            "perro",
            "gato",
            "casa",
            "teclado",
            "celular",
            "papel",
            "pizarron",
            "monitor",
            "escritorio",
            "programa",
            "facultad",
            "hipopotamo",
            "elefante",
            "auto",
            "rinoceronte",
            "magia",
            "television",
            "ruleman",
            "pelota"
        };

        public static string GetPalabraAleatoria()
        {
            ListaPalabras.Shuffle();
            return ListaPalabras.First();
        }

        private static Random rng = new Random();
        private static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
