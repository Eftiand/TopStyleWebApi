using Microsoft.AspNetCore.Mvc;
using TopStyleWebApi.Data;
using TopStyleWebApi.Models;
using TopStyleWebApi.Services;

namespace TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        
        public CategoryController(ApiDbContext context)
        {
            _categoryService = new CategoryService(context);
        }
        
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{id:int}", Name = "GetCategory")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_categoryService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Category
        [HttpPost]
        public ActionResult<Category> Post([FromBody] Category category)
        {
            _categoryService.Add(category);
            return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category value)
        {
            try
            {
                _categoryService.Update(id, value);
                return Ok("Category updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteById(id);
                return Ok("Category deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
