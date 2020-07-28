using CuddlyWombat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Entities
{
    public class TableJReservation:EntityJoin
    {
        public Guid TableID { get; set; }
        public Guid ReservationID { get; set; }
        public TableEntity Table { get; set; }
        public ReservationEntity Reservation { get; set; }
    }
}
