using AutoMapper;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Controllers;
using CuddlyWombatAPI.Data;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources;
using CuddlyWombatAPI.Models.Resources.Menu;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Services
{
    public class DefaultMenuService : IMenuService
    {
        private CuddlyWombatDbContext _context;
        private readonly IMapper _mapper;

        public DefaultMenuService(CuddlyWombatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Menu>> GetAllMenuAsync()
        {
            var response = new List<Menu>();
            var menuList = await _context.Menus
                .Include(i => i.ItemMenus)
                .ThenInclude(i => i.Item)
                .ToListAsync();
            foreach(MenuEntity menuEntity in menuList)
            {
                var menu = MapMenuToEntity(menuEntity);
                response.Add(menu);
            }
            return response;
        }

        public async Task<Menu> GetMenuAsync(Guid id)
        {
            var menuEntity = await _context.Menus.Where(i => i.ID == id)
                .Include(i => i.ItemMenus)
                .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync();
            var menu = MapMenuToEntity(menuEntity);
            return menu;
        }


        private Menu MapMenuToEntity(MenuEntity menuEntity)
        {
            var menu = _mapper.Map<Menu>(menuEntity);
            menu.ItemList = new List<ItemSubResource>();
            foreach (ItemJMenu itemMenu in menuEntity.ItemMenus)
            {
                var item = _mapper.Map<ItemSubResource>(itemMenu.Item);
                item.Self = Link.To(nameof(ItemsController.GetItem), new { itemId = itemMenu.ItemID });
                item.Qty = itemMenu.Qty;
                menu.ItemList.Add(item);
            }
            return menu;
        }
    }
}
