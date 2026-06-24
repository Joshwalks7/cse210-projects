// https://gemini.google.com/share/620d364b4dcd
using System;

public abstract class JWGoal
{
    protected string _jwName;
    protected string _jwDescription;
    protected int _jwPointValue;

    public JWGoal(string jwName, string jwDescription, int jwPointValue)
    {
        _jwName = jwName;
        _jwDescription = jwDescription;
        _jwPointValue = jwPointValue;
    }

    public abstract int RecordEvent();
    public abstract string StringForFile();
    public abstract void DeconstructFromFile(string jwFileLine);
    public abstract string DisplayGoal();
    public string DisplayName()
    {
        return _jwName;
    }
}