using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models
{
    public class Link
    {
        public static Link To (string routeName, object routeValues = null)
        {
            return new Link
            {
                RouteName = routeName,
                RouteValue = routeValues,
                Method = "GET",
                Relations = null
            };
        }
        [JsonProperty(Order = -4)]
        public string Href { get; set; }

        [JsonProperty(Order = -3,
            PropertyName = "rel",
            NullValueHandling = NullValueHandling.Ignore)]
        public string [] Relations { get; set; }
        [JsonProperty(Order = -2,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue("GET")]
        public string Method { get; set; }

        [JsonIgnore]
        public string RouteName { get; set; }
        
        [JsonIgnore]
        public object RouteValue { get; set; }

        [JsonIgnore]
        public Link Self { get; set; }
    }
}
