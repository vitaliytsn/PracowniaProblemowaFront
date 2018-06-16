using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vote.Model
{
    public class District
    {
        [JsonProperty("psi")] public string Psi { get; set; }
    }
}
