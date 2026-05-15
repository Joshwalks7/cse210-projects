using System;

public class Entry
{
    public string _entryMoodJW;
    public string _entryResponseJW;
    public string _entryDateJW;
    public string _entryPromtJW;

    public void Display()
    {
        Console.WriteLine($"Date: {_entryDateJW} - Mood: {_entryMoodJW} - Prompt: {_entryPromtJW}");
        Console.WriteLine($"{_entryResponseJW}\n");
    }
    public string GetRandomPrompt()
    {
        List<string> prompts = new List<string>();
        prompts.Add("Who was the most interesting person I interacted with today?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("How did I see the hand of the Lord in my life today?");
        prompts.Add("What was the strongest emotion I felt today?");
        prompts.Add("If I had one thing I could do over today, what would it be?");
        prompts.Add("What moment today made me stop and think for a second?");
        prompts.Add("When did I feel the most motivated or energized today?");
        prompts.Add("What challenge did I handle better than I would have a year ago?");
        prompts.Add("What small detail from today do I want to remember a month from now?");
        prompts.Add("Did I act like the kind of person I want to become today?");

        Random randGenerator = new Random();
        int randIndex = randGenerator.Next(prompts.Count);
        string randPrompt = prompts[randIndex];
        return randPrompt;
    }
    public void LoadFileEntry(string line, Entry entry)
    {
        string[] parts = line.Split("|");
        entry._entryDateJW = parts[0];
        entry._entryMoodJW = parts[1];
        entry._entryPromtJW = parts[2];
        entry._entryResponseJW = parts[3];
    }
    public string StringEntry(Entry entry)
    {
        string entryStringJW = $"{entry._entryDateJW}|{entry._entryMoodJW}|{entry._entryPromtJW}|{entry._entryResponseJW}\n";
        return entryStringJW;
    }
}