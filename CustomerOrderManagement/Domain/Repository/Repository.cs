public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public IEnumerable<Order> GetOrdersByCustomer(int customerId)
    {
        return _context.Set<Order>().Where(o => o.CustomerId == customerId).ToList();
    }
}