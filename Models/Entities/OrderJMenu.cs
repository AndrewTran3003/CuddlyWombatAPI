using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class OrderJMenu:EntityJoin
    {
        public Guid MenuID { get; set; }
        public Guid OrderID { get; set; }
        public MenuEntity Menu { get; set; }
        public OrderEntity Order { get; set; }
        public int Qty { get; set; }
    }
}
