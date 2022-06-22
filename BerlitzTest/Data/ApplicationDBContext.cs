using BerlitzTest.Models;
using Microsoft.EntityFrameworkCore;

namespace BerlitzTest.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        
        public DbSet<Product> Products  { get; set; }
    }
}
