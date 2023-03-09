using Microsoft.EntityFrameworkCore;
using PropertyRental.Models;

namespace PropertyRental.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Added DBSet for Categories Table
        public DbSet<Category> Categories { get; set; }
    }
}
