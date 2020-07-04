using CuddlyWombatAPI.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Services
{
    public interface IItemService
    {
        Task<Item> GetItemAsync(Guid id);
    }
}
