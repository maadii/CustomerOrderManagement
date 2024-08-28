public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IRepository<Customer> _customers;
    private IRepository<Order> _orders;
    private IRepository<Product> _products;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRepository<Customer> Customers => _customers ??= new Repository<Customer>(_context);
    public IRepository<Order> Orders => _orders ??= new Repository<Order>(_context);
    public IRepository<Product> Products => _products ??= new Repository<Product>(_context);

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}