using System;

public class Journal
{
    public List<Entry> _journalEntriesJW = new List<Entry>();

    public void Display()
    {
        foreach (Entry entry in _journalEntriesJW)
        {
            entry.Display();
        }
    }
    public void CreateEntry(Journal journal)
    {
            // new instance
            Entry entry = new Entry();

            // get mood
            Console.WriteLine("What is your mood right now?");
            string moodResponse = Console.ReadLine();
            entry._entryMoodJW = moodResponse;

            // method to get random prompt
            string randPrompt = entry.GetRandomPrompt();
            entry._entryPromtJW = randPrompt;

            // write prompt
            Console.WriteLine(randPrompt);

            // capture response
            string response = Console.ReadLine();
            entry._entryResponseJW = response;

            // get datetime
            DateTime theCurrentTime = DateTime.Now;
            entry._entryDateJW = theCurrentTime.ToShortDateString();

            //add journal entry to journal list
            journal._journalEntriesJW.Add(entry);
    }
    public void FromString(string[] journallines, Journal journal)
    {
        foreach (string line in journallines)
            {
                Entry entry = new Entry();
                entry.LoadFileEntry(line, entry);
                
                journal._journalEntriesJW.Add(entry);
            }
    }
    public string StringJournal(Journal journal)
    {
        string journalString = "";
        foreach (Entry entry in journal._journalEntriesJW)
        {
            journalString += entry.StringEntry(entry);
        }
        return journalString;
    }
    public void DisplayNumEntries(Journal journal)
    {
        int numJW = journal._journalEntriesJW.Count;
        if (numJW == 1)
        {
            Console.WriteLine($"Your journal consists of 1 entry. Keep it up!\n");
        }
        else
        {
            Console.WriteLine($"Your journal consists of {numJW} entries!\n");
        }
    }
}