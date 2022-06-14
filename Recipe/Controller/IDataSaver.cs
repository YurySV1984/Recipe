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
        void Save(ObservableCollection<Recipe> recipes);
        public void Add(Recipe recipe);
        ObservableCollection<Recipe> Load();
        ObservableCollection<Recipe> Load(string name);
        ObservableCollection<Recipe> Load(Recipe.Cat cat);
        bool DeleteRecipe(string name);

    }
}
