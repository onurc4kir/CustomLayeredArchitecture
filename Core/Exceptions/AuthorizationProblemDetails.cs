namespace Core.Exceptions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

public class AuthorizationProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}