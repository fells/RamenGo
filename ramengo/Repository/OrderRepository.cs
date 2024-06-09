using ramengo.Data;
using ramengo.Interfaces;
using ramengo.Models;

namespace ramengo.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
