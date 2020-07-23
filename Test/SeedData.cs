using CuddlyWombat.Models;
using CuddlyWombatAPI.Data;
using CuddlyWombatAPI.Models.Resources;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Test
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<CuddlyWombatDbContext>());
        }
        public static async Task AddTestData(CuddlyWombatDbContext context)
        {
            if (context.Items.Any())
            {
                return;
            }
            var items = new ItemEntity[]
            {
                new ItemEntity {ID = Guid.Parse("75309739-6e95-4ebc-904f-424899a353b4"), Name = "Cappucino", Description = "Classic Cappucino with one sugar", Quantity = 1000, Type = "Drink", Price = 3.75, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("00b9a201-d823-4832-a063-2aa5ece5aff1"), Name = "Latte", Description = "Classic Latte with one sugar", Quantity = 1000, Type = "Drink", Price = 3.65, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("49dda2db-690e-41d3-9b27-23d99f8556ed"), Name = "Grilled Chicken", Description = "Regular grilled chicken set of 3", Quantity = 600, Type = "Food", Price = 5, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("135dd4f1-ef79-482b-a308-f69eb572c704"), Name = "Small Chips", Description = "A small bag of chips", Quantity = 600, Type = "Food", Price = 3, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("72d65522-3c4d-4c10-a99f-2d8158eac41c"), Name = "Muffin", Description = "Classic blueberry muffin", Quantity = 100, Type = "Food", Price = 4, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("25605ef6-7192-4092-8bc1-481558f59371"), Name = "Flat White", Description = "Classic Flat White with one sugar", Quantity = 1000, Type = "Drink", Price = 3.75, DateCreated = DateTime.UtcNow }
            };
            foreach (ItemEntity item in items)
            {
                context.Items.Add(item);
            }
            var menus = new MenuEntity[]
           {
                new MenuEntity {ID = Guid.Parse("8beae932-c9a5-4d2b-8f25-eb41d32e5729"), Name = "Morning Set", Description = "Something to kickstart your morning",Price = 6, DateCreated = DateTime.UtcNow, Quantity = 1000 },
                new MenuEntity {ID = Guid.Parse("7ff490d9-0edd-42da-a492-e75e077702ad"), Name = "Lunch Set", Description = "Treat your tummy better for a productive afternoon", Price = 10, DateCreated = DateTime.UtcNow, Quantity = 1000 },
                new MenuEntity {ID = Guid.Parse("5c7ac899-ce69-42ea-b403-a724f6a07d03"), Name = "Dinner Set", Description = "Let's have dinner, shall we?", Price = 10, DateCreated = DateTime.UtcNow,  Quantity = 1000 }
           };

            foreach (MenuEntity menu in menus)
            {
                context.Menus.Add(menu);
            }


            //ItemMenu connection

            var itemMenu = new ItemJMenu[]
            {
                new ItemJMenu {ID = Guid.Parse("22b40860-c394-4a69-8333-00b91712bbc0"),ItemID = items.Single(s => s.Name == "Cappucino").ID,
                MenuID = menus.Single(s => s.Name == "Morning Set").ID},
                new ItemJMenu {ID = Guid.Parse("e8fd78e2-b911-43ed-aa24-12bacd6f9d44"),ItemID = items.Single(s => s.Name == "Muffin").ID,
                MenuID = menus.Single(s => s.Name == "Morning Set").ID},

                new ItemJMenu {ID = Guid.Parse("d5df649b-ac30-4438-af18-73021abefed5"),ItemID = items.Single(s => s.Name == "Latte").ID,
                MenuID = menus.Single(s => s.Name == "Lunch Set").ID},
                new ItemJMenu {ID = Guid.Parse("d0b1b3f5-e141-4334-8f19-96e026b66251"),ItemID = items.Single(s => s.Name == "Small Chips").ID,
                MenuID = menus.Single(s => s.Name == "Lunch Set").ID},
                new ItemJMenu {ID = Guid.Parse("3a5c1c98-05e1-4c03-8509-a01ac1ec2ed6"),ItemID = items.Single(s => s.Name == "Grilled Chicken").ID,
                MenuID = menus.Single(s => s.Name == "Lunch Set").ID},

                new ItemJMenu {ID = Guid.Parse("c3648e19-2be6-48fc-902f-a8ca61fbe0e0"),ItemID = items.Single(s => s.Name == "Small Chips").ID,
                MenuID = menus.Single(s => s.Name == "Dinner Set").ID},
                new ItemJMenu {ID = Guid.Parse("01e01e35-afb7-4098-9fce-6e439858717b"),ItemID = items.Single(s => s.Name == "Grilled Chicken").ID,
                MenuID = menus.Single(s => s.Name == "Dinner Set").ID}

            };

            foreach (ItemJMenu ItemMenu in itemMenu)
            {
                context.ItemMenus.Add(ItemMenu);
            }

            await context.SaveChangesAsync();
        }
    }
}
