using Microsoft.EntityFrameworkCore;
namespace Wedding_Planner.Models
{ 
    // the MyContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }
        // the "User" table name will come from the DbSet variable name
        public DbSet<User> User {get; set;}
        public DbSet<Wedding> Wedding {get; set;}
        public DbSet<Association> Association {get; set;}
    }
}
