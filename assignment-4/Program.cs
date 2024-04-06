
bool goAgain = true;
while (goAgain)
{
    try
    {
        DisplayMainMenu();
        string userMainInput = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
        if (userMainInput == "N")
            Console.WriteLine("New client");
        if (userMainInput == "S")
            Console.WriteLine("show client");
        
        if (userMainInput == "Q")
        {
            goAgain = false;
            throw new Exception("Exiting program. Have a good day!");      
        }
    
        if (userMainInput == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string userEditInput = Prompt("\nEnter a Edit Menu Choice: ").ToUpper();
                if (userEditInput == "F")
                    Console.WriteLine("You are changing the first name");
                if (userEditInput == "L")
                    Console.WriteLine("You are change the last name");
                if (userEditInput == "H")
                    Console.WriteLine("You are changing the height");
                if (userEditInput == "W")
                    Console.WriteLine("You are changing the weight");
                if (userEditInput == "R")
                    throw new Exception("Returning to Main Menu");
            }
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}


void DisplayMainMenu()
{
    Console.WriteLine("Menu Options");
    Console.WriteLine("============");
    Console.WriteLine("[N]ew client");
    Console.WriteLine("[S]how client BMI info");
    Console.WriteLine("[E]dit client");
    Console.WriteLine("[Q]uit");
}

void DisplayEditMenu()
{
    Console.WriteLine("Edit Client");
    Console.WriteLine("===========");
    Console.WriteLine("[F]irst Name");
    Console.WriteLine("[L]ast Name");
    Console.WriteLine("[H]eight");
    Console.WriteLine("[W]eight");
    Console.WriteLine("[R]eturn to main menu");
}

string Prompt(string prompt)
{
    string userInput ="";
    while(true)
    {
        try
        {
            Console.Write(prompt);
            userInput = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(userInput))
            {
                throw new Exception($"No input found: Please provide input.");
            }
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return userInput;
}

double PromptDoubleBetweenMinMax(string msg, double max, double min)
{
    double userInput = 0;
    while(true)
    {
        try
        {
            Console.Write($"{msg} between {min} and {max}: ");
            userInput = double.Parse(Console.ReadLine());
            if (userInput < min || userInput > max)
                {
                    throw new Exception($"Must be between {min:n2} and {max:n2}");
                }
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid: {ex.Message}");
        }
    }
    return userInput;
}