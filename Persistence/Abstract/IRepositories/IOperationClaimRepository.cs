using Domain.Entities;

namespace Persistence.Abstract.IRepositories;

public interface IOperationClaimRepository : IRepository<OperationClaim>, IAsyncRepository<OperationClaim>
{
    
}