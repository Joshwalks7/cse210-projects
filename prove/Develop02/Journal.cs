using System;
/// <summary>
/// Journal class hold journal entries in a list that can be manipulated using methods
/// </summary>
public class JWJournal
{
    public List<JWEntry> _jwJournalEntries = new List<JWEntry>();

    public void DisplayJournal()
    // Display the entries in the journal
    {
        foreach (JWEntry jwEntry in _jwJournalEntries)
        {
            jwEntry.Display();
        }
    }

    public void CreateEntry(JWJournal jwJournal)
    // Create a new entry class, prompt the user for entry responses, and add to journal collection
    {
            // new instance
            JWEntry jwEntry = new JWEntry();

            // get mood
            Console.WriteLine("What is your mood right now?");
            string jwMoodResponse = Console.ReadLine();
            jwEntry._jwEntryMoodJW = jwMoodResponse;

            // method to get random prompt
            string jwRandPrompt = jwEntry.GetRandomPrompt();
            jwEntry._jwEntryPromtJW = jwRandPrompt;

            // write prompt
            Console.WriteLine(jwRandPrompt);

            // capture response
            string jwResponse = Console.ReadLine();
            jwEntry._jwEntryResponseJW = jwResponse;

            // get datetime
            DateTime jwTheCurrentTime = DateTime.Now;
            jwEntry._jwEntryDateJW = jwTheCurrentTime.ToShortDateString();

            //add journal entry to journal list
            jwJournal._jwJournalEntries.Add(jwEntry);
    }

    public void LoadFileString(string[] jwJournalLines, JWJournal jwJournal)
    // Loop lines of text from the desired file through the JWEntry.LoadFileEntry method to add them to a journal
    {
        foreach (string jwLine in jwJournalLines)
            {
                JWEntry jwEntry = new JWEntry();
                jwEntry.AssignFileStringAttributes(jwLine, jwEntry);
                
                jwJournal._jwJournalEntries.Add(jwEntry);
            }
    }

    public string GatherAllJournalEntries(JWJournal jwJournal)
    // Compile a string of formatted code using the JWEntry.StringEntry method that can be returned and saved into a file.
    {
        string jwJournalString = "";
        foreach (JWEntry jwEntry in jwJournal._jwJournalEntries)
        {
            jwJournalString += jwEntry.FormatFileString(jwEntry);
        }
        return jwJournalString;
    }
    
    public void DisplayNumEntries(JWJournal jwJournal)
    // Creativity -- Count/display the number of journal entries in a journal
    {
        int jwNum = jwJournal._jwJournalEntries.Count;

        if (jwNum == 1)
        {
            Console.WriteLine($"Your journal consists of 1 entry. Keep it up!");
        }
        else
        {
            Console.WriteLine($"Your journal consists of {jwNum} entries!");
        }
    }
}