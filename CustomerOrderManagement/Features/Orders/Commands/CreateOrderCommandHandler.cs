public class CreateOrderCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Handle(CreateOrderCommand command)
    {
        var customer = _unitOfWork.Customers.GetById(command.CustomerId);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        var order = new Order
        {
            CustomerId = command.CustomerId,
            OrderDate = command.OrderDate,
            Items = command.Items.Select(i => new Item
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };

        order.TotalPrice = order.Items.Sum(i => i.Quantity * i.Product.Price);

        _unitOfWork.Orders.Add(order);
        _unitOfWork.Save();
    }
}
