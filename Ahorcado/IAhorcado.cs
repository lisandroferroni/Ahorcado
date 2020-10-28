using Ahorcado.Models;

namespace Ahorcado
{
    public interface IAhorcado
    {
        string Palabra { get; set; }
        Usuario Usuario { get; set; }

        bool? ArriesgaLetra(char letra);
        bool ArriesgaPalabra(string palabra);
        bool? ContieneLetraCorrecta(char letra);
        bool? ContieneLetraIncorrecta(char letra);
        bool Gano();
        string GetNombreUsuario();
        string MostrarEstadoJuego();
        void SetNombreUsuario(string nombre);
    }
}