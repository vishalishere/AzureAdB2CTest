using AzureAdB2c.Domain.Contracts.Handlers;
using AzureAdB2c.Domain.Contracts.Repositories;
using System;

namespace AzureAdB2c.Business.Core.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        public T FromUnsafeFunction<T>(Func<T> unsafeFunction)
        {
            try
            {
                return unsafeFunction.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            return default(T);
        }
    }
}
