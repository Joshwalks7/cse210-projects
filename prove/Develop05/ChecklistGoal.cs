using System;

public class JWChecklistGoal : JWGoal
{
    private int _jwRepsGoal;
    private int _jwRepsCount = 0;
    private int _jwBonusPoints;
    public JWChecklistGoal(string jwName = "Unkown", string jwDescription = "Unknown", int jwPointValue = 0, int jwRepsGoal = 0, int jwBonusPoints = 0) : base(jwName, jwDescription, jwPointValue)
    {
        _jwRepsGoal = jwRepsGoal;
        _jwBonusPoints = jwBonusPoints;
    }
    public override int RecordEvent()
    {
        _jwRepsCount++;
        if (_jwRepsCount == _jwRepsGoal)
        {
            Console.WriteLine($"Congrats! You have earned {_jwPointValue + _jwBonusPoints} points!");
            return _jwPointValue + _jwBonusPoints;
        }
        else
        {
            Console.WriteLine($"Congrats! You have earned {_jwPointValue} points!");
            return _jwPointValue;
        }
    }
    public override string StringForFile()
    {
        return $"ChecklistGoal:{_jwName}|{_jwDescription}|{_jwPointValue}|{_jwBonusPoints}|{_jwRepsGoal}|{_jwRepsCount}";
    }
    public override void DeconstructFromFile(string jwFileLine)
    {
        string[] jwParts = jwFileLine.Split("|");
        _jwName = jwParts[0];
        _jwDescription = jwParts[1];
        _jwPointValue = int.Parse(jwParts[2]);
        _jwBonusPoints = int.Parse(jwParts[3]);
        _jwRepsGoal = int.Parse(jwParts[4]);
        _jwRepsCount = int.Parse(jwParts[5]);
    }
    public override string DisplayGoal()
    {
        if (_jwRepsCount == _jwRepsGoal)
        {
            return $"[X] {_jwName} ({_jwDescription}) -- Currently Completed: {_jwRepsCount}/{_jwRepsGoal}";
        }
        else
        {
            return $"[ ] {_jwName} ({_jwDescription}) -- Currently Completed: {_jwRepsCount}/{_jwRepsGoal}";
        }
    }
}