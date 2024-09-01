using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using RestAPIPractice.Data;
using RestAPIPractice.Model;

namespace RestAPIPractice.Controllers
{
    // GET: api/<CategoryController>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        APIDbContext _dbContext = new APIDbContext();

        // GET: CategoryController/5
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Categories);
        }

        // GET: CategoryController/Details/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x=> x.Id== id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // api 
        [HttpGet("[action]")]
        public IActionResult GetSortCategories()
        {
            return Ok(_dbContext.Categories.OrderByDescending(x => x.name));
        }


        // GET: CategoryController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        //Put CategoryController/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category categoryObj) 
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound("No record found" + id);
            }
            else
            {
                category.name = categoryObj.name;
                category.description = categoryObj.description;
                _dbContext.SaveChanges();
                return Ok("Record updated successfully");
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound("No record found" + id);
            }
            else
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                return Ok("Record deleted");
            }
        }
    }
}
