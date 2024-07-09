using FromNumberToText.Domain.FromNumberToText;
using FromNumberToText.Domain.User;
using FromNumberToText.Persistence.Base.Context;
using Microsoft.EntityFrameworkCore;

namespace FromNumberToText.Persistence.Context;

public interface IPersistenceDbContext : IDbContextBase
{
    DbSet<FromNumberToTextEntity> Number { get; }
    DbSet<UserEntity> User { get; }
}