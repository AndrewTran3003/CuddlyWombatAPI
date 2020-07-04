using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombat.Models
{
    public class ItemJMenu:EntityJoin
    {
        public Guid MenuID { get; set; }
        public Guid ItemID { get; set; }

        public ItemEntity Item { get; set; }
        public MenuEntity Menu { get; set; }
    }
}
