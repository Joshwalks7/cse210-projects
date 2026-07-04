using System;

public abstract class JWLegoItem
{
    protected string _jwName;
    protected float _jwEstimatedValue;
    protected string _jwTheme;
    protected int _jwQuantity;
    public JWLegoItem(string jwName, float jwEstimatedValue, string jwTheme, int jwQuantity)
    {
        _jwName = jwName;
        _jwEstimatedValue = jwEstimatedValue;
        _jwTheme = jwTheme;
        _jwQuantity = jwQuantity;
    }
    public abstract string DisplayItem();
    public float DisplayEstimatedValue()
    {
        return _jwEstimatedValue;
    }
    public string DisplayTheme()
    {
        return _jwTheme;
    }
}