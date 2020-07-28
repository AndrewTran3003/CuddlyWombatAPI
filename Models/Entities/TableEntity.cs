using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Entities
{
    public class TableEntity:Entity
    {
        public string Location { get; set; }
        public int Size { get; set; }
        public ICollection<TableJReservation> TableReservation { get; set; }
    }
}
