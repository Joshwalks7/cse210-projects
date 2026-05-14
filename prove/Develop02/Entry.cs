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
}