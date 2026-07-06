using System;

public class JWMinifigure : JWLegoItem
{
    private int _jwYear;
    private string _jwAccessory;
    public JWMinifigure(string jwName, float jwEstimatedValue, string jwTheme, int jwQuantity, int jwYear, string jwAccessory = "None") : base(jwName, jwEstimatedValue, jwTheme, jwQuantity)
    {
        _jwYear = jwYear;
        _jwAccessory = jwAccessory;
    }
    public override string DisplayItem()
    {
            return $"{_jwName} Accessory: {_jwAccessory} Theme:{_jwTheme} {_jwYear} (~${_jwEstimatedValue} -- Qty: {_jwQuantity})";
    }
}