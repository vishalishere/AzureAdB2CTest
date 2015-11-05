using System;
namespace AzureAdB2c.Domain.Contracts.Handlers
{
    public interface IExceptionHandler
    {
        T FromUnsafeFunction<T>(Func<T> unsafeFunction);
    }
}
