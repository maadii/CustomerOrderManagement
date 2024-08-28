public class UpdateOrderCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Handle(UpdateOrderCommand command)
    {
        var order = _unitOfWork.Orders.GetById(command.Id);

        if (order == null)
        {
            throw new Exception("Order not found");
        }

        order.OrderDate = command.OrderDate;
        order.Items = command.Items.Select(i => new Item
        {
            ProductId = i.ProductId,
            Quantity = i.Quantity
        }).ToList();

        order.TotalPrice = order.Items.Sum(i => i.Quantity * i.Product.Price);

        _unitOfWork.Orders.Update(order);
        _unitOfWork.Save();
    }
}
