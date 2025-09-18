using System;
using System.IO;

namespace ConsoleAppLearning.console;

public class PetUI
{
    // the ourAnimals array will store the following: 
    private record struct Pet(
        string species,
        string id,
        string age,
        string nickname,
        string physicalDescription,
        string personalityDescription);


    // variables that support data entry
    int maxPets = 8;
    string? readResult;
    string menuSelection = "";
    int petCount = 0;
    string anotherPet = "y";
    bool validEntry = false;
    int petAge = 0;

    public void PetMenu()
    {
        // array used to store runtime data, there is no persisted data
        Pet[] ourAnimals = new Pet[maxPets];

        // create some initial ourAnimals array entries
        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    ourAnimals[i] = new Pet("dog", "d1", "2", "lola",
                        "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.",
                        "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.");
                    break;

                case 1:
                    ourAnimals[i] = new Pet("dog", "d2", "9", "loki",
                        "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.",
                        "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.");
                    break;

                case 2:
                    ourAnimals[i] = new Pet("cat", "c3", "1", "Puss",
                        "small white female weighing about 8 pounds. litter box trained.",
                        "friendly");
                    break;

                case 3:
                    ourAnimals[i] = new Pet("cat", "c4", "?", "",
                        "",
                        "");
                    break;

                default:
                    ourAnimals[i] = new Pet("", "", "", "",
                        "",
                        "");
                    break;
            }
        }

        // display the top-level menu options
        do
        {
            Console.Clear();

            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
            Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
            Console.WriteLine(" 4. Display all cats with a specified characteristic");
            Console.WriteLine(" 5. Display all dogs with a specified characteristic");
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
                    // List all of our current pet information
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (!string.IsNullOrEmpty(ourAnimals[i].id))
                        {
                            displayPet(ourAnimals[i]);
                        }
                    }

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;

                case "2":
                    // Add a new animal friend to the ourAnimals array
                    string animalSpecies = "";
                    string animalID = "";
                    string animalAge = "";
                    string animalNickname = "";
                    string animalPhysicalDescription = "";
                    string animalPersonalityDescription = "";

                    anotherPet = "y";
                    petCount = 0;
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (!string.IsNullOrEmpty(ourAnimals[i].id))
                        {
                            petCount += 1;
                        }
                    }

                    if (petCount < maxPets)
                    {
                        Console.WriteLine(
                            $"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
                    }

                    while (anotherPet == "y" && petCount < maxPets)
                    {
                        // get species (cat or dog)
                        do
                        {
                            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalSpecies = readResult.ToLower();
                                if (animalSpecies != "dog" && animalSpecies != "cat")
                                {
                                    validEntry = false;
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        // build animal ID
                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                        // get age
                        do
                        {
                            Console.WriteLine("Enter the pet's age or enter ? if unknown");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult;
                                if (animalAge != "?")
                                {
                                    validEntry = int.TryParse(animalAge, out petAge);
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        // get physical description
                        do
                        {
                            Console.WriteLine(
                                "Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult.ToLower();
                                if (string.IsNullOrEmpty(animalPhysicalDescription))
                                {
                                    animalPhysicalDescription = "tbd";
                                }

                                validEntry = true;
                            }
                        } while (validEntry == false);

                        // get personality description
                        do
                        {
                            Console.WriteLine(
                                "Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.ToLower();
                                if (string.IsNullOrEmpty(animalPersonalityDescription))
                                {
                                    animalPersonalityDescription = "tbd";
                                }

                                validEntry = true;
                            }
                        } while (validEntry == false);

                        // get nickname
                        do
                        {
                            Console.WriteLine("Enter a nickname for the pet");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalNickname = readResult.ToLower();
                                if (string.IsNullOrEmpty(animalNickname))
                                {
                                    animalNickname = "tbd";
                                }

                                validEntry = true;
                            }
                        } while (validEntry == false);

                        // store the pet information
                        ourAnimals[petCount] = new Pet(animalSpecies, animalID, animalAge, animalNickname,
                            animalPhysicalDescription, animalPersonalityDescription);

                        petCount = petCount + 1;

                        if (petCount < maxPets)
                        {
                            Console.WriteLine("Do you want to enter info for another pet (y/n)");
                            do
                            {
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    anotherPet = readResult.ToLower();
                                }
                            } while (anotherPet != "y" && anotherPet != "n");
                        }
                    }

                    if (petCount >= maxPets)
                    {
                        Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                    }

                    break;

                case "3":
                    // Ensure animal ages and physical descriptions are complete
                    // Collect incomplete fields for all pets (map index -> fields)
                    Dictionary<int, List<string>> invalidFields = new Dictionary<int, List<string>>();
                    for (int i = 0; i < Math.Min(maxPets, ourAnimals.Length); i++)
                    {
                        var fields = GetIncompleteFields(ourAnimals[i]);
                        if (fields != null && fields.Count > 0)
                        {
                            invalidFields[i] = fields;
                        }
                    }

                    if (invalidFields.Count > 0)
                    {
                        Console.WriteLine("The following fields are incomplete:");
                        // Iterate over a snapshot of keys to allow modifications while processing
                        foreach (var kvp in invalidFields.ToArray())
                        {
                            int index = kvp.Key;
                            var fields = kvp.Value;
                            Console.WriteLine($"  Pet #{index + 1} ({ourAnimals[index].species})");
                            // Iterate backwards so removals don't affect upcoming indices
                            for (int fIdx = fields.Count - 1; fIdx >= 0; fIdx--)
                            {
                                var field = fields[fIdx];
                                string readResultLocal = null;
                                bool isValid = false;

                                while (!isValid)
                                {
                                    Console.WriteLine($"  {field}");
                                    var allowUnknown = field == "age";
                                    Console.WriteLine(
                                        $"Please enter updated value for {field}{(allowUnknown ? " (or '?' to leave unknown)" : "")}:");
                                    readResultLocal = Console.ReadLine();

                                    if (readResultLocal == null)
                                    {
                                        // Treat null as closed/empty input; re-prompt
                                        Console.WriteLine("Input was empty or stream closed. Please enter a value.");
                                        continue;
                                    }

                                    readResultLocal = readResultLocal.Trim();

                                    switch (field)
                                    {
                                        case "age":
                                            if (readResultLocal == "?")
                                            {
                                                // Set unknown marker
                                                ourAnimals[index] = ourAnimals[index] with { age = "?" };
                                                isValid = true;
                                            }
                                            else if (int.TryParse(readResultLocal, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int parsedAge) && parsedAge >= 0)
                                            {
                                                ourAnimals[index] = ourAnimals[index] with { age = parsedAge.ToString(System.Globalization.CultureInfo.InvariantCulture) };
                                                isValid = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid age format. Please enter a non-negative integer or '?'");
                                            }
                                            break;

                                        case "species":
                                            var speciesLower = readResultLocal.ToLowerInvariant();
                                            if (speciesLower == "dog" || speciesLower == "cat")
                                            {
                                                ourAnimals[index] = ourAnimals[index] with { species = speciesLower };
                                                isValid = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid species. Please enter 'dog' or 'cat'.");
                                            }
                                            break;

                                        case "nickname":
                                            if (string.IsNullOrWhiteSpace(readResultLocal) || readResultLocal.ToLowerInvariant() == "tbd")
                                            {
                                                Console.WriteLine("Please enter a valid nickname (not blank or 'tbd').");
                                            }
                                            else
                                            {
                                                ourAnimals[index] = ourAnimals[index] with { nickname = readResultLocal };
                                                isValid = true;
                                            }
                                            break;

                                        case "physical description":
                                            if (string.IsNullOrWhiteSpace(readResultLocal))
                                            {
                                                Console.WriteLine("Please enter a valid physical description (not blank).");
                                            }
                                            else
                                            {
                                                ourAnimals[index] = ourAnimals[index] with { physicalDescription = readResultLocal };
                                                isValid = true;
                                            }
                                            break;
                                        
                                        case "personality description":
                                            ourAnimals[index] = ourAnimals[index] with { personalityDescription = readResultLocal };
                                            isValid = true;
                                            break;
                                        default:
                                            // For unknown fields accept input but don't modify model automatically
                                            isValid = true;
                                            break;
                                    }
                                } // while re-prompt for this field

                                if (isValid)
                                {
                                    // remove the completed field from the list
                                    invalidFields[index].RemoveAt(fIdx);
                                }
                            } // for each field (reverse)

                            // if no more incomplete fields for this pet, remove its entry
                            if (!invalidFields.ContainsKey(index) || invalidFields[index].Count == 0)
                            {
                                invalidFields.Remove(index);
                            }
                        } // foreach pet snapshot
                    }
                    else
                    {
                        Console.WriteLine("No incomplete fields found.");
                    }

                    Console.WriteLine("Press the Enter key to continue.");
                    Console.ReadLine();
                    break;

                case "4":
                    // Display all cats with a specified characteristic
                    for(var i = 0; i < ourAnimals.Length; i++)  
                    {
                        if (ourAnimals[i].species.Equals("cat"))
                        {
                            displayPet(ourAnimals[i]);
                            Task.Delay(5000);
                        }
                    }
                    break;

                case "5":
                    // Display all dogs with a specified characteristic
                    for(var i = 0; i < ourAnimals.Length; i++)  
                    {
                        if (ourAnimals[i].species.Equals("dog"))
                        {
                            displayPet(ourAnimals[i]);
                            Task.Delay(5000);
                        }
                    }
                    break;

                    break;

                default:
                    break;
            }
        } while (menuSelection != "exit");
    }

    private List<string> GetIncompleteFields(Pet pet)
    {
        var incompleteFields = new List<string>();
        if (string.IsNullOrEmpty(pet.species)) incompleteFields.Add("species");
        if (string.IsNullOrEmpty(pet.id)) incompleteFields.Add("id");
        if (pet.age == "?" || string.IsNullOrEmpty(pet.age)) incompleteFields.Add("age");
        if (string.IsNullOrEmpty(pet.nickname) || pet.nickname == "tbd") incompleteFields.Add("nickname");
        if (string.IsNullOrEmpty(pet.physicalDescription) || pet.physicalDescription == "tbd")
            incompleteFields.Add("physical description");
        if (string.IsNullOrEmpty(pet.personalityDescription) || pet.personalityDescription == "tbd")
            incompleteFields.Add("personality description");

        return incompleteFields;
    }
    
    private void displayPet(Pet pet)
    {
        Console.WriteLine($"ID: {pet.id}");
        Console.WriteLine($"Species: {pet.species}");
        Console.WriteLine($"Age: {pet.age}");
        Console.WriteLine($"Nickname: {pet.nickname}");
        Console.WriteLine($"Physical description: {pet.physicalDescription}");
        Console.WriteLine($"Personality: {pet.personalityDescription}");
        Console.WriteLine();
    }
}