using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Controller
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(): base("name=DbConnectionString") { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
