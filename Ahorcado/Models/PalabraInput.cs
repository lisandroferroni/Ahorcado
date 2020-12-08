using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ahorcado.Models
{
    public class PalabraInput
    {
        [JsonPropertyName("Palabra")]
        public string Palabra { get; set; }
    }
}
