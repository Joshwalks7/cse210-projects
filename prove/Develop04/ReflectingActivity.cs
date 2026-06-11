/*
Author: Joshua Walker
Description: Class gives the user a reflective prompt, and then prompts them with random follow up questions until the duration has run out.
Date: 6/12/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit04/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWReflectingActivity : JWActivity
{
   private List<string> _jwPrompts;
   private List<string> _jwQuestions;

   public JWReflectingActivity(string jwName, string jwDescription) : base(jwName, jwDescription)
    {
        // passes parameters to the base class and adds prompts/questions to the lists
        _jwPrompts = ["Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."];
        _jwQuestions = ["Why was this experience meaningful to you? ", "Have you ever done anything like this before? ", "How did you get started? ", "How did you feel when it was complete? ", "What made this time different than other times when you were not as successful? ", "What is your favorite thing about this experience? ", "What could you learn from this experience that applies to other situations? ", "What did you learn about yourself through this experience? ", "How can you keep this experience in mind in the future? "];
    }
    public void JWDisplayPrompt()
    {
        // choose a random prompt to display and waits for the user to click enter
        Random jwRandomizer = new Random();
        int jwRandPrompt = jwRandomizer.Next(_jwPrompts.Count);
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"     ---{_jwPrompts[jwRandPrompt]}---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }
    public void JWDisplayQuestions()
    {
        // While the duration isn't exceeded, the program chooses random questions to display to the user 
        Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        JWCountDown(5);
        Console.Clear();
        DateTime jwStartTime = DateTime.Now;
        DateTime jwFutureTime = jwStartTime.AddSeconds(_jwDuration);
        DateTime jwCurrentTime = DateTime.Now;
        while (jwCurrentTime < jwFutureTime)
        {
            Random jwRandomizer = new Random();
            int jwRandQuestion = jwRandomizer.Next(_jwQuestions.Count);
            Console.Write(_jwQuestions[jwRandQuestion]);
            // questions are displayed for 8 seconds
            if (_jwDuration < 8)
            {
                JWDisplayAnimation(_jwDuration);
            }
            else
            {
                JWDisplayAnimation(8);
            }
            Console.WriteLine();
            jwCurrentTime = DateTime.Now;
        }
    }
    public void JWDisplayMiddle()
    {
        // combine both methods to make it easy to call in main
        JWDisplayPrompt();
        JWDisplayQuestions();
    }
}