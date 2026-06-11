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
    }
    public void JWDisplayMiddle()
    {
        _jwCompleteRotations = _jwDuration / (_jwInTime + _jwOutTime);
        if (_jwDuration % (_jwInTime + _jwOutTime) != 0)
        {
            Console.WriteLine(_jwCompleteRotations);
            int jwModNum = _jwDuration % (_jwInTime + _jwOutTime);
            Console.WriteLine(jwModNum);
            int jwUniqueInTime = jwModNum / 2;
            Console.WriteLine(jwUniqueInTime);
            int jwUniqueOutTime = jwModNum - jwUniqueInTime;
            Console.WriteLine(jwUniqueOutTime);
            Console.Write("Breathe in...");
            JWCountDown(jwUniqueInTime);
            Console.Write("Breathe out...");
            JWCountDown(jwUniqueOutTime);
        }
        for (int i = _jwCompleteRotations; i > 0; i--)
        {
            Console.Write("\nBreathe in...");
            JWCountDown(_jwInTime);
            Console.Write("Breathe out...");
            JWCountDown(_jwOutTime);
        }
    }
}