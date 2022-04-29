using Microsoft.EntityFrameworkCore;
using Iswarya.Models;

namespace Iswarya.Data{
public class Datacontext : DbContext
{
    public DbSet<User> users {get; set;} 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=.;Database=InterviewManagementSystem;Trusted_Connection=True;");
    }
}
}