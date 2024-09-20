using Microsoft.EntityFrameworkCore;
using Product.API.Models;

namespace Product.API.Data.DbContexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }
    }
}
