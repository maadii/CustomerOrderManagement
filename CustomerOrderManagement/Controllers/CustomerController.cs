using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var query = new GetCustomerByIdQuery { Id = id };
            var handler = new GetCustomerByIdQueryHandler(_unitOfWork);
            var result = handler.Handle(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var query = new GetAllCustomersQuery();
            var handler = new GetAllCustomersQueryHandler(_unitOfWork);
            var result = handler.Handle(query);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var handler = new CreateCustomerCommandHandler(_unitOfWork);
            handler.Handle(command);
            return CreatedAtAction(nameof(GetCustomerById), new { id = command.Id }, command);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var handler = new UpdateCustomerCommandHandler(_unitOfWork);
            handler.Handle(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            var handler = new DeleteCustomerCommandHandler(_unitOfWork);
            handler.Handle(command);
            return NoContent();
        }
    }
}