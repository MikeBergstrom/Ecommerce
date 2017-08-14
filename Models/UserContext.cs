using Microsoft.EntityFrameworkCore;
using System.Linq;
 
namespace ecommerce.Models
{
    public class UserContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
	public DbSet<User> user { get; set; }
	public DbSet<Order> orders { get; set; }
	public DbSet<Product> product { get; set; }
    }
}