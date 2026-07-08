using System;

public class JWSellingInventory : JWInventory
{
    private float _jwRevenue;
    private List<JWTransaction> _jwTransactions;
    public JWSellingInventory(string jwName) : base(jwName)
    {
    }
    public float DisplayRevenue()
    {
        return _jwRevenue;
    }
    public override void DeconstructFromFile()
    {
        //
    }
    public override string StringForFile()
    {
        return "";
    }
    public void ListTransactionSummaries()
    {
        foreach(JWTransaction jWTransaction in _jwTransactions)
        {
            Console.WriteLine(jWTransaction.ReturnSummary());
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