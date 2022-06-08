using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Model
{
    public class Product
    {
        
        
        public int Id { get; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Unit { get; private set; }
        public int? Amount { get; private set; }
        public Product(int id, string? name, string? description, string? unit, int? amount)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name must be not empty", nameof(name));
            }
            if (string.IsNullOrEmpty(description))
            {
                Description = string.Empty;
            }
            else
            {
                Description = description;
            }
            if (string.IsNullOrEmpty(unit))
            {
                throw new ArgumentNullException("unut must be not empty",nameof(unit));
            }
            if (amount < 0)
            {
                throw new ArgumentException("amount must be more than 0", nameof(amount));
            }
            Id = id;
            Name = name;
            Unit = unit;
            Amount = amount;
        }
    }
}
