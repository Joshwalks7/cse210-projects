/*
Author: Joshua Walker
Description: Class displays a breathing exercise to use while showing countdown. Additionally it holds how long the user will breathe in and out for.
Date: 6/12/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit04/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWBreathingActivity : JWActivity
{
    private int _jwInTime;
    private int _jwOutTime;
    private int _jwCompleteRotations;
    public JWBreathingActivity(string jwName, string jwDescription) : base(jwName, jwDescription)
    {
        // constuctor passes parameters to the base class, sets variables for breathing in and out times
        _jwInTime = 3;
        _jwOutTime = 4;
    }
    public void JWDisplayMiddle()
    {
        // dislays the breathing in and out while calling on countdown method. If condition determines if there's not an even amount of time to do only full exercises. In the case there isn't, the program creates a shorter exercise that will lean toward the exhale time being longer. Then it continues normal length breathing
        _jwCompleteRotations = _jwDuration / (_jwInTime + _jwOutTime);
        if (_jwDuration % (_jwInTime + _jwOutTime) != 0)
        {
            int jwModNum = _jwDuration % (_jwInTime + _jwOutTime);
            int jwUniqueInTime = jwModNum / 2;
            int jwUniqueOutTime = jwModNum - jwUniqueInTime;
            Console.Write("\nBreathe in...");
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