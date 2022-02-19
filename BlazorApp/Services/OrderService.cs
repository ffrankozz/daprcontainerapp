 

namespace BlazorApp.Services;
using Dapr.Client;
public class OrderService : IOrderService
{
    private readonly DaprClient _daprClient;
    private readonly string _serviceId;
    private const string StoreName = "orderstore";
    public OrderService(DaprClient daprClient, IConfiguration configuration)
    {
        _daprClient = daprClient;
        _serviceId = configuration.GetValue<string>("Services:Orders:ServiceId");
    }

    public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default)
    {
            
            int Id =3;
            var state = await _daprClient.GetStateEntryAsync<Order>(StoreName,  Id.ToString());
            state.Value ??= new Order(Id=3, DateTime.UtcNow  );
            await state.SaveAsync();
            return await _daprClient.InvokeMethodAsync<IEnumerable<Order>>(HttpMethod.Get,
            _serviceId,
            "orders",
            cancellationToken);
    }
}