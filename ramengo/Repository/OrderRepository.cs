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

        public async Task<Broth> GetBrothById(int id)
        {
            return await _context.Broths.FindAsync(id);
        }

        public async Task<Protein> GetProteinById(int id)
        {
            return await _context.Proteins.FindAsync(id);
        }
    }
}
