using System;

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
        string rvalue = $"Welcome to the {_jwName}.\n\nThis activity will help you {_jwDescription}.\n\nHow long, in seconds, would you like for your session? ";
        return rvalue;
    }
    public void JWSetDuration(string jwDurationString)
    {
        int jwDurationTime = int.Parse(jwDurationString);
        _jwDuration = jwDurationTime;
    }
}