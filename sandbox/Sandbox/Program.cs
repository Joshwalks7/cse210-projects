using System;

public class Program 
{
    public static string FindLongestWord(string s) 
    {
        string[] words = s.Split(" ");
        string longestWord = "";
        foreach(string word in words)
        {
            if(word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }
        
        return longestWord; // Fallback
    }

    public static void Main() 
    {
        // Test your code:
        Console.WriteLine(FindLongestWord("The quick brown fox jumped over the lazy dog")); // Expected: "jumped"
        Console.WriteLine(FindLongestWord("Csharp programming is fun"));                  // Expected: "programming"
        Console.WriteLine(FindLongestWord("hi"));                                         // Expected: "hi"
    }
}