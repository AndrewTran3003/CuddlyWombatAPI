using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Data;
using CuddlyWombatAPI.Models.Resources;
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
        [HttpGet(Name = nameof(Index))]
        [ProducesResponseType(200)]
        // GET: ItemsController
        public ActionResult<Item> Index()
        {

            return null; 
        }

        // GET: Items/Get/5
        [HttpGet("{itemId}", Name = nameof(Get))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Item>> Get(Guid itemId)
        {
            var item = await _itemService.GetItemAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // GET: ItemsController/Create
        public ActionResult Create()
        {
            return null;
        }

        // POST: ItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }

        // GET: ItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            return null;
        }

        // POST: ItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }

        // GET: ItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return null;
        }

        // POST: ItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }
    }
}
