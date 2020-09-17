using AutoMapper;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Controllers;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources;
using CuddlyWombatAPI.Models.Resources.Menu;
using CuddlyWombatAPI.Models.Resources.Order;
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
               Link.To(nameof(MenusController.GetMenu), new { menuId = src.ID })));
            CreateMap<ItemEntity, ItemSubResource>();
            CreateMap<OrderEntity, Order>()
                .ForMember(dest => dest.Self, option => option.MapFrom(src =>
               Link.To(nameof(OrdersController.GetOrder), new {orderId = src.ID })));


            CreateMap<OrderJItem, OrderDetailSubResource>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name))
                .ForMember(dest => dest.PricePerUnit, opt => opt.MapFrom(src => src.Item.Price))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Item.Type))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(ItemsController.GetItem), new { itemId = src.ItemID })));

            CreateMap<OrderJMenu, OrderDetailSubResource>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Menu.Name))
                .ForMember(dest => dest.PricePerUnit, opt => opt.MapFrom(src => src.Menu.Price))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Menu.Type))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(MenusController.GetMenu), new { menuId = src.MenuID })));
        }
    }
}
