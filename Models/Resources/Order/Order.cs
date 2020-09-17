using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Resources.Order
{
    public class Order: Resource
    {
        public string CustomerName { get; set; }
        public double AmountDue { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime OrderStartTime { get; set; }
        public string Employee { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderDetailSubResource> OrderDetail { get; set; }
    }
}
