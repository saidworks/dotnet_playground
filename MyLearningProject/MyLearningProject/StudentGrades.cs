namespace MyLearningProject;

public class StudentGrades
{

    
    public static void Main(string[] args)
    {
        // initialize variables - graded assignments 
        int currentAssignments = 5;

        int sophia1 = 93;
        int sophia2 = 87;
        int sophia3 = 98;
        int sophia4 = 95;
        int sophia5 = 100;

        int nicolas1 = 80;
        int nicolas2 = 83;
        int nicolas3 = 82;
        int nicolas4 = 88;
        int nicolas5 = 85;

        int zahirah1 = 84;
        int zahirah2 = 96;
        int zahirah3 = 73;
        int zahirah4 = 85;
        int zahirah5 = 79;

        int jeong1 = 90;
        int jeong2 = 92;
        int jeong3 = 98;
        int jeong4 = 100;
        int jeong5 = 97;

        int sophiaSum = calculatSum(sophia1, sophia2, sophia3, sophia4, sophia5);
        int nicolasSum = calculatSum(nicolas1, nicolas2, nicolas3, nicolas4, nicolas5);
        int zahirahSum = calculatSum(zahirah1, zahirah2, zahirah3, zahirah4, zahirah5);
        int jeongSum = calculatSum(jeong1, jeong2, jeong3, jeong4, jeong5);
        
        decimal averageSophia = calculateAverage(sophiaSum, currentAssignments);
        decimal averageNicolas = calculateAverage(nicolasSum, currentAssignments);
        decimal averageZahirah = calculateAverage(zahirahSum, currentAssignments);
        decimal averageJeong = calculateAverage(jeongSum, currentAssignments);
        

        Console.WriteLine($"Average of Sophia:  {averageSophia}   \t {determinesGrade(averageSophia)}");
        Console.WriteLine($"Average of Nicolas: {averageNicolas} \t {determinesGrade(averageNicolas)}");
        Console.WriteLine($"Average of Zahirah: {averageZahirah} \t {determinesGrade(averageZahirah)}");
        Console.WriteLine($"Average of Jeong:   {averageJeong}   \t {determinesGrade(averageJeong)}");

        
    }

    static int calculatSum(int a, int b, int c, int d, int e)
    {
        return a + b + c + d + e;
    }
    static decimal calculateAverage(int sum, int count)
    {
        return (decimal) sum / count;
    }
    
    static string determinesGrade(decimal score)
    {
        if (score >= 90)
        {
            return "A";
        }
        else if (score >= 80)
        {
            return "B";
        }
        else if (score >= 70)
        {
            return "C";
        }
        else if (score >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
        
    }
}