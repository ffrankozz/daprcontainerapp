public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken = default);
}