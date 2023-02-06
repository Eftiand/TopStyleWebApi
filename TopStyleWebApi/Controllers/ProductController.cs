using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopStyleWebApi.Data;
using TopStyleWebApi.Models;
using TopStyleWebApi.Services;

namespace TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        
        public ProductController(ApiDbContext context)
        {
            _productService = new ProductService(context);
        }
        
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAll();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_productService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            try
            {
                _productService.Add(value);
                return Ok("Product added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            try
            {
                _productService.Update(id, value);
                return Ok("Product updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.DeleteById(id);
                return Ok("Product deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("search")]
        public IEnumerable<Product> Get(string query)
        {
            return _productService.GetByQuery(query);
        }
    }
}
