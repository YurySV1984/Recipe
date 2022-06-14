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
    public class RecipeController : ControllerBase
    {
        //private RecipeList? Recipes { get; set; }
        //public Recipe? CurrentRecipe { get; private set; }
        public bool IsRecipeExists { get; } = true;

        private ObservableCollection<Recipe> _recipes;


        public RecipeController(string recipeName)
        {
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                throw new ArgumentNullException(nameof(recipeName), "Name must be not null");
            }
            _recipes = GetRecipes(recipeName);
            //CurrentRecipe = _recipes.SingleOrDefault(recipe => recipe.Name == recipeName);

            //if (CurrentRecipe == null)

            if (_recipes.Count == 0)
            {
                //CurrentRecipe = new Recipe(recipeName);

                //_recipes.Add(CurrentRecipe);
                IsRecipeExists = false;
                //Save("recipes.dat", Recipes._recipes);
            }
        }

        public void SetRecipe(string recipeName, string recipeDescription, Recipe.Cat recipeCategory, List<Product> recipeProducts)
        {
            if (((int)recipeCategory) >= 0 && ((int)recipeCategory) <= 4)
            {
                var newRecipe = new Recipe
                {
                    Name = recipeName,
                    Category = recipeCategory,
                    Description = recipeDescription
                };
                newRecipe.AddRange(recipeProducts);
                Add(newRecipe);
            }
        }

        public RecipeController()
        {
        }

        public ObservableCollection<Recipe> SearchRecipe(string name)
        {
            //Recipes._recipes = GetRecipes(name);
            //return Recipes.SearchRecipe(name);
            return GetRecipes(name);
        }

        public ObservableCollection<Recipe> SearchByCategory(Recipe.Cat recipeCategory)
        {
            //return Recipes.SearchByCategory(recipeCategory);
            return GetRecipes(recipeCategory);
        }

#pragma warning disable SYSLIB0011

        /// <summary>
        /// Получить сохраненный список рецептов.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Recipe> GetRecipes()
        {
            return Load();
        }
        public ObservableCollection<Recipe> GetRecipes(string name)
        {
            return Load(name);
        }
        public ObservableCollection<Recipe> GetRecipes(Recipe.Cat recipeCategory)
        {
            return Load(recipeCategory);
        }

        public bool Delete(string name)
        {
            return DeleteRecipe(name);
        }
    }
}
#pragma warning restore SYSLIB0011