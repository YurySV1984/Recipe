using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public ObservableCollection<Recipe> Load()
        {
            using (var db = new RecipeContext())
            {
                var recipes = new ObservableCollection<Recipe> (db.Set<Recipe>().ToList());
                foreach (var recipe in recipes)
                {
                    recipe.Products = db.Set<Product>().Where(product => product.RecipeId == recipe.Id).ToList();
                }
                return recipes;
            }
        }

        public ObservableCollection<Recipe> Load(string name)
        {
            using (var db = new RecipeContext())
            {
                var recipes = new ObservableCollection<Recipe>(db.Set<Recipe>().Where(recipe => recipe.Name.Contains(name)).ToList());
                foreach (var recipe in recipes)
                {
                    recipe.Products = db.Set<Product>().Where(product => product.RecipeId == recipe.Id).ToList();
                }
                return recipes;
            }
        }

        public ObservableCollection<Recipe> Load(Recipe.Cat cat)
        {
            using (var db = new RecipeContext())
            {
                var recipes = new ObservableCollection<Recipe>(db.Set<Recipe>().Where(recipe => recipe.Category == cat).ToList());
                foreach (var recipe in recipes)
                {
                    recipe.Products = db.Set<Product>().Where(product => product.RecipeId == recipe.Id).ToList();
                }
                return recipes;
            }
        }

        public void Add(Recipe recipe)
        {
            using (var db = new RecipeContext())
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
            }
        }

        public bool DeleteRecipe(string name)
        {
            var result = false;
            using (var db = new RecipeContext())
            {
                var recipe = db.Set<Recipe>().SingleOrDefault(recipe => recipe.Name == name);
                if (recipe != null)
                {
                    var products = db.Set<Product>().Where(product => product.RecipeId == recipe.Id);
                    foreach (var product in products)
                    {
                        db.Products.Remove(product);
                    }
                    db.Recipes.Remove(recipe);
                    db.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public void Save(ObservableCollection<Recipe> recipes)
        {
            using(var db = new RecipeContext())
            {
                db.Recipes.AddRange(recipes);
                db.SaveChanges();
            }
        }
    }
}
