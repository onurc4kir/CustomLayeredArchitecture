namespace Persistence.Abstract;

public interface IQuery<T>
{
    IQueryable<T> Query();
}