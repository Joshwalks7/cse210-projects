using System;

public class JWMinifigure : JWLegoItem
{
    private int _jwYear;
    private string _jwAccessory;
    public JWMinifigure(string jwName, float jwEstimatedValue, string jwTheme, int jwQuantity, int jwYear, string jwAccessory = "nothing") : base(jwName, jwEstimatedValue, jwTheme, jwQuantity)
    {
        _jwYear = jwYear;
        _jwAccessory = jwAccessory;
    }
    public override string DisplayItem()
    {
        return $"{_jwName} ({_jwTheme} -- {_jwYear})";
    }
}