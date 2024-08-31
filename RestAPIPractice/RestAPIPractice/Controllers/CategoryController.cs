using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPIPractice.Model;

namespace RestAPIPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private List<Category> categories = new List<Category>()
        {
            new Category() { Id = 0, name = "Appartment", description = "Hola"},
            new Category() { Id = 1, name = "Appartment", description = "Hola"},
        };

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categories;
        }

        [HttpPost]
        public void Post([FromBody]Category category)
        {
            categories.Add(category);
        }

        [HttpPut("id")]
        public void Put(int id, [FromBody] Category category)
        {
            categories[id] = category;
        }
    };
}
