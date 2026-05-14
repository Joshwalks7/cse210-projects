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
}