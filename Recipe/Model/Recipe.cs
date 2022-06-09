using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Model
{
    [Serializable]
    public class Recipe
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        private List<Product> _products = new List<Product>();
        public string? Category { get; set; }

        public Recipe(string name, string description, string category)
        {
            Name = name;
            Description = description;
            Category = category;
        }
        public Recipe()
        { }
        public Product this[int index]
        {
            get => _products[index];
            set => _products[index] = value;
        }
        public int Count { get => _products.Count; }

        public void Add(Product product)
        {
            _products.Add(product);
        }
    }
}
