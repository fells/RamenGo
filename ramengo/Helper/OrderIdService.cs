using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ramengo.Helper
{
    public class OrderIdService
    {

        private readonly HttpClient _httpClient;
        private const string ApiKey = "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf";

        public OrderIdService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GenerateOrderIdAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.tech.redventures.com.br/orders/generate-id");
            request.Headers.Add("x-api-key", ApiKey);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to get order ID");
            }

            var content = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonDocument.Parse(content);

            var orderIdString = jsonResponse.RootElement.GetProperty("orderId").GetString();
            if (!int.TryParse(orderIdString, out int orderId))
            {
                throw new FormatException("Failed to parse order ID as integer");
            }

            return orderId;
        }
    }
}
