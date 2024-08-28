public class CreateCustomerCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Handle(CreateCustomerCommand command)
    {
        var customer = new Customer
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Address = command.Address,
            PostalCode = command.PostalCode
        };

        _unitOfWork.Customers.Add(customer);
        _unitOfWork.Save();
    }
}