public class GetAllCustomersQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Customer> Handle(GetAllCustomersQuery query)
    {
        return _unitOfWork.Customers.GetAll();
    }
}