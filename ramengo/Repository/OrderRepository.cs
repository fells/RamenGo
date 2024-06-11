using ramengo.Data;
using ramengo.Helper;
using ramengo.Interfaces;
using ramengo.Models;

namespace ramengo.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderIdService _orderIdService = new OrderIdService(new HttpClient());
        

        public void OrderReporsitory()
        {
            System.Diagnostics.Debug.WriteLine("Instanciado");
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            var orderId = await _orderIdService.GenerateOrderIdAsync();
            var localStorage = DataContext.localStorage;
            localStorage.Add(Convert.ToString(orderId), (object)order);
            return order;
        }

        public async Task<Broth> GetBrothById(int id)
        {
            var x = DataContext.localStorage[Convert.ToString(id)];
            return (Broth) x;
        }

        public async Task<Protein> GetProteinById(int id)
        {
            var x = DataContext.localStorage[Convert.ToString(id)];
            return (Protein) x;
        }
    }
}