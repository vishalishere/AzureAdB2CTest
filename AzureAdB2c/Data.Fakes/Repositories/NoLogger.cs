using System;
using AzureAdB2c.Domain.Contracts.Repositories;
#if DEBUG
using System.Diagnostics;
#endif

namespace Data.Fakes.Repositories
{
    public class NoLogger : ILogger
    {
        public void LogException(Exception ex)
        {
#if DEBUG
            Debug.WriteLine(ex.Message);
#endif
        }

    }
}
