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
        public bool IsRecipeExists { get; private set; } = true;
        private ObservableCollection<Recipe> _recipes = new ObservableCollection<Recipe>();

        public RecipeController() { }
        public RecipeController(string recipeName)
        {
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                throw new ArgumentNullException(nameof(recipeName), "Name must be not null");
            }
            _recipes = GetRecipes(recipeName);

            if (_recipes.Count == 0)
            {
                IsRecipeExists = false;
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

        

        public ObservableCollection<Recipe> SearchRecipe(string name)
        {
            return GetRecipes(name);
        }

        public ObservableCollection<Recipe> SearchByCategory(Recipe.Cat recipeCategory)
        {
            //return Recipes.SearchByCategory(recipeCategory);
            return GetRecipes(recipeCategory);
        }

#pragma warning disable SYSLIB0011

        /// <summary>
        /// Получить из БД весь список рецептов.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Recipe> GetRecipes()
        {
            return Load();
        }
        /// <summary>
        /// Возвращает из БД коллекцию рецептов по имени name
        /// </summary>
        /// <param name="name">Имя рецепта</param>
        /// <returns></returns>
        public ObservableCollection<Recipe> GetRecipes(string name)
        {
            return Load(name);
        }
        /// <summary>
        /// Возвращает из БД коллекцию рецептов по категории recipeCategory
        /// </summary>
        /// <param name="recipeCategory">Категория рецепта</param>
        /// <returns></returns>
        public ObservableCollection<Recipe> GetRecipes(Recipe.Cat recipeCategory)
        {
            return Load(recipeCategory);
        }
        /// <summary>
        /// Возвращает результат удаления из БД рецепта и именем name
        /// </summary>
        /// <param name="name">Имя рецепта для удаления</param>
        /// <returns></returns>
        public bool Delete(string name)
        {
            return DeleteRecipe(name);
        }
    }
}
#pragma warning restore SYSLIB0011