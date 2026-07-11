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
    public override void DeconstructFromFile(string jwLine)
    {
        //
    }
    public void DeconstructTransaction(string jwLine)
    {
        
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