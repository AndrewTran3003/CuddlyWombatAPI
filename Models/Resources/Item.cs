using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Resources
{
    public class Item:Resource
    {
        public string Type { get; set; }
        public double Price { get; set; }
        public int? AvailableQuantity { get; set; }
    }
}
