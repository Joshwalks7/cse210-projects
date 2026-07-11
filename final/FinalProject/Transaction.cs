using System;

public class JWTransaction
{
    private string _jwBuyerName;
    private float _jwSellingPrice;
    private string _jwAddress;
    private string _jwEmail;
    private List<JWLegoItem> _jwSetsSold = new List<JWLegoItem>();
    private string _jwTransactionDate;
    public JWTransaction(string jwBuyerName, float jwSellingPrice, string jwAddress, string jwEmail, List<JWLegoItem> jwSetsSold, string jwTransactionDate)
    {
        _jwBuyerName = jwBuyerName;
        _jwSellingPrice = jwSellingPrice;
        _jwAddress = jwAddress;
        _jwEmail = jwEmail;
        _jwSetsSold = jwSetsSold;
        _jwTransactionDate = jwTransactionDate;
    }
    public string ReturnSummary()
    {
        return $"Transaction Date: {_jwTransactionDate} -- ${_jwSellingPrice}";
    }
    public void DisplayTransaction()
    {
        Console.WriteLine($"Buyer: {_jwBuyerName}\nContact Email:{_jwEmail}\nAddress: {_jwAddress}\nDate: {_jwTransactionDate}\nSelling Price: ${_jwSellingPrice}");
        foreach(JWLegoItem jwItem in _jwSetsSold)
        {
            Console.WriteLine(jwItem.DisplayItem());
        }
    }
    public float ReturnSellingPrice()
    {
        return _jwSellingPrice;
    }
    public string StringForFile()
    {
        string jwReturnTransaction = $"\nTransaction#{_jwBuyerName}|{_jwEmail}|{_jwAddress}|{_jwTransactionDate}|{_jwSellingPrice}";
        jwReturnTransaction += "{}";
        foreach(JWLegoItem jwItem in _jwSetsSold)
        {
            if (jwItem == _jwSetsSold[^1])
            {
                jwReturnTransaction += $"{jwItem.StringForFile()}";
            }
            else
            {
                jwReturnTransaction += $"{jwItem.StringForFile()}^";
            }
        }
        return jwReturnTransaction;
    }
}