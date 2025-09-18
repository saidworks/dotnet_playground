namespace ConsoleAppLearning.scratches;

public class StringPlayground
{
    /*
     * A Method that reverse a string and count the number of o letter
     */
    public static Dictionary<string, object> ReverseAndCountO(string str)
    {
        var dict = new Dictionary<string, object>();
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        int x = 0;
        foreach (char i in charArray) { if (i == 'o') { x++; } }
        string newStr = new string(charArray);
        dict.Add("new reversed string", newStr);
        dict.Add("number of o", x);
        return dict;
    }
}