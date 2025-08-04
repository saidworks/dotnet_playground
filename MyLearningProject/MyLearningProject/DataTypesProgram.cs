using MyLearningProject;

int fahrenheit = 94;

decimal celsius = (fahrenheit - 32m) * 5m / 9m;

String message = @$"The temperature is {celsius} degrees Celsius";

Console.WriteLine(message);

StudentGrades studentGrades = new StudentGrades();
Console.ReadKey();
