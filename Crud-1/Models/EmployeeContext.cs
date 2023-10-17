using Microsoft.EntityFrameworkCore;
using Crud_1.Models;

namespace Crud_1.Models;
    
public class EmployeeContext : DbContext
{   
    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
   
    public DbSet<Taskes> Tasks { get; set; }
    
}
