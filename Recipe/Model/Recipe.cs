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
        public int Id { get; set; }
        public virtual ICollection<Product> Products { get => _products; set => _products = (List<Product>)value; }

        public string Name { get; set; }
        public string? Description { get; set; }
        private List<Product> _products = new List<Product>();
        public Cat Category { get; set; }
        
        public enum Cat
        {            
            Салаты = 0,
            Супы = 1,
            Горячее = 2,
            Десерты = 3,
            Напитки = 4
        }

        public Recipe(string name, string description, Cat category)
        {
            Name = name;
            Description = description;
            Category = category;
        }

        public static bool CheckCategory(int inputInt)
        {
            if (inputInt >= 0 && inputInt <= 4)
                return true;
            else return false;
        }

        public Recipe(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("", nameof(name));
            }
            Name = name;
        }
        public Recipe()
        { }
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
