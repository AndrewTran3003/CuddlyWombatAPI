using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class MenuEntity:Entity
    {
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ICollection<ItemJMenu> ItemMenus { get; set; }
        public ICollection<OrderJMenu> OrderMenus { get; set; }
        
    }
}
