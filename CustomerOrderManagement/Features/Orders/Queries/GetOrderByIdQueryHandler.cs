
public class GetOrderByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Order Handle(GetOrderByIdQuery query)
    {
        return _unitOfWork.Orders.GetById(query.Id);
    }
}
