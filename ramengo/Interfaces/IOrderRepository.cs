using ramengo.Models;

namespace ramengo.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> PlaceOrder(Order order);
        Task<Broth> GetBrothById(int id);
        Task<Protein> GetProteinById(int id);
    }
}