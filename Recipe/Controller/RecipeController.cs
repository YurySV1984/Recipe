﻿using Recipes.Model;
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
        public RecipeList? Recipes { get; set; }
        public Recipe? CurrentRecipe { get; private set; }
        public bool IsNewRecipe { get; } = false; 

        public RecipeController (string recipeName)
        {
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                throw new ArgumentNullException("Name must be not null", nameof(recipeName));
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
            else
            {

            }
            
        }




        /// <summary>
        /// Получить сохраненный список рецептов.
        /// </summary>
        /// <returns></returns>
        public RecipeList GetRecipes()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("recipes.dat", FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011
                try
                {
                    if (formatter.Deserialize(fs) is RecipeList recipes)
                    {
                        var result = new RecipeList();
                        foreach (var recipe in recipes)
                        {
                            result.AddRecipe(recipe);
                        }
                        return result;
                    }
                }
                catch (Exception)
                {
                    return new RecipeList();
                }
#pragma warning restore SYSLIB0011
                return new RecipeList();

            }
        }

        /// <summary>
        /// Сохранить список рецептов.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("recipes.dat", FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011
                formatter.Serialize(fs, Recipes);
#pragma warning restore SYSLIB0011
            }
        }
    }
}
