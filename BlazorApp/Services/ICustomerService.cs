 namespace BlazorApp.Services;
public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetCustomers(CancellationToken cancellationToken = default);
}