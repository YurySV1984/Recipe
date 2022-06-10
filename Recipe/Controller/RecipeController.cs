using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Controller
{
    public class RecipeController
    {
        private RecipeList? Recipes { get; set; }
        public Recipe? CurrentRecipe { get; private set; }
        public bool IsNewRecipe { get; } = false; 

        public RecipeController (string recipeName)
        {
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                throw new ArgumentNullException(nameof(recipeName), "Name must be not null");
            }
            Recipes = GetRecipes();
            CurrentRecipe = Recipes.SingleOrDefault(recipe => recipe.Name == recipeName);

            if (CurrentRecipe == null)
            {
                CurrentRecipe = new Recipe(recipeName);
                Recipes.AddRecipe(CurrentRecipe);
                IsNewRecipe = true;
                Save();
            }
        }

        public void SetRecipe(string recipeDescription, Recipe.Cat recipeCategory, List<Product> recipeProducts)
        {
            if (((int)recipeCategory) >=0 && ((int)recipeCategory) <= 4)
            {
                CurrentRecipe.Category = recipeCategory;
                CurrentRecipe.Description = recipeDescription;
                CurrentRecipe.AddRange(recipeProducts);
                Save();
            }          
        }

        public RecipeController()
        {
            Recipes = GetRecipes();
        }


#pragma warning disable SYSLIB0011

        /// <summary>
        /// Получить сохраненный список рецептов.
        /// </summary>
        /// <returns></returns>
        public RecipeList GetRecipes()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("recipes.dat", FileMode.OpenOrCreate))
            {

                //try
                //{
                    if (fs.Length > 0 && formatter.Deserialize(fs) is RecipeList recipes)
                    {
                        var result = new RecipeList();
                        foreach (var recipe in recipes)
                        {
                            result.AddRecipe(recipe);
                        }
                        return result;
                    }
                    else return new RecipeList();
                //}
                //catch (Exception)
                //{
                //    return new RecipeList();
                //}
                //return new RecipeList();

            }
        }

        public bool DeleteRecipe(string name)
        {

            if (Recipes.DeleteRecipe(name))
            {
                Save();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Сохранить список рецептов.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("recipes.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Recipes);
            }
        }
    }
}
#pragma warning restore SYSLIB0011