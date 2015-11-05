using System;
using AzureAdB2c.Domain.Values;

namespace AzureAdB2c.Domain.Entities
{
    public class Product
    {
        public Guid Id
        { get; set; }

        public string Name
        { get; set; }

        public Money Price
        { get; set; }
    }
}
