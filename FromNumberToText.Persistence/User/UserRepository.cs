using FromNumberToText.Domain.User;
using FromNumberToText.Persistence.Base;
using FromNumberToText.Persistence.Context;

namespace FromNumberToText.Persistence.FromNumberToText;

public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
{
    public UserRepository(IPersistenceDbContext userContext) : base(userContext)
    {
    }
}
