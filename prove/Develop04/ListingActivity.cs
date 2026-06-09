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
}