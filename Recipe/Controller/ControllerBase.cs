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
    public abstract class ControllerBase
    {
        protected IDataSaver saver = new DatabaseDataSaver();
        
        
        protected void Save(ObservableCollection<Recipe> recipes)
        {
            saver.Save(recipes);
        }

        protected void Add(Recipe recipe)
        {
            saver.Add(recipe);
        }

        protected ObservableCollection<Recipe> Load()
        {
            return saver.Load();
        }
        protected ObservableCollection<Recipe> Load(string name)
        {
            return saver.Load(name);
        }
        protected ObservableCollection<Recipe> Load(Recipe.Cat cat)
        {
            return saver.Load(cat);
        }
        protected bool DeleteRecipe(string name)
        {
            return saver.DeleteRecipe(name);
        }
    }
}
