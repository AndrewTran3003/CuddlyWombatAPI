using CuddlyWombatAPI.Models.Resources;
using CuddlyWombatAPI.Models.Resources.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Services
{
    public interface IMenuService
    {
        Task<Menu> GetMenuAsync(Guid id);

        Task<List<Menu>> GetAllMenuAsync();
    }
}
