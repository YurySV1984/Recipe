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
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Amount { get; private set; }
        #endregion
        public Product(string name, string description, string amount)
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
            //Id = id;
            Name = name;
            Amount = amount;
        }
        public Product() { }
        //public override string ToString() => Name + " " + Amount;
    }
}
