using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using TopStyleWebApi.Data;
using TopStyleWebApi.Models;
using TopStyleWebApi.Models.RecievingClasses;
using TopStyleWebApi.Services;

namespace TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        
        public OrderController(ApiDbContext context)
        {
            _orderService = new OrderService(context);
        }
        // GET: api/Order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderService.GetAll();
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_orderService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] TemplateOrder value)
        {
            try
            {
                _orderService.Add(value);
                return Ok("Order added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order value)
        {
            try
            {
                _orderService.Update(id, value);
                return Ok("Order updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _orderService.DeleteById(id);
                return Ok("Order deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
