using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly IProductDBContext _dbcontext;

        public productsController(IProductDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _dbcontext.Products.ToListAsync();
        }

        [HttpGet("colour")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByColour(string colour)
        {
            var products = await _dbcontext.Products.Where(p => p.Colour == colour).ToListAsync();
            return products == null ? NotFound(): Ok(products);           
        }
    }
}