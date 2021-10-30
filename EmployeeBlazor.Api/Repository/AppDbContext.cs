using EmployeeBlazor.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBlazor.Api2.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Bethany",
                LastName = "Smith",
                JobName = "High"
            });
        }
    }
}
