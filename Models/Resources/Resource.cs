﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models.Resources
{
    public class Resource:Link
    {

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
