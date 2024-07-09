using FromNumberToText.Domain.Base;

namespace FromNumberToText.Domain.User;

public interface IUserRepository : IRepositoryBase<UserEntity>, IDisposable
{
}