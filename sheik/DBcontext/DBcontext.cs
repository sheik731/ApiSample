using Microsoft.EntityFrameworkCore;
using sample.Model;

namespace sample.Data{
public class Datacontext : DbContext
{
    public DbSet<Dept> Dept {get; set;} 
    public DbSet<Project> Project {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=Department;Trusted_Connection=True;");
    }
}
}