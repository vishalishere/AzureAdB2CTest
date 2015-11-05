using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAdB2c.Domain.Contracts.Validators
{
    public interface IValidator<T>
    {
        bool IsValid(T entity);
    }
}
