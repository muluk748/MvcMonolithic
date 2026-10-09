using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.DomainModels.ProductAggregates;

namespace MvcMonolithic.Models
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext>options)
            :base(options) 
        {
        }
        public DbSet<Person> Person {  get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
