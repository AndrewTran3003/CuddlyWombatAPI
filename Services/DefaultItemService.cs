using AutoMapper;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Data;
using CuddlyWombatAPI.Infrastructure;
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
        private readonly IMapper _mapper;
        public DefaultItemService(CuddlyWombatDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            var entity = await _context.Items
                .SingleOrDefaultAsync(i => i.ID == id);
            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<Item>(entity);
        }
    }
}
