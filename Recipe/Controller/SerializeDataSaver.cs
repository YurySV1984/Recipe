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
                if (fs.Length > 0 && formatter.Deserialize(fs) is ObservableCollection<Recipe> items)
                {
                    return items;
                }
                else return default(ObservableCollection<Recipe>);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }

        public void Add(Recipe recipe)
        {
            throw new NotImplementedException();
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

        public ObservableCollection<Recipe> Load(string name)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Recipe> Load(Recipe.Cat cat)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRecipe(string name)
        {
            throw new NotImplementedException();
        }
    }
}
