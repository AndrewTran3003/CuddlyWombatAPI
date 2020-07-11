using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuddlyWombatAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        [HttpGet (Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new RootResponseModel
            {
                Self = Link.To(nameof(GetRoot)),
                Items = Link.To(nameof(ItemsController.Index))
            };

            return Ok(response);
        }
    }
}
