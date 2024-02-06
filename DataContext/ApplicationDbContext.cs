using dotnetapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapi.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<EmployeeRequestViewModel> Employees { get; set; }
}