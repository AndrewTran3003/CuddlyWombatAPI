using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Data;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources;
using CuddlyWombatAPI.Models.Resources.Order;
using CuddlyWombatAPI.Models.ResponseModels;
using CuddlyWombatAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CuddlyWombatAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet(Name = nameof(GetAllItems))]
        [ProducesResponseType(200)]
        // GET: ItemsController
        public async Task<ActionResult<ItemsResponseModel>> GetAllItems()
        {
            var items = await _itemService.GetAllItemsAsync();
            var allItems = new ItemsResponseModel() {
                Self = Link.To(nameof(GetAllItems)),
                Items = items
            };
         

            if(allItems.Items == null)
            {
                return NotFound();
            }
            return allItems;

        }

        // GET: Items/Get/5
        [HttpGet("{itemId}", Name = nameof(GetItem))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Item>> GetItem(Guid itemId)
        {
            var item = await _itemService.GetItemAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }


        // POST: ItemsController/Create
        [HttpPost]
        [Route("Create")]
        public async void Create(Item item)
        {
            
        }

    }
}
