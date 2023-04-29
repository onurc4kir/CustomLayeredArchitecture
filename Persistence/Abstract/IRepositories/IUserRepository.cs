using Domain.Entities;

namespace Persistence.Abstract.IRepositories;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
    
}