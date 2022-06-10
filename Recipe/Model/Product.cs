using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Model
{
    [Serializable]
    public class Product
    {

        #region Свойства
        public int Id { get; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Amount { get; private set; }
        #endregion

        //public Dictionary<string, string> Unit { get; private set; }
        public Product(int id, string name, string description, string amount)
        {
            #region check
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
            #endregion
            Id = id;
            Name = name;
            Amount = amount;
        }
        public override string ToString() => Name + " " + Amount;
    }
}
