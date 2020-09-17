using AutoMapper;
using CuddlyWombat.Models;
using CuddlyWombatAPI.Controllers;
using CuddlyWombatAPI.Data;
using CuddlyWombatAPI.Models;
using CuddlyWombatAPI.Models.Resources.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuddlyWombatAPI.Services.DefaultServices
{
    public class DefaultOrderService : IOrderService
    {
        private CuddlyWombatDbContext _context;
        private readonly IMapper _mapper; 
        public DefaultOrderService(CuddlyWombatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderAsync(Guid id)
        {
            var orderEntity = await _context.Orders.Where(i => i.ID == id)
                .Include(i => i.OrderItems)
                .ThenInclude(i => i.Item)
                .Include(i => i.OrderMenus)
                .ThenInclude(i => i.Menu)
                .FirstOrDefaultAsync();
            Order order = _mapper.Map<Order>(orderEntity);
            order.OrderDetail = GetOrderSubDetail(orderEntity);
            return order;
        }

        private List<OrderDetailSubResource> GetOrderSubDetail(OrderEntity orderEntity)
        {
            List<OrderDetailSubResource> result = new List<OrderDetailSubResource>();

            foreach(OrderJItem orderItem in orderEntity.OrderItems)
            {
                var subResource = _mapper.Map<OrderDetailSubResource>(orderItem);
                subResource.Price = CalculateTotalPrice(subResource);
                result.Add(subResource);        
            }

            foreach (OrderJMenu orderMenu in orderEntity.OrderMenus)
            {
                var subResource = _mapper.Map<OrderDetailSubResource>(orderMenu);
                subResource.Price = CalculateTotalPrice(subResource);
                result.Add(subResource);
            }

            return result;
        }

        private double CalculateTotalPrice(OrderDetailSubResource source)
        {
            double result = source.Qty * source.PricePerUnit;
            return result;
        }
    }
}
