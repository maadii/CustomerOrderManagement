using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var query = new GetOrderByIdQuery { Id = id };
            var handler = new GetOrderByIdQueryHandler(_unitOfWork);
            var result = handler.Handle(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult GetOrdersByCustomer(int customerId)
        {
            var query = new GetOrdersByCustomerQuery { CustomerId = customerId };
            var handler = new GetOrdersByCustomerQueryHandler(_unitOfWork);
            var result = handler.Handle(query);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderCommand command)
        {
            var handler = new CreateOrderCommandHandler(_unitOfWork);
            handler.Handle(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = command.Id }, command);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] UpdateOrderCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var handler = new UpdateOrderCommandHandler(_unitOfWork);
            handler.Handle(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand { Id = id };
            var handler = new DeleteOrderCommandHandler(_unitOfWork);
            handler.Handle(command);
            return NoContent();
        }
    }
}
