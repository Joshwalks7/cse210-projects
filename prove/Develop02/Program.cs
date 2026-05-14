using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Jolly Ole Journal!");
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


        string _userChoiceJW = "-1";
        Journal journal = new Journal();
        while (_userChoiceJW != "5")
        {
            Console.WriteLine("Please select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            _userChoiceJW = Console.ReadLine();
            if (_userChoiceJW == "1")
            {
                // new instance
                Entry entry = new Entry();
                // get mood
                Console.WriteLine("What is your mood right now?");
                string moodResponse = Console.ReadLine();
                entry._entryMoodJW = moodResponse;
                // function to get random prompt
                string randPrompt = GetRandomPrompt(prompts);

                entry._entryPromtJW = randPrompt;
                Console.WriteLine(randPrompt);
                string response = Console.ReadLine();
                entry._entryResponseJW = response;
                // get datetime
                DateTime theCurrentTime = DateTime.Now;
                entry._entryDateJW = theCurrentTime.ToShortDateString();
                journal._journalEntriesJW.Add(entry);
            }
            else if (_userChoiceJW == "2")
            {
                journal.Display();
            }
            else if (_userChoiceJW == "3")
            {
                Console.Write("What is the file name? ");
                string fileName = Console.ReadLine();
                LoadFile(fileName, journal);
                Console.WriteLine($"{fileName} correctly loaded!");

            }
            else if (_userChoiceJW == "4")
            {
                Console.Write("What file would you like to save this journal in? ");
                string fileName = Console.ReadLine();
                SaveFile(fileName, journal);
                Console.WriteLine($"Journal correctly saved in {fileName}");
            }
            else if (_userChoiceJW == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid selection");
            }
        }
        
        static string GetRandomPrompt(List<string> prompts)
        {
            Random randGenerator = new Random();
            int randIndex = randGenerator.Next(prompts.Count);
            string randPrompt = prompts[randIndex];
            return randPrompt;
        }

        static void LoadFile(string fileName, Journal journal)
        {

            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Entry entry = new Entry();
                string[] parts = line.Split(",");
                entry._entryDateJW = parts[0];
                entry._entryMoodJW = parts[1];
                entry._entryPromtJW = parts[2];
                entry._entryResponseJW = parts[3];
                
                journal._journalEntriesJW.Add(entry);
            }
        }

        static void SaveFile(string fileName, Journal journal)
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
                {
                    foreach (Entry entry in journal._journalEntriesJW)
                    {
                        outputFile.WriteLine($"{entry._entryDateJW},{entry._entryMoodJW},{entry._entryPromtJW},{entry._entryResponseJW}");
                    }
                }
        }
    }
}