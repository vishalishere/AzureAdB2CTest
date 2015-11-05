using System;

namespace AzureAdB2c.Domain.Contracts.Repositories
{
    public interface ILogger
    {
        void LogException(Exception ex);
    }
}
