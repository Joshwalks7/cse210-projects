using System;
/// <summary>
/// Entry class sets up member variables of what is defined in an entry. Includes methods to give the user a random prompt to respond to as well as store it. Entry data is able to be split down from a file and compiled in a way to save it into a file.
/// </summary>
public class JWEntry
{
    public string _jwEntryMoodJW;
    public string _jwEntryResponseJW;
    public string _jwEntryDateJW;
    public string _jwEntryPromtJW;

    public void Display()
    // Outlines how a specific entry is to be displayed
    {
        Console.WriteLine($"Date: {_jwEntryDateJW} - Mood: {_jwEntryMoodJW} - Prompt: {_jwEntryPromtJW}");
        Console.WriteLine($"{_jwEntryResponseJW}\n");
    }
    public string GetRandomPrompt()
    // Chooses a random prompt and returns it to the calling function
    {
        List<string> jwPrompts = new List<string>();
        jwPrompts.Add("What was the best part of my day?");
        jwPrompts.Add("Who was the most interesting person I interacted with today?");
        jwPrompts.Add("How did I see the hand of the Lord in my life today?");
        jwPrompts.Add("If I had one thing I could do over today, what would it be?");
        jwPrompts.Add("What moment today made me stop and think for a second?");
        jwPrompts.Add("When did I feel the most motivated or energized today?");
        jwPrompts.Add("What challenge did I handle better than I would have a year ago?");
        jwPrompts.Add("What small detail from today do I want to remember a month from now?");
        jwPrompts.Add("Did I act like the kind of person I want to become today?");

        Random jwRandGenerator = new Random();
        int jwRandIndex = jwRandGenerator.Next(jwPrompts.Count);
        // use random index number to assign a prompt
        string jwRandPrompt = jwPrompts[jwRandIndex];

        return jwRandPrompt;
    }
    public void AssignFileStringAttributes(string jwLine, JWEntry jwEntry)
    //Breaks a line of code from a file into individual parts that can be assigned to attributes in the entry class
    {
        string[] parts = jwLine.Split("|");
        jwEntry._jwEntryDateJW = parts[0];
        jwEntry._jwEntryMoodJW = parts[1];
        jwEntry._jwEntryPromtJW = parts[2];
        jwEntry._jwEntryResponseJW = parts[3];
    }
    public string FormatFileString(JWEntry jwEntry)
    //Properly prepares each entry to be saved into a file. It returns a string of the line
    {
        string jwEntryString = $"{jwEntry._jwEntryDateJW}|{jwEntry._jwEntryMoodJW}|{jwEntry._jwEntryPromtJW}|{jwEntry._jwEntryResponseJW}\n";
        return jwEntryString;
    }
}