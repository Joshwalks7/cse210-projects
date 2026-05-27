using System;
// strings with quotes: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-put-quotation-marks-in-a-string-windows-forms

class Program
{
    static void Main(string[] args)
    {
        JWReference reference = new JWReference("1 Nephi", 7, 8, 9);
        JWScripture scripture = new JWScripture(reference, "And it came to pass that Rychen became a baller.");
        string jwUserChoice = "";
        // bool jwContinueProgram = true;
        Console.WriteLine(scripture.WordListToString());
        jwUserChoice = GetUserInput("Enter to make the memorization harder, or type \"quit\": ");
        while (jwUserChoice.ToLower() != "quit" && scripture.DetermineContinuation() == true)
        {
            scripture.HideWords();
            Console.WriteLine(scripture.WordListToString());
            if (scripture.DetermineContinuation() == true)
            {
            jwUserChoice = GetUserInput("Enter to make the memorization harder, or type \"quit\": "); 
            }            
        }
    }
    static string GetUserInput(string jwMessage)
    {
        Console.Write(jwMessage);
        string jwUserResponse = Console.ReadLine();
        return jwUserResponse;
    }
}