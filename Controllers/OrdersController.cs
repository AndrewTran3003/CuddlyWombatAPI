using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuddlyWombatAPI.Models.Resources.Order;
using CuddlyWombatAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CuddlyWombatAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("{orderId}",Name = nameof(GetOrder))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Order>> GetOrder(Guid orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);
            if(order == null)
            {
                return NotFound();
            }
            return order;
        }
    }
}
