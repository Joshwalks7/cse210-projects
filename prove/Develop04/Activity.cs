using System;
//https://www.w3schools.com/cs/cs_strings_chars.php
public class JWActivity
{
    private string _jwName;
    private string _jwDescription;
    protected int _jwRemainingTime;
    protected int _jwDuration;

    public JWActivity(string jwName, string jwDescription)
    {
       _jwName = jwName;
       _jwDescription = jwDescription;
    }
    public string JWBegin()
    {
        string rvalue = $"Welcome to the {_jwName} Activity.\n\nThis activity will help you {_jwDescription}.\n\nHow long, in seconds, would you like for your session? ";
        return rvalue;
    }
    public void JWSetDuration(string jwDurationString)
    {
        int jwDurationTime = int.Parse(jwDurationString);
        _jwDuration = jwDurationTime;
    }
    public void JWGetReady()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        JWDisplayAnimation();
    }
    public void JWFinishProgram()
    {
        Console.WriteLine("Well done!!");
        JWDisplayAnimation();
        Console.WriteLine($"\nYou have completed another {_jwDuration} seconds of the {_jwName} Activity.");
    }
    public void JWDisplayAnimation()
    {
        for (int i = 0; i < 4; i++)
        {
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
    public void JWCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        Console.Write("\b");
    }
}