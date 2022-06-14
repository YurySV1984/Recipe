﻿using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Controller
{
    public abstract class ControllerBase
    {
        private static readonly string dataSaver = ConfigurationManager.ConnectionStrings["DataSource"].ConnectionString;
        
        
        
        
        
        //protected IDataSaver saver = new DatabaseDataSaver();
        protected IDataSaver saver = dataSaver == "DB"? new DatabaseDataSaver(): new SerializeDataSaver();


        protected void Save(ObservableCollection<Recipe> recipes)
        {
            saver.Save(recipes);
        }

        protected void Add(Recipe recipe)
        {
            saver.Add(recipe);
        }
        /// <summary>
        /// Возвращает всю коллекцию рецептов
        /// </summary>
        /// <returns></returns>
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
