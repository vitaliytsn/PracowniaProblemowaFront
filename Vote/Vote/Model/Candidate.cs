using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vote.Model
{
   public class Candidate
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("surname")] public string Surname { get; set; }
        [JsonProperty("district")] public string Psi { get; set; }    
    }
}
