public class DeleteCustomerCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Handle(DeleteCustomerCommand command)
    {
        var customer = _unitOfWork.Customers.GetById(command.Id);

        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        _unitOfWork.Customers.Delete(customer);
        _unitOfWork.Save();
    }
}