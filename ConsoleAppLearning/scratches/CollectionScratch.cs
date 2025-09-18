namespace ConsoleAppLearning.scratches;

public class CollectionScratch
{
    public static void play()
    {
        ICollection<string> collection = new List<string>();
        collection.Add("a");
        collection.Add("b");
        collection.Add("c");
        collection.Add("d");

        foreach (var se in collection)
        {
            Console.WriteLine(se);
        }

        string[] names = { "Alex", "Eddie", "David", "Michael" };

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i] == "David")
            {
                names[i] = "Sammy";
            }
        }

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
        Random rnd = new Random();
        List<int> numbers = new List<int>()
        {
            rnd.Next(1, 100),
            rnd.Next(1, 100),
            rnd.Next(1, 100),
            rnd.Next(1, 100),
            rnd.Next(1, 100),
            rnd.Next(1, 100),
            rnd.Next(1, 100),
            rnd.Next(1, 100),
            rnd.Next(1, 100),
            rnd.Next(1, 100)

        };
        numbers.Sort();
        foreach (var number in numbers)
            Console.WriteLine(number);
        for (int i = 1; i < 101; i++)
        {
            if ((i % 3 == 0) && (i % 5 == 0))
                Console.WriteLine($"{i} - FizzBuzz");
            else if (i % 3 == 0)
                Console.WriteLine($"{i} - Fizz");
            else if (i % 5 == 0)
                Console.WriteLine($"{i} - Buzz");
            else
                Console.WriteLine($"{i}");
        }

        int hero = 10;
        int monster = 10;

        Random dice = new Random();

        do
        {
            int roll = dice.Next(1, 11);
            monster -= roll;
            Console.WriteLine($"Monster was damaged and lost {roll} health and now has {monster} health.");

            if (monster <= 0) continue;

            roll = dice.Next(1, 11);
            hero -= roll;
            Console.WriteLine($"Hero was damaged and lost {roll} health and now has {hero} health.");

        } while (hero > 0 && monster > 0);

        Console.WriteLine(hero > monster ? "Hero wins!" : "Monster wins!");

        string? readResult;
        bool validEntry = false;
        Console.WriteLine("Enter a string containing at least three characters:");
        do
        {
            readResult = Console.ReadLine();
            if (readResult != null)
            {
                if (readResult.Length >= 3)
                {
                    validEntry = true;
                }
                else
                {
                    Console.WriteLine("Your input is invalid, please try again.");
                }
            }
        } while (validEntry == false);
    }
}