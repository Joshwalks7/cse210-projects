using System;

public class JWIncompleteSet : JWLegoItem
{
    private string _jwPercentComplete;
    private int _jwSetNumber;
    private List<JWMinifigure> _jwMinifigures;
    private string _jwDescription;
    public JWIncompleteSet(string jwName, float jwEstimatedValue, string jwTheme, int jwQuantity, string jwPercentComplete, int jwSetNumber, List<JWMinifigure> jwMinifigures, string jwDescription) : base(jwName, jwEstimatedValue, jwTheme, jwQuantity)
    {
        _jwPercentComplete = jwPercentComplete;
        _jwSetNumber = jwSetNumber;
        _jwMinifigures = jwMinifigures;
        _jwDescription = jwDescription;
    }
    public override string DisplayItem()
    {
        return $"{_jwName} Set: {_jwSetNumber} Theme:{_jwTheme} (~${_jwEstimatedValue} -- Qty: {_jwQuantity})";
    }
}