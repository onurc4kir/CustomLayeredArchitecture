using Persistence.Abstract;

namespace Domain.Entities;

public class OperationClaim : EntityBase
{
    public string Name { get; set; }
    
    public OperationClaim()
    {
    }
    
    
}