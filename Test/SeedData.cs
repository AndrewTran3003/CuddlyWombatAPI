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
                new ItemEntity {
                    ID = Guid.Parse("5a514ce0-33e7-4069-9823-d1c6cea1fda3"), 
                    Name = "Cappucino", 
                    Description = "Classic Cappucino with one sugar", 
                    AvailableQuantity = null, 
                    QuantitySold = 100, 
                    Type = "Drink", 
                    Price = 3.75, 
                    DateCreated = DateTime.UtcNow, 
                    Available = true 
                },
                new ItemEntity {
                    ID = Guid.Parse("58b6cfc8-23ba-4a7c-a641-5ba37bf72bed"), 
                    Name = "Latte", 
                    Description = "Classic Latte with one sugar", 
                    AvailableQuantity = null, 
                    QuantitySold = 120, 
                    Type = "Drink", 
                    Price = 3.65, 
                    DateCreated = DateTime.UtcNow, 
                    Available = true 
                },
                new ItemEntity {
                    ID = Guid.Parse("065de0e4-e587-48c2-a0e3-66b4981243ab"), 
                    Name = "Grilled Chicken", 
                    Description = "Regular grilled chicken set of 3", 
                    AvailableQuantity = null, 
                    QuantitySold = 150, 
                    Type = "Food", 
                    Price = 5, 
                    DateCreated = DateTime.UtcNow, 
                    Available = true 
                },
                new ItemEntity {
                    ID = Guid.Parse("ba9684ed-3d89-4cbd-9380-ea47fb290ee1"), 
                    Name = "Small Chips", 
                    Description = "A small bag of chips", 
                    AvailableQuantity = null, 
                    QuantitySold = 131, 
                    Type = "Food", 
                    Price = 3, 
                    DateCreated = DateTime.UtcNow 
                },
                new ItemEntity {
                    ID = Guid.Parse("18dbcd8b-64ea-43a7-b0aa-b4cd8f5e3cca"), 
                    Name = "Muffin", 
                    Description = "Classic blueberry muffin", 
                    AvailableQuantity = null, 
                    QuantitySold = 140, 
                    Type = "Food", 
                    Price = 4, 
                    DateCreated = DateTime.UtcNow 
                },
                new ItemEntity {
                    ID = Guid.Parse("eaf64e3d-4f44-4df3-a2a3-bf2441fbd791"), 
                    Name = "Flat White", 
                    Description = "Classic Flat White with one sugar", 
                    AvailableQuantity = null, 
                    QuantitySold = 100, 
                    Type = "Drink", 
                    Price = 3.75, 
                    DateCreated = DateTime.UtcNow 
                },
                new ItemEntity {
                    ID = Guid.Parse("d1b55b79-176d-4aef-9c13-87f54579fcbb"), 
                    Name = "Signature Vanilla Syrup", 
                    Description = "Made in New Zealand from local and imported ingredients", 
                    AvailableQuantity = 100, 
                    QuantitySold = 3, 
                    Type = "Merchandise", 
                    Price = 15, 
                    DateCreated = DateTime.UtcNow 
                },
                new ItemEntity {
                    ID = Guid.Parse("fb8c11f5-5c12-4ee9-bbc9-aa22c39511f2"),
                    Name = "Hardys Stamp of Australia Chardonnay 1L",
                    Description = "Round and flavoursome on the palate with a touch of oak and appealing freshness on the finish",
                    AvailableQuantity = 80,
                    QuantitySold = 8,
                    Type = "Merchandise",
                    Price = 13,
                    DateCreated = DateTime.UtcNow
                },
                new ItemEntity {
                    ID = Guid.Parse("5f4979b9-ccdc-4664-8cff-55ac4791deff"),
                    Name = "Lanson Gold Label Vintage Brut Champagne",
                    Description = "Wonderful linear acidity that is as taut as a high-wire complimented by a rush of citrus blossom",
                    AvailableQuantity = 50,
                    QuantitySold = 10,
                    Type = "Merchandise",
                    Price = 67,
                    DateCreated = DateTime.UtcNow
                },
                new ItemEntity {
                    ID = Guid.Parse("1675a0bb-9a10-4aa2-8ab4-bd8e49c1ccfb"),
                    Name = "Freixenet Cordon Negro Brut Cava",
                    Description = "Produced entirely from hand-harvested grapes and fermented in the bottle, it is a wine of great style and delicacy for a great price",
                    AvailableQuantity = 60,
                    QuantitySold = 10,
                    Type = "Merchandise",
                    Price = 13,
                    DateCreated = DateTime.UtcNow
                },
                new ItemEntity {
                    ID = Guid.Parse("30726c8f-4ab4-41b5-84bd-489606f110d5"),
                    Name = "Moccona Freeze Dried Instant Coffee Classic Medium Roast 200g",
                    Description = "Made in The Netherlands with coffee from multiple origins",
                    AvailableQuantity = 30,
                    QuantitySold = 140,
                    Type = "Merchandise",
                    Price = 13,
                    DateCreated = DateTime.UtcNow
                },
                new ItemEntity {
                    ID = Guid.Parse("47d4f233-c689-476c-8008-f2c4d9b92b11"),
                    Name = "Twinings English Breakfast Tea Bags 100pk 200g",
                    Description = "Blended and packed in Poland to the highest standards by Twinings of London using the finest imported and local ingredients.",
                    AvailableQuantity = 60,
                    QuantitySold = 100,
                    Type = "Merchandise",
                    Price = 18,
                    DateCreated = DateTime.UtcNow
                }
            };
            foreach (ItemEntity item in items)
            {
                context.Items.Add(item);
            }
            var menus = new MenuEntity[]
           {
                new MenuEntity {
                    ID = Guid.Parse("8beae932-c9a5-4d2b-8f25-eb41d32e5729"), 
                    Name = "Morning Set", 
                    Description = "Something to kickstart your morning", 
                    Price = 6, 
                    DateCreated = DateTime.UtcNow, 
                    AvailableQuantity = null, 
                    QuantitySold = 20 
                },
                new MenuEntity {
                    ID = Guid.Parse("7ff490d9-0edd-42da-a492-e75e077702ad"), 
                    Name = "Lunch Set", 
                    Description = "Treat your tummy better for a productive afternoon", 
                    Price = 10, 
                    DateCreated = DateTime.UtcNow, 
                    AvailableQuantity = null, 
                    QuantitySold = 30 
                },
                new MenuEntity {
                    ID = Guid.Parse("5c7ac899-ce69-42ea-b403-a724f6a07d03"), 
                    Name = "Dinner Set", 
                    Description = "Let's have dinner, shall we?", 
                    Price = 10, 
                    DateCreated = DateTime.UtcNow,  
                    AvailableQuantity = null, 
                    QuantitySold = 30
                }
           };

            foreach (MenuEntity menu in menus)
            {
                context.Menus.Add(menu);
            }


            //ItemMenu connection

            var itemMenu = new ItemJMenu[]
            {
                new ItemJMenu {
                    ID = Guid.Parse("22b40860-c394-4a69-8333-00b91712bbc0"),
                    ItemID = items.Single(s => s.Name == "Cappucino").ID,
                    MenuID = menus.Single(s => s.Name == "Morning Set").ID,
                    Quantity = 2
                },
                new ItemJMenu {
                    ID = Guid.Parse("e8fd78e2-b911-43ed-aa24-12bacd6f9d44"),
                    ItemID = items.Single(s => s.Name == "Muffin").ID,
                    MenuID = menus.Single(s => s.Name == "Morning Set").ID,
                    Quantity = 1
                },
                new ItemJMenu {
                    ID = Guid.Parse("d5df649b-ac30-4438-af18-73021abefed5"),
                    ItemID = items.Single(s => s.Name == "Latte").ID,
                    MenuID = menus.Single(s => s.Name == "Lunch Set").ID,
                    Quantity = 1
                },
                new ItemJMenu {
                    ID = Guid.Parse("d0b1b3f5-e141-4334-8f19-96e026b66251"),
                    ItemID = items.Single(s => s.Name == "Small Chips").ID,
                    MenuID = menus.Single(s => s.Name == "Lunch Set").ID,
                    Quantity = 2
                },
                new ItemJMenu {
                    ID = Guid.Parse("3a5c1c98-05e1-4c03-8509-a01ac1ec2ed6"),
                    ItemID = items.Single(s => s.Name == "Grilled Chicken").ID,
                    MenuID = menus.Single(s => s.Name == "Lunch Set").ID,
                    Quantity = 3
                },
                new ItemJMenu {
                    ID = Guid.Parse("c3648e19-2be6-48fc-902f-a8ca61fbe0e0"),
                    ItemID = items.Single(s => s.Name == "Small Chips").ID,
                    MenuID = menus.Single(s => s.Name == "Dinner Set").ID,
                    Quantity = 2
                    
                },
                new ItemJMenu {
                    ID = Guid.Parse("01e01e35-afb7-4098-9fce-6e439858717b"),
                    ItemID = items.Single(s => s.Name == "Grilled Chicken").ID,
                    MenuID = menus.Single(s => s.Name == "Dinner Set").ID,
                    Quantity = 1
                }

            };

            foreach (ItemJMenu ItemMenu in itemMenu)
            {
                context.ItemMenus.Add(ItemMenu);
            }

            await context.SaveChangesAsync();
        }
    }
}
