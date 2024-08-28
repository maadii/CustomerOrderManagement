public class UpdateCustomerCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Handle(UpdateCustomerCommand command)
    {
        var customer = _unitOfWork.Customers.GetById(command.Id);

        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        customer.FirstName = command.FirstName;
        customer.LastName = command.LastName;
        customer.Address = command.Address;
        customer.PostalCode = command.PostalCode;

        _unitOfWork.Customers.Update(customer);
        _unitOfWork.Save();
    }
}