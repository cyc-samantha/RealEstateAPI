using Microsoft.AspNetCore.Mvc;
using RestAPIPractice.Data;
using RestAPIPractice.Model;

namespace RestAPIPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        APIDbContext _dbContext = new APIDbContext();

        // GET: CategoryController
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _dbContext.Categories;
        }

        // GET: CategoryController/Details/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x=> x.Id== id);
            return category;
        }

        // GET: CategoryController/Create
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }
    }
}
