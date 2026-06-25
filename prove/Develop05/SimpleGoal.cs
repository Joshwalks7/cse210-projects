using System;

public class JWSimpleGoal : JWGoal
{
    private bool _jwIsComplete = false;

    public JWSimpleGoal(string jwName = "Unknown", string jwDescription = "Unknown", int jwPointValue = 0) : base(jwName, jwDescription, jwPointValue)
    {
    }
    public override int RecordEvent()
    {
        _jwIsComplete = true;
        Console.WriteLine($"Congrats! You have earned {_jwPointValue} points!");
        return _jwPointValue;
    }
    public override string StringForFile()
    {
        return $"SimpleGoal:{_jwName}|{_jwDescription}|{_jwPointValue}|{_jwIsComplete}";
    }
    public override void DeconstructFromFile(string jwFileLine)
    {
        string[] jwParts = jwFileLine.Split("|");
        _jwName = jwParts[0];
        _jwDescription = jwParts[1];
        _jwPointValue = int.Parse(jwParts[2]);
        _jwIsComplete = bool.Parse(jwParts[3]);
    }
    public override string DisplayGoal()
    {
        if (_jwIsComplete)
        {
            return $"[X] {_jwName} ({_jwDescription})";
        }
        else
        {
            return $"[ ] {_jwName} ({_jwDescription})";
        }
    }
}