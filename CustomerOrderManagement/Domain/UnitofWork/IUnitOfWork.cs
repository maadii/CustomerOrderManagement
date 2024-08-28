public interface IUnitOfWork : IDisposable
{
    IRepository<Customer> Customers { get; }
    IRepository<Order> Orders { get; }
    IRepository<Product> Products { get; }
    void Save();
}