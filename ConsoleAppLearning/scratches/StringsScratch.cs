namespace ConsoleAppLearning.scratches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StringsScratch
{
    public string LongestCommonPrefix(string[] strs)
    {
        return tring prefix = strs[0];
        for(int i=0; i < prefix.Length; i++){
            strs.Where()   
        };
    }
    public int RomanToInt(string s) {
        /*
         Symbol       Value
            I             1
            V             5
            X             10
            L             50
            C             100
            D             500
            M             1000
            I can be placed before V (5) and X (10) to make 4 and 9.
            X can be placed before L (50) and C (100) to make 40 and 90.
            C can be placed before D (500) and M (1000) to make 400 and 900.
            "MCMXCIV"
        */
        char[] acceptedChars = {'I', 'V', 'X', 'L', 'C', 'D', 'M'}; 
        bool isValid = s.Length >= 1 && s.Length <= 15 && s.All(c => Array.IndexOf(acceptedChars, c) >= 0);
        if(!isValid){
            throw new ArgumentException("invalid char in input");
        }

        Dictionary<char, int> values = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // If current value is less than next value, subtract current from result
            if (i + 1 < s.Length && values[s[i]] < values[s[i + 1]])
            {
                result -= values[s[i]];
            }
            else
            {
                result += values[s[i]];
            }
        }

        return result;
    }
    
}