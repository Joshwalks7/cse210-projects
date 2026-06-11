/*
Author: Joshua Walker
Description: Class displays a prompt and lets the user type as many possible responses until the timer runs out
Date: 6/12/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit04/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWListingActivity : JWActivity
{
    private List<string> _jwPrompts;
    private int _jwItemCount;

    public JWListingActivity(string jwName, string jwDescription) : base(jwName, jwDescription)
    {
        // passes parameters to the base class and adds questions to the list
        _jwPrompts = ["Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"];
        _jwItemCount = 0;
    }
    public void JWDisplayMiddle()
    {
        // randomly chooses a prompt to display, then chooses a random question for the user to write about
        Random jwRandomizer = new Random();
        int jwRandPrompt = jwRandomizer.Next(_jwPrompts.Count);
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"     ---{_jwPrompts[jwRandPrompt]}---");
        Console.Write("You may begin in: ");
        JWCountDown(5);
        DateTime jwStartTime = DateTime.Now;
        DateTime jwFutureTime = jwStartTime.AddSeconds(_jwDuration);
        DateTime jwCurrentTime = DateTime.Now;
        // check if the current time is later than the future time each time the user hits enter
        while (jwCurrentTime < jwFutureTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _jwItemCount++;
            jwCurrentTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {_jwItemCount} items!\n");
    }
    
}