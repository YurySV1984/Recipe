using Recipes.Controller;
using Recipes.Model;
using System.Collections.ObjectModel;

bool inputMore = true;
while (inputMore)
{
    Console.WriteLine("-----------------------------------------------------------------------------------------------");
    Console.WriteLine("Input command ( del: delete recipe, add: add new recipe, list: show all the recipes, exit: exit, cat: select category");
    var commandInput = Console.ReadLine();

    switch (commandInput.ToLower())
    {
        case "add":
            Add();
            break;
        case "del":
            Del();
            break;
        case "list":
            ShowList();
            break;
        case "search":
            Search();
            break;
        case "clear":
            Console.Clear();
            break;
        case "cat":
            SearchCat();
            break;
        case "exit":
            inputMore = false;
            break;
        default:
            break;
    }
}



Console.WriteLine("Enter for exit");


void PrintRecipes(ObservableCollection<Recipe> recipes)
{
    foreach (var recipe in recipes)
    {
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine($"Recipe of {recipe?.Name}:");
        Console.WriteLine($"Description: {recipe?.Description}");
        Console.WriteLine($"Category: {recipe?.Category}");
        Console.WriteLine("------Ingridients:------");
        foreach (var product in recipe)
            Console.WriteLine($"{product.Name} - {product.Amount} : {product.Description}");
    }
    Console.WriteLine("-----------------------------------------------------------------------------------------------");
    Console.WriteLine("Recipes found: " + recipes.Count);
}

void Add()
{
    string? name;
    do
    {
        Console.WriteLine("Input recipe name :");
        name = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(name));

    var recipeController = new RecipeController(name);

    if (!recipeController.IsRecipeExists)
    {
        Console.WriteLine("input description (may be empty): ");
        var recipeDescription = Console.ReadLine();
        Console.WriteLine("input category (0 - salads, 1 - soups, 2 - hot, 3 - desert, 4 - drink):");
        Recipe.Cat recipeCategory = new Recipe.Cat();
        var inputIsOk = false;
        do
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result >= 0 && result <= 4)
                {
                    inputIsOk = true;
                    switch (result)
                    {
                        case 0:
                            recipeCategory = Recipe.Cat.Салаты;
                            break;
                        case 1:
                            recipeCategory = Recipe.Cat.Супы;
                            break;
                        case 2:
                            recipeCategory = Recipe.Cat.Горячее;
                            break;
                        case 3:
                            recipeCategory = Recipe.Cat.Десерты;
                            break;
                        case 4:
                            recipeCategory = Recipe.Cat.Напитки;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("input correct category:");
                }
            }
        } while (inputIsOk == false);

        List<Product> products = new List<Product>();
        Console.WriteLine("Now input products");
        var inputMore = true;
        string productName;
        string productDescription;
        string productAmount;
        while (inputMore)
        {
            Console.WriteLine("Input product name:");
            productName = Console.ReadLine();
            Console.WriteLine("Input product descriprion:");
            productDescription = Console.ReadLine();
            Console.WriteLine("Input product amount:");
            productAmount = Console.ReadLine();
            products.Add(new Product(productName, productDescription, productAmount));

            Console.WriteLine("do you want to input more products? (input \"Y\" for input one more product and input \"N\" for end)");
            var input = Console.ReadLine();
            while (true)
            {
                if (input.ToLower() == "y")
                {
                    break;
                }
                if (input.ToLower() == "n")
                {
                    inputMore = false;
                    break;
                }
                Console.WriteLine("input Y or N");
                input = Console.ReadLine();
            }
        }
        recipeController.SetRecipe(name, recipeDescription, recipeCategory, products);
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine($"Recipe {name} added");
    }
}

void Del()
{
    Console.WriteLine("Input recipe name for deleting");
    var recipeNameForDelete = Console.ReadLine();
    var recipeController = new RecipeController(recipeNameForDelete);

    if (recipeController.IsRecipeExists)
    {
        if (recipeController.Delete(recipeNameForDelete))
            Console.WriteLine($"Recipe {recipeNameForDelete} deleted sucessfully");
        else Console.WriteLine($"Can't delete recipe {recipeNameForDelete}");
    }
    else Console.WriteLine($"Can't find recipe {recipeNameForDelete}");
}

void ShowList()
{
    var recipeController = new RecipeController();
    //var recipes = recipeController.GetRecipes();
    PrintRecipes(recipeController.GetRecipes());
}

void Search()
{
    string? name;
    do
    {
        Console.WriteLine("Input recipe name :");
        name = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(name));
    var recipeController = new RecipeController();
    //var recipes = recipeController.SearchRecipe(name);
    //PrintRecipes(recipes);
    PrintRecipes(recipeController.SearchRecipe(name));
}

void SearchCat()
{
    Recipe.Cat recipeCategory;
    while (true)
    {
        Console.WriteLine("Input category you need :");
        if (int.TryParse(Console.ReadLine(), out int cat))
        {
            if (Recipe.CheckCategory(cat))
            {
                recipeCategory = (Recipe.Cat)cat;
                var recipeController = new RecipeController();
                var recipes = recipeController.SearchByCategory(recipeCategory);
                Console.WriteLine("-----------------------------------------------------------------------------------------------");
                Console.WriteLine($"Category: {recipeCategory}");
                PrintRecipes(recipes);
                break;
            }
        }
    }
}