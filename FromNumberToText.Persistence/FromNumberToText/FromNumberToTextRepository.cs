using FromNumberToText.Domain.FromNumberToText;
using FromNumberToText.Persistence.Base;
using FromNumberToText.Persistence.Context;

namespace FromNumberToText.Persistence.FromNumberToText;

public class FromNumberToTextRepository : RepositoryBase<FromNumberToTextEntity>, IFromNumberToTextRepository
{
    public FromNumberToTextRepository(IPersistenceDbContext FromNumberToTextDbContext) : base(FromNumberToTextDbContext)
    {
    }
}
