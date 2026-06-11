using System;

public class JWReflectingActivity : JWActivity
{
   private List<string> _jwPrompts;
   private List<string> _jwQuestions;

   public JWReflectingActivity(string jwName, string jwDescription) : base(jwName, jwDescription)
    {
        _jwPrompts = ["Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."];
        _jwQuestions = ["Why was this experience meaningful to you? ", "Have you ever done anything like this before? ", "How did you get started? ", "How did you feel when it was complete? ", "What made this time different than other times when you were not as successful? ", "What is your favorite thing about this experience? ", "What could you learn from this experience that applies to other situations? ", "What did you learn about yourself through this experience? ", "How can you keep this experience in mind in the future? "];
    }
    public void JWDisplayPrompt()
    {
        Random jwRandomizer = new Random();
        int jwRandPrompt = jwRandomizer.Next(_jwPrompts.Count);
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"     ---{_jwPrompts[jwRandPrompt]}---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
    }
    public void JWDisplayQuestions()
    {
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
            JWDisplayAnimation(8);
            Console.WriteLine();
            jwCurrentTime = DateTime.Now;
        }
    }
    public void JWDisplayMiddle()
    {
        JWDisplayPrompt();
        JWDisplayQuestions();
    }

}