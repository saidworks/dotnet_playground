namespace ConsoleAppLearning.scratches;

public class ControlFlowExample
{
    public static void SwitchExample()
    {
        Console.WriteLine("Enter a number: ");
        String userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                Console.WriteLine("You entered 1");
                break;
            case "2":
                Console.WriteLine("You entered 2");
                break;
            default:
                Console.WriteLine("You entered something else");
                break;
        }


    }
}