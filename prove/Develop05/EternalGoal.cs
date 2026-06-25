using System;

public class JWEternalGoal : JWGoal
{
    public JWEternalGoal(string jwName = "Unknown", string jwDescription = "Unknown", int jwPointValue = 0) : base(jwName, jwDescription, jwPointValue)
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
        string[] jwParts = jwFileLine.Split("|");
        _jwName = jwParts[0];
        _jwDescription = jwParts[1];
        _jwPointValue = int.Parse(jwParts[2]);
    }
    public override string DisplayGoal()
    {
        return $"[ ] {_jwName} ({_jwDescription})";
    }
}