/*
Author: Joshua Walker
Description: Write a scripture memorization program that shows the user a scripture reference and text and hides words each time the user clicks "enter." Program ends when user types "quit."
Date: 5/29/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit03/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
    3. How to write strings with quotation marks -- https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-put-quotation-marks-in-a-string-windows-forms

Creativity: Rather than just increase the number of words my randomizer hides each time it's called, I set up code that will only hide words that have not been hidden yet. This was done by having a separate list that kept all the words that were not hidden. Each time they get chosen randomly, they are removed from the list. Once the list has less than 3 words, it will just hide all of them.
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // create new instances
        JWReference reference = new JWReference("Proverbs", 3, 5, 6);
        JWScripture scripture = new JWScripture(reference, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        string jwUserChoice = "";
        Console.WriteLine(scripture.WordListToString());
        jwUserChoice = GetUserInput("Enter to make the memorization harder, or type \"quit\": ");
        while (jwUserChoice.ToLower() != "quit" && scripture.DetermineContinuation() == true)
        {
            //continues until user types quit or the program no longer has any visible words
            Console.Clear();
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
        // simply prints out whatever the user wants to display and returns the user response.
        Console.Write(jwMessage);
        string jwUserResponse = Console.ReadLine();
        return jwUserResponse;
    }
}