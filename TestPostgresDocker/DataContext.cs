using Microsoft.EntityFrameworkCore;

namespace TestPostgresDocker;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Person> Person { get; set; }
}
