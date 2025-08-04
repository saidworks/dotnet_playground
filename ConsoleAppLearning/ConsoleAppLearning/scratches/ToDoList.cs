namespace ConsoleAppLearning;
using Microsoft.Extensions.Logging;
public class ToDoList
{
    private static List<string> tasksList = new List<string>();
    private static int tasksCount = 0;
    private static ILogger<Program> _logger;


    public static void RunApp()
    {
         using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .SetMinimumLevel(LogLevel.Information)
                .AddConsole(); // Add this line to enable console logging
        });
        _logger = loggerFactory.CreateLogger<Program>();
        int userInput;
        bool continueProgram = true;
        try
        {
            do
            {
                _logger.LogInformation("Starting the program...");
                Console.WriteLine(@" Welcome to the To Do List App, please
                                choose an option from the following:
                                1. Add Task
                                2. Remove Task
                                3. Edit Task
                                4. Clear all tasks
                                5. View all tasks
                                6. Mark a task as complete
                                
                                Enter any other number to exit");
                var input = Console.ReadLine();
                int.TryParse(input, out userInput);
                {
                    if ( userInput is >= 1 and <= 6)
                    {
                        _logger.LogInformation("User input: {userInput}", userInput);
                        switch (userInput)
                        {
                            case 1:
                                _logger.LogInformation("Adding a task...");
                                ToDoList.AddTask();
                                break;
                            case 2:
                                _logger.LogInformation("Removing a task...");
                                Console.WriteLine("Enter task: ");
                                string taskToRemove = Console.ReadLine();
                                ToDoList.RemoveTask(taskToRemove);
                                break;
                            case 3:
                                _logger.LogInformation("Editing a task...");
                                Console.WriteLine("Enter old task: ");
                                string taskToEdit = Console.ReadLine();
                                Console.WriteLine("Enter new task: ");
                                string newTask = Console.ReadLine();
                                ToDoList.editTask(taskToEdit, newTask);
                                break;
                            case 4:
                                _logger.LogInformation("Clearing all tasks...");
                                ToDoList.ClearTasks();
                                break;
                            case 5:
                                _logger.LogInformation("Viewing all tasks...");
                                ToDoList.ViewTasks();
                                break;
                            case 6:
                                _logger.LogInformation("Marking a task as complete...");
                                Console.WriteLine("Enter the completed task: ");
                                string taskCompleted = Console.ReadLine();
                                ToDoList.CompleteTask(task: taskCompleted);
                                break;
          
                        }
                    }
                    else
                    {
                        _logger.LogInformation("Invalid input");
                        Console.WriteLine("Exiting the program...");
                        continueProgram = false;
                    }

               
                }
            } while (continueProgram);

  
        }

        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    
    public static void AddTask()
    {
        try
        {
            Console.WriteLine("Enter task: ");
            string task = Console.ReadLine();
            tasksList.Add(task);
            tasksCount++;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }
    public static void ListTasks()
    {
        Console.WriteLine("Tasks:");
        for (int i = 0; i < tasksCount; i++)
        {
            Console.WriteLine(tasksList[i]);
        }
    }
    public static void RemoveTask(string task)
    {
        tasksList.Remove(task);
    }

    public static void ClearTasks()
    {
        tasksList.Clear();
    }
    public static void ViewTasks()
    {
        foreach (var task in tasksList)
        {
            Console.WriteLine(task);
        }
    }

    public static void editTask(string task, string newTask)
    {
        tasksList.Remove(task);
        tasksList.Add(newTask);
    }

    public static void CompleteTask(string task)
    {
        editTask(task, @$"[Completed] {task}");
    }

}