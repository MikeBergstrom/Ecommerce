using Microsoft.EntityFrameworkCore;
using System.Linq;
 
namespace ecommerce.Models
{
    public class UserContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
	public DbSet<User> User { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<Product> Product { get; set; }
    }
}