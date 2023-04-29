using Castle.Core.Interceptor;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.Logging;

namespace Core.Aspects
{
    public class LogAspect : MethodInterception
    {
        private ILogger _logger;

        public LogAspect(ILogger loggerService)
        {


            _logger = loggerService;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _logger.Log(LogLevel.Information, "Called On Before", invocation.Method.Name);
        }

        protected override void OnAfter(IInvocation invocation)
        {
            _logger.Log(LogLevel.Information, "Called On After", invocation.Method.Name);
        }
    }
}