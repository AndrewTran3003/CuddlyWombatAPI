using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var response = new
            {
                message = "Welcome to Cuddly Wombat API version 1",
                href = Url.Link(nameof(GetRoot), null),
                items = new
                {
                    href = Url.Link(nameof(ItemsController.Index),null)
                }
            };

            return Ok(response);
        }
    }
}
