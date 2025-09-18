namespace ConsoleAppLearning.patterns;

public abstract class Animal
{
    public abstract void Speak();
}

public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Meow!");
    }
}

public class AnimalFactory
{
    public static Animal CreateAnimal(string type)
    {
        if (type == "Dog")
        {
            return new Dog();
        }
        else if (type == "Cat")
        {
            return new Cat();
        }
        else
        {
            throw new ArgumentException("Invalid animal type");
        }
    }
}

// public class Program
// {
//     public static void Main()
//     {
//         Animal dog = AnimalFactory.CreateAnimal("Dog");
//         dog.Speak(); // Outputs: Woof!
//
//         Animal cat = AnimalFactory.CreateAnimal("Cat");
//         cat.Speak(); // Outputs: Meow!
//     }
// }