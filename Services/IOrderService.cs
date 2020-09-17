using CuddlyWombatAPI.Models.Resources.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(Guid id);

        Task<List<Order>> GetAllOrdersAsync();
    }
}
