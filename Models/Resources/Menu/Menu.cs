using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Resources.Menu
{
    public class Menu : Resource
    {

        public string Type { get; set; }
        public int? AvailableQuantity { get; set; }
        public double Price { get; set; }
        public List<ItemSubResource> ItemList { get; set; }

    }
}

