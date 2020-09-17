using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Resources.Order
{
    public class OrderDetailSubResource:SubResource
    {
        public int Qty { get; set; }
        public double PricePerUnit { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
    }
}
