using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Serialization;
//Greeting

Console.WriteLine("Welcome to the shopping App. Here is a list of items and prices.");
Console.WriteLine();

//Headers for columns

Console.WriteLine(string.Format("{0,15}  | {1,15}", "item", "price"));
Console.WriteLine();

//Creates dictionary

Dictionary<string, decimal> menu = new Dictionary<string, decimal>();
menu.Add("running shoes", 159.99m);
menu.Add("t-shirt", 29.99m);
menu.Add("shorts", 19.99m);
menu.Add("hats", 59.99m);
menu.Add("pants", 79.99m);
menu.Add("suit", 599.99m);
menu.Add("jacket", 129.50m);
menu.Add("head band", 12.49m);

//Displays dictionary on console

foreach (KeyValuePair<string, decimal> kvp in menu)
{
    
    {
        Console.WriteLine(string.Format(" {0,15} | {1,15}", $"{kvp.Key}", $"{kvp.Value}"));
    }
    
}

//Creates list to store user input 

List<string> names = new List<string>();

//Asks if user want to continue or quit

while (true)
{
    Console.WriteLine("Would you like to quit or continue? q/c");
    string response = Console.ReadLine().ToLower().Trim();
    if (response == "c")
    {
        break;
    }
    else if (response == "q")
    {
        Console.WriteLine("Thank you. Goodbye");
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("Response invalid, please enter q/c.");
    }
}

//main loop for program

bool runProgram = true;
while (runProgram)
{
 //declares variables 
    decimal sum = 0;
    string input = "";

 //loop to validate user input for items
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("Please enter an item");
        input = Console.ReadLine().ToLower().Trim();
        
        if (menu.Keys.Any(n => n.ToLower().Contains(input)))
        {

          string result = menu.Keys.FirstOrDefault(n => n.ToLower().Contains(input));
            names.Add(result);
            break;
        }
        else
        {
            Console.WriteLine("item doesn't exist. Please choose from the items list");
        }
    }

 //loop to allow user to enter additional items   
    while (true)
    {
        Console.WriteLine("Do you want to add more items? y/n");
        string choice = Console.ReadLine().ToLower().Trim();
        
        if (choice == "y")
        {
            runProgram = true;
            break;
        }
//Displays the shopping list, price, calculates total, and ends program
        else if (choice == "n")
        {
            Console.WriteLine("Your shopping list contains:");
            Console.WriteLine();
            foreach (string n in names)
            {
               
                Console.WriteLine($"item {n} price {menu[n]}");
                if (menu.ContainsKey(n))
                {
                    decimal result1 = menu[n];
                    sum += result1;                    
                }                
            }
            Console.WriteLine();
            Console.WriteLine($" The Total = {sum}");
            Console.WriteLine();
            Console.WriteLine("Thank you. Goodbye");
            runProgram = false;
            break;
        }
        else
        {
            Console.WriteLine("Invalid response, choose y or n");
        }
        
    }
    
}
