public class GetCustomerByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Customer Handle(GetCustomerByIdQuery query)
    {
        return _unitOfWork.Customers.GetById(query.Id);
    }
}