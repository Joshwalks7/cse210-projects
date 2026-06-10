using System;

public class JWListingActivity : JWActivity
{
    private List<string> _jwPrompts;
    private long _jwStartTime;
    private long _jwFutureTime;
    private int _jwItemCount;

    public JWListingActivity(string jwName, string jwDescription) : base(jwName, jwDescription)
    {
        _jwPrompts = ["Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"];
        _jwItemCount = 0;
    }
    public void JWDisplayMiddle()
    {
        Random jwRandomizer = new Random();
        int jwRandPrompt = jwRandomizer.Next(_jwPrompts.Count);
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"     ---{_jwPrompts[jwRandPrompt]}---");
        Console.Write("You may begin in: ");
        JWCountDown(5);
        DateTime jwStartTime = DateTime.Now;
        DateTime jwFutureTime = jwStartTime.AddSeconds(_jwDuration);
        DateTime jwCurrentTime = DateTime.Now;
        while (jwCurrentTime < jwFutureTime)
        {
            Console.Write("\n> ");
            Console.ReadLine();
            _jwItemCount++;
            jwCurrentTime = DateTime.Now;
        }
        Console.WriteLine($"You listed {_jwItemCount} items!\n");
    }
    
}