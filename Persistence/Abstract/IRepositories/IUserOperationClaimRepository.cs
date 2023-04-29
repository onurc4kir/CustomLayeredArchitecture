using Domain.Entities;

namespace Persistence.Abstract.IRepositories;

public interface IUserOperationClaimRepository : IRepository<UserOperationClaim>, IAsyncRepository<UserOperationClaim>
{
    
}