using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Models
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public Link Link { get; set; }
    }
}
