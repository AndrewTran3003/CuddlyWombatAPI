using CuddlyWombatAPI.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.ResponseModels
{
    public class MenusResponseModel:Resource
    {
        public List<Menu> Menus { get; set; }
    }
}
