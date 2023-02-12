using Microsoft.AspNetCore.Mvc;
using ApexRestaurant.Services.SCustomer;
using ApexRestaurant.Repository.Domain;
namespace ApexRestaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customers = await _customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            await _customerService.Insert(customer);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutCustomer([FromBody] Customer customer)
        {
            await _customerService.Update(customer);
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteCustomer([FromBody] Customer customer)
        {
            await _customerService.Delete(customer);
            return Ok();
        }
    }
}