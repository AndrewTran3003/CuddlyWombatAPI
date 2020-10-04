using AutoMapper;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Data;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CuddlyWombatAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CuddlyWombatAPI.Services
{

    public class DefaultItemService: IItemService
    {
        private readonly CuddlyWombatDbContext _context;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        
        public DefaultItemService(
            CuddlyWombatDbContext context,

            IConfigurationProvider configurationProvider
            )
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

        public async Task<ApiResponse> CreateAnItem(Item item)
        {
            ApiResponse response = new ApiResponse();
            if (!ValidItem(item))
            {
                response.Message = "An error occurred while adding a new item";
                response.Detail = "The item is lost during transit";
                response.Link = Link.To(nameof(ItemsController.GetAllItems));
            }
            else
            {
                var itemEntity = _mapper.Map<ItemEntity>(item);
                itemEntity.ID = Guid.NewGuid();
                itemEntity.DateCreated = DateTime.UtcNow;
                try
                {
                     _context.Items.Add(itemEntity);
                    await _context.SaveChangesAsync();
                    response.Message = "Item is added successfully";
                    response.Detail = "View the item by following this link";
                    response.Link = Link.To(nameof(ItemsController.GetItem), new { itemId = itemEntity.ID });



                }
                catch (Exception ex)
                {
                    response.Message = "An error has occurred";
                    response.Detail = ex.Message;
                }
            }
            
            return response;
        }

        public async Task<ApiResponse> EditAnItem(Guid id, Item item)
        {
            ApiResponse response = new ApiResponse();
            var targetedItemEntity = await _context.Items.SingleAsync(i => i.ID == id);

            if (targetedItemEntity == null)
            {
                response.Message = "An error occured while updating the item";
                response.Detail = "The item cannot be found. To go back, use this link below";
                response.Link = Link.To(nameof(ItemsController.GetAllItems));
            }
            

            else
            {
                targetedItemEntity  = _mapper.Map<Item, ItemEntity>(item, targetedItemEntity);
                try
                {
                    _context.Items.Update(targetedItemEntity);
                    await _context.SaveChangesAsync();
                    response.Message = "Item updated successfully";
                    response.Detail = "The item has been updated successfully. To view the item, click on this link";
                    response.Link = Link.To(nameof(ItemsController.GetItem), new { itemId = id });
                }
                catch (Exception ex)
                {
                    response.Message = "An error has occurred";
                    response.Detail = ex.Message;
                }
            }
            return response; 
        }
        private bool ValidItem(Item item)
        {
            var result = true;
            if (item.Name == null ||
                item.Type == null
                )
            {
                result = false;
            }

            return result;
        }
    }
    

}
