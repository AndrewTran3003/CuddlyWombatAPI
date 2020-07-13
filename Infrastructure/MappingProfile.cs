using AutoMapper;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Controllers;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Infrastructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemEntity, Item>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => 
                Link.To(nameof(ItemsController.Get),new { itemId = src.ID } )));
        }
    }
}
