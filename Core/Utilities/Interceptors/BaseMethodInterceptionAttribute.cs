using Castle.Core.Interceptor;

namespace Core.Utilities.Interceptors;

[AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
public abstract class BaseMethodInterceptionAttribute:Attribute,IInterceptor
{
    public int Priority { get; set; }

    public virtual void Intercept(IInvocation invocation)
    {

    }
}