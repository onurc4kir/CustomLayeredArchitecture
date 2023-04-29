using Core.Utilities.Results;
using Persistence.Abstract.DynamicQuery;

namespace Application.Services.IServices;

public interface ICrudService<T>
{
    Task<IDataResult<T> >GetByIdAsync(Guid itemId);
    Task<IResult> AddAsync(T item);
    Task<IResult> DeleteAsync(T item);
    Task<IResult> UpdateAsync(T item);
    Task<IDataResult<List<T>>> GetListByDynamicQueryAsync(DynamicQuery dynamicQuery, int page = 0, int pageSize = 10);

    
}