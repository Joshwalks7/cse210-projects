using System;

public class JWBreathingActivity : JWActivity
{
    private int _jwInTime;
    private int _jwOutTime;
    private int _jwCompleteRotations;
    public JWBreathingActivity(string jwName, string jwDescription) : base(jwName, jwDescription)
    {
        _jwInTime = 3;
        _jwOutTime = 4;
        _jwCompleteRotations = _jwDuration / (_jwInTime + _jwOutTime);
        Console.WriteLine(_jwCompleteRotations);
    }
    public void JWDisplayMiddle()
    {
        if (_jwDuration % (_jwInTime + _jwOutTime) != 0)
        {
            int jwModNum = _jwDuration % (_jwInTime + _jwOutTime);
            int jwUniqueInTime = jwModNum / 2;
            int jwUniqueOutTime = jwModNum - jwUniqueInTime;
            Console.Write("Breathe in...");
            JWCountDown(jwUniqueInTime);
            Console.Write("Breathe out...");
            JWCountDown(jwUniqueOutTime);
        }
        for (int i = _jwCompleteRotations; i > 0; i--)
        {
            Console.Write("Breathe in...");
            JWCountDown(_jwInTime);
            Console.Write("Breathe out...");
            JWCountDown(_jwOutTime);
        }
    }
}