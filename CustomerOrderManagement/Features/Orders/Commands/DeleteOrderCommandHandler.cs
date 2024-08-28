public class DeleteOrderCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Handle(DeleteOrderCommand command)
    {
        var order = _unitOfWork.Orders.GetById(command.Id);

        if (order == null)
        {
            throw new Exception("Order not found");
        }

        _unitOfWork.Orders.Delete(order);
        _unitOfWork.Save();
    }
}
