using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public interface IProductDBContext : IDisposable
    {
        DbSet<Product> Products { get; set; }
    }
}
