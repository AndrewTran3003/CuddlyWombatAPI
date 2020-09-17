using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Resources.Menu
{
    public class ItemSubResource:SubResource
    {
        public string Description { get; set; }
        public int Qty { get; set; }
    }
}
