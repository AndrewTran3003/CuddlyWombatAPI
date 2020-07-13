using AutoMapper;
using AutoMapper.QueryableExtensions;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Controllers;
using CuddlyWombatAPI.Data;
using CuddlyWombatAPI.Infrastructure;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Services
{
   
    public class DefaultItemService: IItemService
    {
        private readonly CuddlyWombatDbContext _context;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        public DefaultItemService(
            CuddlyWombatDbContext context,

            IConfigurationProvider configurationProvider)
        {
            _context = context;
            _configurationProvider = configurationProvider;
            _mapper = configurationProvider.CreateMapper();
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            var itemsEntity = await _context.Items.ToListAsync();
           
            if (itemsEntity == null)
            {
                return null;
            }

            List<Item> items = new List<Item>();
            foreach (var itemEntity in itemsEntity)
            {
                var item = _mapper.Map<Item>(itemEntity);
                items.Add(item);
            }

            return items;
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var entity = await _context.Items
                .SingleOrDefaultAsync(i => i.ID == id);
            if (entity == null)
            {
                return null;
            }
            var result = _mapper.Map<Item>(entity);
            return result;
        }
    }
}
