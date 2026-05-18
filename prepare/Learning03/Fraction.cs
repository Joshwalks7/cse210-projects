using System;
using System.Security.Cryptography.X509Certificates;

public class Fraction
{
    private int _jwTop;
    private int _jwBottom;
    public Fraction()
    {
        _jwTop = 1;
        _jwBottom = 1;
    }
    public Fraction(int numerator)
    {
        _jwTop = numerator;
        _jwBottom = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        _jwTop = numerator;
        _jwBottom = denominator;
    }
    public void SetTop(int numerator)
    {
        _jwTop = numerator;
    }
    public int GetTop()
    {
        return _jwTop;
    }
    public void SetBottom(int denominator)
    {
        _jwBottom = denominator;
    }
    public int GetBottom()
    {
        return _jwBottom;
    }
    public string GetFractionString()
    {
        return $"{_jwTop}/{_jwBottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_jwTop / (double)_jwBottom;
    }
}