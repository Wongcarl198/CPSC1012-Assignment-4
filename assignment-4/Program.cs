﻿using ClientsCWong;

Client userClient = new();
List<Client> ListOfClients = [];

LoadFileValuesToProgram(ListOfClients);

bool goAgain = true;
while (goAgain)
{
    try
    {
        DisplayMainMenu();
        string userMainInput = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
        if (userMainInput == "N")
        {
            userClient = NewClient();
            addClientToList(userClient, ListOfClients);
        }
        if (userMainInput == "S")
            ShowClientInfo(userClient);
        
        if (userMainInput == "D")
            DisplayAllClientsInfo(ListOfClients);
        
        if (userMainInput == "Q")
        {
            goAgain = false;
            SaveMemoryValuesToFile(ListOfClients);
            throw new Exception("Exiting program. Have a good day!");      
        }
    
        if (userMainInput == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string userEditInput = Prompt("\nWhat would you like to edit?: ").ToUpper();
                if (userEditInput == "F")
                    GetFirstName(userClient);
                if (userEditInput == "L")
                    GetLastName(userClient);
                if (userEditInput == "H")
                    GetHeight(userClient);
                if (userEditInput == "W")
                    GetWeight(userClient);
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
    Console.WriteLine("\nMenu Options");
    Console.WriteLine("============");
    Console.WriteLine("[N]ew client");
    Console.WriteLine("[S]how client BMI info");
    Console.WriteLine("[E]dit client");
    Console.WriteLine("[D]isplay all clients info");
    Console.WriteLine("[Q]uit");
}

void DisplayEditMenu()
{
    Console.WriteLine("\nEdit Client");
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

int PromptInt(string msg, double min)
{
    int userInput = 0;
    while(true)
    {
        try
        {
            Console.Write($"{msg}");
            userInput = int.Parse(Console.ReadLine());
            if (userInput <= min)
                throw new Exception($"Measurement must be greater than {min}.");
            break;
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid: {ex.Message}");
        }
    }
    
    return userInput;
}

void ShowClientInfo(Client client)
{
    if(client.FirstName == "XXXXX" || client.LastName == "XXXXX")
        throw new Exception($"No Client In Memory");
    Console.WriteLine($"\n=== Client Info ===");
    Console.WriteLine($"Client Name:\t{client.FullName}");
    Console.WriteLine($"BMI Score  :\t{client.BmiScore:f2}");
    Console.WriteLine($"BMI Status :\t{client.BmiStatus}");
}

Client NewClient()
{
    Client userClient = new();
    GetFirstName(userClient);
    GetLastName(userClient);
    GetWeight(userClient);
    GetHeight(userClient);

    return userClient;
}

void GetFirstName(Client client)
{
    string userInput = Prompt("Enter client's first name: ");
    client.FirstName = userInput;
}   

void GetLastName(Client client)
{
    string userInput = Prompt("Enter client's last name: ");
    client.LastName = userInput;
}

void GetWeight(Client client)
{
    int userInput = PromptInt("Enter client's weight in pounds: ", 0);
    client.Weight = userInput;
}

void GetHeight(Client client)
{
    int userInput = PromptInt("Enter client's height in inches: ", 0);
    client.Height = userInput;
}

void LoadFileValuesToProgram(List<Client> ListOfClients)
{
    while(true)
    {
        try
        {
            string fileName = "cilents.csv";
            string filePath = $"./data/{fileName}";
            if (!File.Exists(filePath))
                throw new Exception($"{fileName} does not exit.");
            string[] csvFile = File.ReadAllLines(filePath);
            for(int i = 0; i < csvFile.Length; i++)
            {
                string[] info = csvFile[i].Split(',');
                Client userClient = new(info[0], info[1], int.Parse(info[2]), int.Parse(info[3]));
                ListOfClients.Add(userClient);
            }
            Console.WriteLine($"Load complete. {fileName} has {ListOfClients.Count} entries");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}

void SaveMemoryValuesToFile(List<Client> ListOfClients)
{
    string fileName = "cilents.csv";
    string filePath = $"./data/{fileName}";
    string[] csvFileLines = new string[ListOfClients.Count];
    for (int i = 0; i < ListOfClients.Count; i++)
    {
        Console.WriteLine($"{ListOfClients[i]}");
        csvFileLines[i] = ListOfClients[i].ToString();
    }
    File.WriteAllLines(filePath, csvFileLines);
    Console.WriteLine($"Save complete. {fileName} has {ListOfClients.Count} entries.");
}

void addClientToList(Client userClient, List<Client> ListOfClients)
{
    ListOfClients.Add(userClient);
}

void DisplayAllClientsInfo(List<Client> ListOfClients)
{
    foreach(Client client in ListOfClients)
        ShowClientInfo(client);
}