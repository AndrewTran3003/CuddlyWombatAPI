using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class OrderJItem:EntityJoin
    {
        public Guid ItemID { get; set; }
        public Guid OrderID { get; set; }
        public ItemEntity Item { get; set; }
        public OrderEntity Order { get; set; }
        public int Qty { get; set; }
    }
}
