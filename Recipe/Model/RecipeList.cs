using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Model
{
    [Serializable]
    public class RecipeList : IEnumerable<Recipe>
    {
        private ObservableCollection<Recipe> _recipes;
        
        /// <summary>
        /// Индексатор.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Recipe this[int index]
        {
            get => _recipes[index];
            set => _recipes[index] = value;
        }

        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        public RecipeList()
        {
            _recipes = new ObservableCollection<Recipe>();
        }

        /// <summary>
        /// Сортировка по имени рецепта.
        /// </summary>
        public void Sort()
        {
            _recipes = new ObservableCollection<Recipe>(_recipes.OrderBy(recipe => recipe.Name).ToList());
        }

        /// <summary>
        /// Получить список рецептов.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Recipe> GetRecipesList()
        {
            return _recipes;
        }
        

        public IEnumerator<Recipe> GetEnumerator()
        {
            return ((IEnumerable<Recipe>)_recipes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_recipes).GetEnumerator();
        }

    }
}
