using Microsoft.EntityFrameworkCore;
namespace Products_Categories.Models
{ 
    // the MyContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        // the "User" table name will come from the DbSet variable name
        public DbSet<Association> Association { get; set; }
        public DbSet<Product> Product {get; set;}
        public DbSet<Category> Category {get; set;}
    }
}
