using System;

class Program
{
    static void Main(string[] args)
    {
        string fileName = "myFile.txt";

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine("Collection of jokes? ready");
            string joke = "How many eye doctors does it take to change a lightbulb? 1... or 2";
            string joke1 = "Who is the best? Yo mama!";
            outputFile.WriteLine(joke);
            outputFile.WriteLine(joke1);
        }

        LoadFile(fileName);

        static void LoadFile(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split("? ");
                string joke = parts[0];
                string answer = parts[1];
                Console.WriteLine(joke);
                Console.WriteLine(answer);
            }
        }
    }
}