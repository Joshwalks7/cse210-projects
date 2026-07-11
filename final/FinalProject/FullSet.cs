using System;
using System.Globalization;

public class JWFullSet : JWLegoItem
{
    private string _jwCondition;
    private int _jwSetNumber;
    public JWFullSet(string jwName, float jwEstimatedValue, string jwTheme, int jwQuantity, string jwCondition, int jwSetNumber) : base(jwName, jwEstimatedValue, jwTheme, jwQuantity)
    {
        _jwCondition = jwCondition;
        _jwSetNumber = jwSetNumber;
    }
    public override string DisplayItem()
    {
        return $"{_jwName} Set: {_jwSetNumber} Condition: {_jwCondition} Theme:{_jwTheme} (~${_jwEstimatedValue} -- Qty: {_jwQuantity})";
    }
    public override string StringForFile()
    {
        return $"FullSet[]{_jwName}|{_jwEstimatedValue}|{_jwTheme}|{_jwQuantity}|{_jwCondition}|{_jwSetNumber}";
    }
}