using System;

public class JWSellingInventory : JWInventory
{
    private float _jwRevenue;
    private List<JWTransaction> _jwTransactions = new List<JWTransaction>();
    public JWSellingInventory(string jwName) : base(jwName)
    {
    }
    public float DisplayRevenue()
    {
        return _jwRevenue;
    }
    public void SetRevenue(float jwRevenue)
    {
        _jwRevenue = jwRevenue;
    }
    public void DeconstructTransaction(string jwLine)
    {
        string[] jwTransactionSplit = jwLine.Split("{}");
        // split normal transaction details/parameters
        string[] jwTransactionDetailsSplit = jwTransactionSplit[0].Split("|");
        string jwBuyername = jwTransactionDetailsSplit[0];
        string jwEmail = jwTransactionDetailsSplit[1];
        string jwAddress = jwTransactionDetailsSplit[2];
        string jwTransactionDate = jwTransactionDetailsSplit[3];
        float jwSellingPrice = float.Parse(jwTransactionDetailsSplit[4]);

        // split/create parts for sets sold list
        List<JWLegoItem> jwSetsSold = new List<JWLegoItem>();
        string[] jwSetsSplit = jwTransactionSplit[1].Split("^");
        foreach(string jwLineItem in jwSetsSplit)
        {
            string[] jwItemSplit = jwLineItem.Split("[]");
            if (jwItemSplit[0] == "Minifigure")
            {
                string[] jwClassSplit = jwItemSplit[1].Split("|");
                JWMinifigure jwMinifigure = new JWMinifigure(jwClassSplit[0], float.Parse(jwClassSplit[1]), jwClassSplit[2], int.Parse(jwClassSplit[3]), int.Parse(jwClassSplit[4]), jwClassSplit[5]);
                jwSetsSold.Add(jwMinifigure);
            }
            else if (jwItemSplit[0] == "FullSet")
            {
                string[] jwClassSplit = jwItemSplit[1].Split("|");
                JWFullSet jwFullSet = new JWFullSet(jwClassSplit[0], float.Parse(jwClassSplit[1]), jwClassSplit[2], int.Parse(jwClassSplit[3]), jwClassSplit[4], int.Parse(jwClassSplit[5]));
                jwSetsSold.Add(jwFullSet);
            }
            else if (jwItemSplit[0] == "IncompleteSet")
            {
                string[] jwClassSplit = jwItemSplit[1].Split("|");
                JWIncompleteSet jwIncompleteSet = new JWIncompleteSet(jwClassSplit[0], float.Parse(jwClassSplit[1]), jwClassSplit[2], int.Parse(jwClassSplit[3]), jwClassSplit[4], int.Parse(jwClassSplit[5]), jwClassSplit[6], jwClassSplit[7]);
                jwSetsSold.Add(jwIncompleteSet);
            }
        }
        JWTransaction jwTransaction = new JWTransaction(jwBuyername, jwSellingPrice, jwAddress, jwEmail, jwSetsSold, jwTransactionDate);
        _jwTransactions.Add(jwTransaction);
    }
    public override string StringForFile()
    {
        string jwReturnLine = "";
        foreach (JWLegoItem jwItem in _jwInventoryList)
        {
            jwReturnLine += $"\nSelling#{jwItem.StringForFile()}";
        }
        return jwReturnLine;
    }
    public string StringTransaction()
    {
        string jwReturnTransaction = "";
        foreach (JWTransaction jwTransaction in _jwTransactions)
        {
            jwReturnTransaction += jwTransaction.StringForFile();
        }
        return jwReturnTransaction;
    }
    public void ListTransactionSummaries()
    {
        int jwListNum = 1;
        foreach(JWTransaction jWTransaction in _jwTransactions)
        {
            Console.WriteLine($"  {jwListNum}. {jWTransaction.ReturnSummary()}");
            jwListNum++;
        }
    }
    public void ViewTransactionDetails(int jwIndex)
    {
        _jwTransactions[jwIndex].DisplayTransaction();
    }
    public void RecordTransaction(JWTransaction jwTransaction)
    {
        _jwRevenue += jwTransaction.ReturnSellingPrice();
        _jwTransactions.Add(jwTransaction);
    }
}