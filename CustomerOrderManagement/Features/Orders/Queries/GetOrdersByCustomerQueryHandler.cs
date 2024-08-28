public class GetOrdersByCustomerQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrdersByCustomerQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Order> Handle(GetOrdersByCustomerQuery query)
    {
        return _unitOfWork.Orders.GetOrdersByCustomer(query.CustomerId);
    }
}
