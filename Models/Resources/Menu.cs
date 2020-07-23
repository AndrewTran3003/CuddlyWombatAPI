using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Resources
{
    public class Menu : Resource
    {

        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public List<Resource> ItemList { get; set; }

    }
}

