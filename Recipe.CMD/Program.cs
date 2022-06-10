using Recipes.Controller;
using Recipes.Model;

Console.WriteLine("Recipe book :)");
Console.WriteLine("Input recipe name :");
var name = Console.ReadLine();

var recipeController = new RecipeController(name);
if (recipeController.IsNewRecipe)
{
    Console.WriteLine("input description (may be empty): ");
    var recipeDescription = Console.ReadLine();
    Console.WriteLine("input category (0 - salads, 1 - soups, 2 - hot, 3 - desert, 4 - drink):");

    Recipe.Cat recipeCategory = new Recipe.Cat();
    var inputIsOk = false;
    do
    {    
        if (int.TryParse(Console.ReadLine(),out int result))    
        {        
            if (result >= 0 && result <= 4)        
            {            
                inputIsOk = true;                
                switch (result)
                {
                    case 0:
                        recipeCategory = Recipe.Cat.Salads;
                        break;
                    case 1:
                        recipeCategory = Recipe.Cat.Soups;
                        break;
                    case 2:
                        recipeCategory = Recipe.Cat.Hot;
                        break;
                    case 3:
                        recipeCategory = Recipe.Cat.Desert;
                        break;
                    case 4:
                        recipeCategory = Recipe.Cat.Drink;
                        break;
                    default:
                        break;
                }
            }        
            else        
            {
                Console.WriteLine("input category:");        
            }    
        }
    } while (inputIsOk == false);

    List<Product> products = new List<Product>();
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
        products.Add(new Product(id, productName, productDescription, productAmount));

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

    recipeController.SetRecipe(recipeDescription, recipeCategory, products);
}
else
{
    var recipes = recipeController.GetRecipes();
    foreach (var recipe in recipes)
    {
        Console.WriteLine("-----------------------------------------------------------------------------");
        Console.WriteLine($"Recipe of {recipe.Name}:");
        Console.WriteLine($"Description: { recipe.Description}");
        Console.WriteLine($"Category: {recipe.Category}");
        Console.WriteLine("--Ingridients:--");
        foreach (var product in recipe)
        {
            Console.WriteLine($"{product.Name} - {product.Amount} : {product.Description}");
        }
    }
}








//while (string.IsNullOrWhiteSpace(name))
//    {
//        Console.WriteLine("Incorrect, input again:");
//        name = Console.ReadLine();
//    }
//    Console.WriteLine("input description:");
//    var description = Console.ReadLine();
//    Console.WriteLine("input category:");
//    var category = Console.ReadLine();

//    var recipeController = new RecipeController(name,description,category);

//    Console.WriteLine("Now input products");
//    var inputMore = true;
//    var id = 0;
//    string productName;
//    string productDescription;
//    string productAmount;
//    while (inputMore)
//    {
//        Console.WriteLine("Input product name:");
//        productName = Console.ReadLine();
//        Console.WriteLine("Input product descriprion:");
//        productDescription = Console.ReadLine();
//        Console.WriteLine("Input product amount:");
//        productAmount = Console.ReadLine();
//        recipeController.AddProduct(new Product(id, productName,productDescription,productAmount));

//        Console.WriteLine("do you want to input more products? (input \"Y\" for input one more product and input \"N\" for end)");
//        var input = Console.ReadLine();
//        while (true)
//        {
//            if (input.ToLower() == "y")
//            {
//                break;
//            }
//            if (input.ToLower() == "n")
//            {
//                inputMore = false;
//                break;
//            }
//            Console.WriteLine("input Y or N");
//            input = Console.ReadLine();
//        }

//        id++;
//    }
//    recipeController.Save();




Console.ReadLine();



