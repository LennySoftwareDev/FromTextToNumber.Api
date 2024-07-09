using FromNumberToText.Domain.FromNumberToText;
using FromNumberToText.Domain.User;
using FromNumberToText.Persistence.Base.Context;
using Microsoft.EntityFrameworkCore;

namespace FromNumberToText.Persistence.Context;

public class PersistenceDbContext : DbContextBase, IPersistenceDbContext
{
    public PersistenceDbContext(DbContextOptions<PersistenceDbContext> options) : base(options)
    {
    }

    public virtual DbSet<FromNumberToTextEntity> Number { get; set; }
    public virtual DbSet<UserEntity> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>().HasData(

            new UserEntity
            {
                UserId = 1,
                UserName = "admin",
                Password = "12345"
            });
    }
}
