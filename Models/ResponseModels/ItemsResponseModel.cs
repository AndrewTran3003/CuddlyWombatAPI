using CuddlyWombatAPI.Models.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.ResponseModels
{
    public class ItemsResponseModel:Resource
    {
        public List<Item> Items { get; set; }
    }
}
