using BerlitzTest.Models;
using Microsoft.EntityFrameworkCore;

namespace BerlitzTest.Data
{
    public class ApplicationDBContextInMemory : DbContext
    {
        public ApplicationDBContextInMemory(DbContextOptions<ApplicationDBContextInMemory> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
