using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace GraphqlProject.Helpers
{
    public class GraphqlDbContext:DbContext
    {
        public GraphqlDbContext(DbContextOptions options) : base(options)
        { }
         public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
