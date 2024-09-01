using Microsoft.EntityFrameworkCore;
using RestAPIPractice.Model;

namespace RestAPIPractice.Data
{
    public class APIDbContext:  DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=RealEstateDb;");
        }
    }
}
