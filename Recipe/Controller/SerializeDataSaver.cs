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
    public class SerializeDataSaver : IDataSaver
    {
        const string filename = "recipes.dat";

        public ObservableCollection<Recipe> Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                if (fs.Length > 0 && formatter.Deserialize(fs) is ObservableCollection<Recipe> recipes)
                {
                    return recipes;
                }
                else return new ObservableCollection<Recipe>();
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }

        public ObservableCollection<Recipe> Load(string name)
        {
            return new ObservableCollection<Recipe>(Load().Where(recipe => recipe.Name == name).ToList());
        }

        public ObservableCollection<Recipe> Load(Recipe.Cat cat)
        {
            return new ObservableCollection<Recipe>(Load().Where(recipe => recipe.Category == cat).ToList());
        }

        public void Add(Recipe recipe)
        {
            var recipes = Load();
            recipes.Add(recipe);
            Save(recipes);
        }


        

        

        public bool DeleteRecipe(string name)
        {
            var result = false;
            var recipes = Load();
            var recipeForDeleting = recipes.SingleOrDefault(recipe => recipe.Name == name);
            if (recipeForDeleting != null)
            {
                recipes.Remove(recipeForDeleting);
                result = true;
                Save(recipes);
            }
            return result;
        }


        public void Save(ObservableCollection<Recipe> recipes)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(fs, recipes);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
}
