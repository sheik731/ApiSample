using Microsoft.EntityFrameworkCore;
using sample.Model;

namespace sample.Data{
public class Datacontext : DbContext
{
    public DbSet<AvailableResponse> AvailableResponse {get; set;} 
    public DbSet<CancellationReason> CancellationReason {get; set;}
    public DbSet<Dept> Dept {get; set;} 
    public DbSet<Drive> Drive {get; set;} 
    public DbSet<EmployeeDriveResponse> EmployeeDriveResponse {get; set;} 
    public DbSet<Employee> Employee {get; set;} 
    public DbSet<Location> Location {get; set;}
    public DbSet<Pool> Pool {get; set;}
    public DbSet<PoolMembers> PoolMembers {get; set;}
    public DbSet<Project> Project {get; set;}
    public DbSet<Role> Role {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=Department;Trusted_Connection=True;");
    }
}
}