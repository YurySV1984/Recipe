using Recipes.Controller;
using Recipes.Model;

//Console.WriteLine("Recipe book :)");
//Console.WriteLine("Input recipe name :");
//var name = Console.ReadLine();

//var recipeController = new RecipeController(name);
//if (recipeController.IsNewRecipe)
//{
//    Console.WriteLine("There is no recipe in the list. Do you want to add it? (y/n)");

//    var input = Console.ReadLine();
//    while (true)
//    {
//        if (input.ToLower() == "y")
//        {
//            break;
//        }
//        if (input.ToLower() == "n")
//        {
//            break;
//        }
//        Console.WriteLine("input Y or N");
//        input = Console.ReadLine();
//    }
//    if (input == "y")
//    {
//        Console.WriteLine("input description (may be empty): ");
//        var recipeDescription = Console.ReadLine();
//        Console.WriteLine("input category (0 - salads, 1 - soups, 2 - hot, 3 - desert, 4 - drink):");

//        Recipe.Cat recipeCategory = new Recipe.Cat();
//        var inputIsOk = false;
//        do
//        {
//            if (int.TryParse(Console.ReadLine(), out int result))
//            {
//                if (result >= 0 && result <= 4)
//                {
//                    inputIsOk = true;
//                    switch (result)
//                    {
//                        case 0:
//                            recipeCategory = Recipe.Cat.Salads;
//                            break;
//                        case 1:
//                            recipeCategory = Recipe.Cat.Soups;
//                            break;
//                        case 2:
//                            recipeCategory = Recipe.Cat.Hot;
//                            break;
//                        case 3:
//                            recipeCategory = Recipe.Cat.Desert;
//                            break;
//                        case 4:
//                            recipeCategory = Recipe.Cat.Drink;
//                            break;
//                        default:
//                            break;
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("input category:");
//                }
//            }
//        } while (inputIsOk == false);

//        List<Product> products = new List<Product>();
//        Console.WriteLine("Now input products");
//        var inputMore = true;
//        var id = 0;
//        string productName;
//        string productDescription;
//        string productAmount;
//        while (inputMore)
//        {
//            Console.WriteLine("Input product name:");
//            productName = Console.ReadLine();
//            Console.WriteLine("Input product descriprion:");
//            productDescription = Console.ReadLine();
//            Console.WriteLine("Input product amount:");
//            productAmount = Console.ReadLine();
//            products.Add(new Product(id, productName, productDescription, productAmount));

//            Console.WriteLine("do you want to input more products? (input \"Y\" for input one more product and input \"N\" for end)");
//            input = Console.ReadLine();
//            while (true)
//            {
//                if (input.ToLower() == "y")
//                {
//                    break;
//                }
//                if (input.ToLower() == "n")
//                {
//                    inputMore = false;
//                    break;
//                }
//                Console.WriteLine("input Y or N");
//                input = Console.ReadLine();
//            }

//            id++;
//        }

//        recipeController.SetRecipe(recipeDescription, recipeCategory, products);
//    }
//}
//else
//{
//    var recipes = recipeController.GetRecipes();
//    var recipe = recipes.SingleOrDefault(recipe => recipe.Name == name);
//    //foreach (var recipe in recipes)
//    //{
//        Console.WriteLine("-----------------------------------------------------------------------------");
//        Console.WriteLine($"Recipe of {recipe.Name}:");
//        Console.WriteLine($"Description: { recipe.Description}");
//        Console.WriteLine($"Category: {recipe.Category}");
//        Console.WriteLine("--Ingridients:--");
//        foreach (var product in recipe)
//        {
//            Console.WriteLine($"{product.Name} - {product.Amount} : {product.Description}");
//        }
//    //}
//}

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
var recipe = new Recipe(recipeName, recipeDescription, recipeCategory);
recipe.Add(new Product(0, "prodName1", "proddescr1", "prodamount1"));
recipe.Add(new Product(1, "prodName2", "proddescr2", "prodamount2"));
recipe.Add(new Product(2, "prodName3", "proddescr3", "prodamount3"));
recipeList.Add(recipe);
var s = recipeController.GetRecipes();
Console.WriteLine(recipeList[0].Name);
var cnt = s.Counter;
Console.WriteLine(s.Last().Name);




Console.ReadLine();



