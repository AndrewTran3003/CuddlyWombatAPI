using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Resources
{
    public class Resource
    {
        //The Href would be the first one in the response
        [JsonProperty(Order = -2)]
        public string Href { get; set; }
    }
}
