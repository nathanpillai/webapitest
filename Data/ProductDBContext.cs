using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class ProductDBContext : DbContext, IProductDBContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            :base(options)
            { }
        public DbSet<Product> Products { get; set;}
    }
}
