using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ahorcado.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }

        internal string GetNombre()
        {
            return Nombre;
        }
    }
}
