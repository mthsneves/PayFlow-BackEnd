using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities;

namespace PayFlow.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
    public DbSet<Transaction> Transactions { get; set; }
}
