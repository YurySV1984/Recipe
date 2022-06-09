using Recipes.Controller;
using Recipes.Model;

Console.WriteLine("Recipe book :)");
Console.WriteLine("Input recipe name (or input LOAD to load recipe from file \"recipe.dat\"):");
var name = Console.ReadLine();
if (name == "LOAD")
{
    var recipeController = new RecipeController();
    Console.WriteLine("Name: " + recipeController.Recipe.Name);
    Console.WriteLine("Description: " + recipeController.Recipe.Description);
    Console.WriteLine("Category: " + recipeController.Recipe.Category);
    for (int i = 0; i < recipeController.Recipe.Count; i++)
    {
        Console.WriteLine($"Product {i + 1}: {recipeController.Recipe[i].Name} ({recipeController.Recipe[i].Description}), {recipeController.Recipe[i].Amount}");
    }
    Console.ReadLine();
}
else
{
    while (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Incorrect, input again:");
        name = Console.ReadLine();
    }
    Console.WriteLine("input description:");
    var description = Console.ReadLine();
    Console.WriteLine("input category:");
    var category = Console.ReadLine();

    var recipeController = new RecipeController(name,description,category);

    Console.WriteLine("Now input products");
    var inputMore = true;
    var id = 0;
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
        recipeController.AddProduct(new Product(id, productName,productDescription,productAmount));

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

        id++;
    }
    recipeController.Save();




    Console.ReadLine();
}



