using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Model
{
    public class Recipe
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        private List<Product>  products = new List<Product>();
        public string? Category { get; private set; }

    }
}
