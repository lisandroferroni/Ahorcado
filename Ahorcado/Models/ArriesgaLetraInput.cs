using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ahorcado.Models
{
    public class ArriesgaLetraInput
    {
        [JsonPropertyName("Letra")]
        public char Letra { get; set; }
    }
}