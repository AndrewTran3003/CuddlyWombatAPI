using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Resources
{
    public class Table: Resource
    {
        public string Location { get; set; }
        public int Size { get; set; }
    }
}
