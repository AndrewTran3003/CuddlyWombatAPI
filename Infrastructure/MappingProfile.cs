using AutoMapper;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Controllers;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Infrastructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemEntity, Item>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => 
                Link.To(nameof(ItemsController.GetItem),new { itemId = src.ID } )));
            CreateMap<MenuEntity, Menu>()
               .ForMember(dest => dest.Self, opt => opt.MapFrom(src =>
               Link.To(nameof(MenusController.GetMenu), new { menuId = src.ID })))
               .ForMember(dest => dest.ItemList, opt => opt.MapFrom(src => ReturnObject(src)));
            
        }
        public List<Resource> ReturnObject(MenuEntity src)
        {
            List<Resource> Response = new List<Resource>();
            foreach(ItemJMenu itemMenu in src.ItemMenus)
            {
                Resource itemResponse = new Resource
                {
                    Self = Link.To(nameof(ItemsController.GetItem), new { itemId = itemMenu.ItemID }),
                    Name = itemMenu.Item.Name,
                    Description = itemMenu.Item.Description
                };
                Response.Add(itemResponse);
            }
            return Response;
        }
    }
}
