using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class ItemEntity : Entity
    {
        public string Type { get; set; }
        public int? AvailableQuantity { get; set; }
        public int QuantitySold { get; set; }
        public double Price { get; set; }
        public ICollection<ItemJMenu> ItemMenus {get;set;}
        public ICollection<OrderJItem> OrderItems { get; set; }
    }
}
