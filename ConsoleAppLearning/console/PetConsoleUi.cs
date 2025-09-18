namespace ConsoleAppLearning.console;


public class PetConsoleUi
{
    // the ourAnimals array will store the following: 
    private static string animalSpecies = "";
    private static string animalID = "";
    private static string animalAge = "";
    private static string animalPhysicalDescription = "";
    private static string animalPersonalityDescription = "";
    private static string animalNickname = "";

    // variables that support data entry
    private static int maxPets = Int16.MaxValue;
    private static string? readResult;
    private static string menuSelection = "";

    // array used to store runtime data, there is no persisted data
    private static string[,] ourAnimals = new string[maxPets, 6];

    public static void EntryPoint()
    {
        // create some initial ourAnimals array entries
        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    break;
                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "loki";
                    break;
                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "Puss";
                    break;
                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "?";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    break;
                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    break;
            }

            ourAnimals[i, 0] = "ID #: " + animalID;
            ourAnimals[i, 1] = "Species: " + animalSpecies;
            ourAnimals[i, 2] = "Age: " + animalAge;
            ourAnimals[i, 3] = "Nickname: " + animalNickname;
            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
        }

        do
        {


            // display the top-level menu options
            Console.Clear();

            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
            Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
            Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
            Console.WriteLine(" 5. Edit an animal's age");
            Console.WriteLine(" 6. Edit an animal's personality description");
            Console.WriteLine(" 7. Display all cats with a specified characteristic");
            Console.WriteLine(" 8. Display all dogs with a specified characteristic");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
            }

            switch (menuSelection)
            {
                case "1":
                    // display all of our current pet information
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 6; j++)
                            {
                                Console.WriteLine(ourAnimals[i, j]);
                            }
                        }
                    }
                    Console.WriteLine("\nPress the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                case "2":
                    // add a new animal friend to the ourAnimals array
                    Console.Clear();
                    Console.WriteLine("Enter the new animal's species (dog or cat)");
                    readResult = Console.ReadLine();
                    animalSpecies = readResult.ToLower();
                    Console.WriteLine("Enter the new animal's ID number (e.g. d1, c2, etc.)");
                    readResult = Console.ReadLine();
                    animalID = readResult;
                    Console.WriteLine("Enter the new animal's age");
                    readResult = Console.ReadLine();
                    animalAge = readResult;
                    Console.WriteLine("Enter the new animal's physical description");
                    readResult = Console.ReadLine();
                    animalPhysicalDescription = readResult;
                    Console.WriteLine("Enter the new animal's personality description");
                    readResult = Console.ReadLine();
                    animalPersonalityDescription = readResult;
                    Console.WriteLine("Enter the new animal's nickname");
                    readResult = Console.ReadLine();
                    animalNickname = readResult;
                    ourAnimals[maxPets, 0] = "ID #: " + animalID;
                    ourAnimals[maxPets, 1] = "Species: " + animalSpecies;
                    ourAnimals[maxPets, 2] = "Age: " + animalAge;
                    ourAnimals[maxPets, 3] = "Nickname: " + animalNickname;
                    ourAnimals[maxPets, 4] = "Physical description: " + animalPhysicalDescription;
                    ourAnimals[maxPets, 5] = "Personality: " + animalPersonalityDescription;
                    Console.WriteLine("The new animal has been added to ourAnimals array.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;
                case "3":
                    // ensure animal ages and physical descriptions are complete
                    Console.Clear();
                    Console.WriteLine("Enter the ID number of the animal whose age and physical description you want to check");
                    readResult = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(readResult))
                    {
                        Console.WriteLine("Invalid ID entered. Press Enter to continue.");
                        readResult = Console.ReadLine();
                        break;
                    }

                    int foundIndex = -1;
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0].Contains(readResult))
                        {
                            foundIndex = i;
                            break;
                        }
                    }

                    if (foundIndex == -1)
                    {
                        Console.WriteLine("Animal not found. Press Enter to continue.");
                        readResult = Console.ReadLine();
                        break;
                    }

                    string[] selectedAnimal = new string[6];
                    for (int j = 0; j < 6; j++)
                    {
                        selectedAnimal[j] = ourAnimals[foundIndex, j];
                    }
                    break;
                    
                    
            }

            Console.WriteLine($"You selected menu option {menuSelection}.");
            Console.WriteLine("Press the Enter key to continue");

            // pause code execution
            readResult = Console.ReadLine();
        } while (menuSelection != "Exit");

    }
}