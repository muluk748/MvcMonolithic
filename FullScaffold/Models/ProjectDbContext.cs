using Microsoft.EntityFrameworkCore;
using FullScaffold.Models.DomainModels.ProductsAggregates;

namespace FullScaffold.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            :base (options)
            {
            }
        public DbSet<Product> Products { get; set; }
    }
}
