using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources;
using CuddlyWombatAPI.Models.ResponseModels;
using CuddlyWombatAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MenusController:ControllerBase
    {
        private IMenuService _menuService;
        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet(Name = nameof(GetAllMenus))]
        [ProducesResponseType(200)]
        // GET: ItemsController
        public async Task<ActionResult<MenusResponseModel>> GetAllMenus()
        {
            var menus = await _menuService.GetAllMenuAsync();
            var allMenus = new MenusResponseModel
            {
                Self = Link.To(nameof(GetAllMenus)),
                Name = "Full Menu",
                Description = "All Available Menus at Cuddly Wombat",
                Menus = menus
            };


            if (allMenus.Menus == null)
            {
                return NotFound();
            }
            return allMenus;

        }

        [HttpGet("{menuId}", Name = nameof(GetMenu))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Menu>> GetMenu(Guid menuId)
        {
            var menu = await _menuService.GetMenuAsync(menuId);
            if (menu == null)
            {
                return NotFound();
            }
            return menu;
        }

    }
}
