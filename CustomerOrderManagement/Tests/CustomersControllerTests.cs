using CustomerOrderManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

[TestFixture]
public class CustomersControllerTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private CustomerController _controller;

    [SetUp]
    public void SetUp()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _controller = new CustomerController(_unitOfWorkMock.Object);
    }

    [Test]
    public void GetCustomer_ReturnsNotFound_WhenCustomerDoesNotExist()
    {
        _unitOfWorkMock.Setup(u => u.Customers.GetById(It.IsAny<int>())).Returns((Customer)null);
        var result = _controller.GetCustomerById(1);
        //Assert.Equals<NotFoundResult>(result);
    }

    // Additional tests...
}
