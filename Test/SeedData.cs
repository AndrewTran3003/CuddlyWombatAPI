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
                new ItemEntity {ID = Guid.Parse("bfd270b3-6181-47db-a18c-e196dd6592d6"), Name = "Cappucino", Description = "Classic Cappucino with one sugar", Quantity = 1000, Type = "Drink", Price = 3.75, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("119d0ff1-42fd-4ede-a75a-c0d51b1849c7"), Name = "Latte", Description = "Classic Latte with one sugar", Quantity = 1000, Type = "Drink", Price = 3.65, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("77e37480-9e4a-44d4-9cea-e860dbf291a1"), Name = "Grilled Chicken", Description = "Regular grilled chicken set of 3", Quantity = 600, Type = "Food", Price = 5, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("3e356e0e-8e37-4cba-8a72-f3a5b3d48633"), Name = "Small Chips", Description = "A small bag of chips", Quantity = 600, Type = "Food", Price = 3, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("929fb39c-43e8-4da3-b3de-ef3fde45d7d2"), Name = "Muffin", Description = "Classic blueberry muffin", Quantity = 100, Type = "Food", Price = 4, DateCreated = DateTime.UtcNow },
                new ItemEntity {ID = Guid.Parse("1c602bc9-a4bf-4698-b4b0-3b0cf2e757d7"), Name = "Flat White", Description = "Classic Flat White with one sugar", Quantity = 1000, Type = "Drink", Price = 3.75, DateCreated = DateTime.UtcNow }
            };
            foreach (ItemEntity item in items)
            {
                context.Items.Add(item);
            }
            await context.SaveChangesAsync();
        }
    }
}
