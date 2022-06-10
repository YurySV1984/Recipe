using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Controller;
using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Controller.Tests
{
    [TestClass()]
    public class RecipeControllerTests
    {
        

        [TestMethod()]
        public void GetRecipesTest()
        {
            //Arrange
            var recipeName = Guid.NewGuid().ToString();
            var recipeDescription = "descr of " + recipeName;
            var recipeCategory = Recipe.Cat.Drink;
            List<Product> products = new List<Product>();
            products.Add(new Product(0, "prodName1", "proddescr1", "prodamount1"));
            products.Add(new Product(1, "prodName2", "proddescr2", "prodamount2"));
            products.Add(new Product(2, "prodName3", "proddescr3", "prodamount3"));
            //Act
            var recipeController = new RecipeController(recipeName);
            recipeController.SetRecipe(recipeDescription, recipeCategory, products);

            var recipeList = new List<Recipe>();
            var recipe = new Recipe(recipeName,recipeDescription,recipeCategory);
            recipe.Add(new Product(0, "prodName1", "proddescr1", "prodamount1"));
            recipe.Add(new Product(1, "prodName2", "proddescr2", "prodamount2"));
            recipe.Add(new Product(2, "prodName3", "proddescr3", "prodamount3"));
            recipeList.Add(recipe);
            var s = recipeController.GetRecipes();
            //Assert
            Assert.AreEqual(recipeList[0].Name, s.Last().Name);
            Assert.AreEqual(recipeList[0].Description, s.Last().Description);
            Assert.AreEqual(recipeList[0].Category, s.Last().Category);

        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var recipeName = Guid.NewGuid().ToString();
            var recipeDescription = "descr of " + recipeName;
            var recipeCategory = Recipe.Cat.Drink;
            List<Product> products = new List<Product>();
            products.Add(new Product(0, "prodName1", "proddescr1", "prodamount1"));
            products.Add(new Product(1, "prodName2", "proddescr2", "prodamount2"));
            products.Add(new Product(2, "prodName3", "proddescr3", "prodamount3"));

            //Act
            var recipeController = new RecipeController(recipeName);
            recipeController.SetRecipe(recipeDescription,recipeCategory,products);
            

            //Assert
            Assert.AreEqual(recipeName, recipeController.CurrentRecipe.Name);
            Assert.AreEqual(recipeDescription, recipeController.CurrentRecipe.Description);
            Assert.AreEqual(recipeCategory, recipeController.CurrentRecipe.Category);            
            Assert.AreEqual(products.Count, recipeController.CurrentRecipe.GetProducts().Count);
            Assert.AreEqual(products.First(), recipeController.CurrentRecipe.GetProducts().First());
            Assert.AreEqual(products[0], recipeController.CurrentRecipe.GetProducts()[0]);
            Assert.AreEqual(products[1], recipeController.CurrentRecipe.GetProducts()[1]);
            Assert.AreEqual(products[2], recipeController.CurrentRecipe.GetProducts()[2]);
        }
    }
}