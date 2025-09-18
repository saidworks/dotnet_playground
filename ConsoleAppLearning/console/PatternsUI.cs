namespace ConsoleAppLearning.console;
using ConsoleAppLearning.patterns;

public class PatternsUI
{
    public static void displayPatterns()
    {
        // Adapter Pattern
        // Adaptee adaptee = new Adaptee();
        // ITarget target = new Adapter(adaptee);
        //
        // target.Request(); // Outputs: Specific request is called.

        // Observer pattern
        Subject subject = new Subject();

        IObserver observer1 = new ConcreteObserver("Observer 1");
        IObserver observer2 = new ConcreteObserver("Observer 2");

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.Notify("Hello, Observers!"); // Outputs: "Observer 1 received message: Hello, Observers!"
                                             //          "Observer 2 received message: Hello, Observers!"



    }
}