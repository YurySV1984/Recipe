using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Controller
{
    public class RecipeController
    {
        public Recipe? Recipe { get; set; }
        public RecipeController (string recipeName,string recipeDescription, string recipeCategory)
        {
            if (string.IsNullOrWhiteSpace(recipeName) || string.IsNullOrWhiteSpace(recipeCategory))
            {
                throw new ArgumentNullException("is null");
            }
            Recipe = new Recipe(recipeName, recipeDescription, recipeCategory);
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product is null");
            }
            Recipe.Add(product);
        }
        /// <summary>
        /// Сохранить рецепт
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("recipe.dat", FileMode.OpenOrCreate))
            {
                #pragma warning disable SYSLIB0011
                formatter.Serialize(fs, Recipe);
                #pragma warning restore SYSLIB0011
            }
        }
        /// <summary>
        /// Загрузить рецепт.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>
        public RecipeController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("recipe.dat", FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011
                if (formatter.Deserialize(fs) is Recipe recipe)
                {
                    Recipe = recipe;
                }
#pragma warning restore SYSLIB0011
                else
                {
                    Recipe = null;
                }
            }

            
        }
    }
}
