using System;

public class JWSimpleGoal : JWGoal
{
    private bool _jwIsComplete = false;

    public JWSimpleGoal(string jwName, string jwDescription, int jwPointValue) : base(jwName, jwDescription, jwPointValue)
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
        //
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