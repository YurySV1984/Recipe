using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Controller
{
    public interface IDataSaver
    {
        /// <summary>
        /// Добавляет и сохраняет в БД коллекцию рецептов
        /// </summary>
        /// <param name="recipes"></param>
        void Save(ObservableCollection<Recipe> recipes);
        /// <summary>
        /// Добавляет рецепт к БД
        /// </summary>
        /// <param name="recipe"></param>
        public void Add(Recipe recipe);
        /// <summary>
        /// Возвращает из БД всю коллекцию рецептов
        /// </summary>
        /// <returns></returns>
        ObservableCollection<Recipe> Load();
        /// <summary>
        /// Возвращает коллекцию рецептов по имени из БД
        /// </summary>
        /// <param name="name">Имя рецепта</param>
        /// <returns></returns>
        ObservableCollection<Recipe> Load(string name);
        /// <summary>
        /// Возвращает коллекцию рецептов по категории из БД
        /// </summary>
        /// <param name="cat">Категория рецепта</param>
        /// <returns></returns>
        ObservableCollection<Recipe> Load(Recipe.Cat cat);
        /// <summary>
        /// Возвращает результат удаления рецепта с именем name из БД
        /// </summary>
        /// <param name="name">Имя рецепта</param>
        /// <returns></returns>
        bool DeleteRecipe(string name);

    }
}
