using System;

public class JWEternalGoal : JWGoal
{
    public JWEternalGoal(string jwName, string jwDescription, int jwPointValue) : base(jwName, jwDescription, jwPointValue)
    {
    }
    public override int RecordEvent()
    {
        Console.WriteLine($"Congrats! You have earned {_jwPointValue} points!");
        return _jwPointValue;
    }
    public override string StringForFile()
    {
        return $"EternalGoal:{_jwName}|{_jwDescription}|{_jwPointValue}";
    }
    public override void DeconstructFromFile(string jwFileLine)
    {
        //
    }
    public override string DisplayGoal()
    {
        return $"[ ] {_jwName} ({_jwDescription})";
    }
}