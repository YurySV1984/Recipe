using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Model
{
    [Serializable]
    public class Recipe : IEnumerable<Product>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        private List<Product> _products = new List<Product>();
        public Cat Category { get; set; }

        public enum Cat
        {            
            Salads = 0,
            Soups = 1,
            Hot = 2,
            Desert = 3,
            Drink = 4
        }

        public Recipe(string name, string description, Cat category)
        {
            Name = name;
            Description = description;
            Category = category;
        }
        public Recipe(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("", nameof(name));
            }
            Name = name;
        }
        public List<Product> GetProducts()
        {
            return _products;
        }


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
        public void AddRange(List<Product> products)
        {
            _products.AddRange(products);
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return ((IEnumerable<Product>)_products).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_products).GetEnumerator();
        }
    }
}
