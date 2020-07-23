using CuddlyWombat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Data
{
    public class CuddlyWombatDbContext:DbContext
    {
        public CuddlyWombatDbContext (DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<ItemJMenu> ItemMenus { get; set; }
    }
}
