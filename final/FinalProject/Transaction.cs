/*
Author: Joshua Walker
Description: Class responsible for holding data regarding a transaction, including the contant/shipping informtation as well as each set that was sold in the transaction
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit06/project-plan.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
    3. Accessing final item in a list -- https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
*/
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
       // return a small, condensed version of a transaction for the user to see 
        return $"Transaction Date: {_jwTransactionDate} -- ${_jwSellingPrice}";
    }
    public void DisplayTransaction()
    {
        // Display the transaction details, including the specifics about each set included
        Console.WriteLine($"Buyer: {_jwBuyerName}\nContact Email:{_jwEmail}\nAddress: {_jwAddress}\nDate: {_jwTransactionDate}\nSelling Price: ${_jwSellingPrice}");
        foreach(JWLegoItem jwItem in _jwSetsSold)
        {
            Console.WriteLine(jwItem.DisplayItem());
        }
    }
    public float ReturnSellingPrice()
    {
        // return the price the transaction was sold for
        return _jwSellingPrice;
    }
    public string StringForFile()
    {
        // prepare the transaction to be stored as a string in a file
        string jwReturnTransaction = $"\nTransaction#{_jwBuyerName}|{_jwEmail}|{_jwAddress}|{_jwTransactionDate}|{_jwSellingPrice}";
        jwReturnTransaction += "{}";
        foreach(JWLegoItem jwItem in _jwSetsSold)
        {
            // if the set is the last in the list, don't add the ^ that allows the data to be split later
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