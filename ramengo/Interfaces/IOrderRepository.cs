using ramengo.Models;

namespace ramengo.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> PlaceOrder(Order order);
    }
}
