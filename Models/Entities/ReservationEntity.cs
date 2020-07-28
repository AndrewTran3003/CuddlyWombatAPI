using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Entities
{
    public class ReservationEntity:Entity
    {
        public string CustomerName { get; set; }
        public DateTime ReservationStartTime { get; set; }
        public DateTime ReservationEndTime { get; set; }
        public ICollection<TableJReservation> TableReservation { get; set; }


    }
}
