//https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.indexof?view=net-10.0
using System;

public class JWInventory
{
    protected string _jwName;
    protected List<JWLegoItem> _jwInventoryList = new List<JWLegoItem>();
    public JWInventory(string jwName)
    {
        _jwName = jwName;
    }
    public void DisplayCollection()
    {
        int jwListNum = 1;
        foreach(JWLegoItem jwItem in _jwInventoryList)
        {
            Console.WriteLine($"{jwListNum}. {jwItem.DisplayItem()}");
            jwListNum++;
        }
    }
    public void AddItem(JWLegoItem jwLegoItem)
    {
        _jwInventoryList.Add(jwLegoItem);
    }
    public void RemoveItem(int jwItemIndex, int jwRemoveQuantity)
    {
        _jwInventoryList[jwItemIndex].DecreaseQuantity(jwRemoveQuantity);
        if (_jwInventoryList[jwItemIndex].CheckQuantity())
        {
            _jwInventoryList.RemoveAt(jwItemIndex);
        }
    }
    public JWLegoItem ReturnItemFromInventory(int jwItemIndex)
    {
        return _jwInventoryList[jwItemIndex];
    }
    public JWLegoItem RemoveFromInventory(int jwItemIndex)
    {
        JWLegoItem jwItemToMove = _jwInventoryList[jwItemIndex];
        _jwInventoryList.RemoveAt(jwItemIndex);
        return jwItemToMove;
    }
    public float EstimateTotal()
    {
        float jwTotal = 0;
        foreach(JWLegoItem jwItem in _jwInventoryList)
        {
            jwTotal += jwItem.DisplayEstimatedValue();
        }
        return jwTotal;
    }
    public string DisplayMostExpensive()
    {
        int jwExpensiveIndex = 0;
        float jwMostExpensivePrice = 0;
        foreach(JWLegoItem jwItem in _jwInventoryList)
        {
            if (jwItem.DisplayEstimatedValue() > jwMostExpensivePrice)
            {
                jwMostExpensivePrice = jwItem.DisplayEstimatedValue();
                jwExpensiveIndex = _jwInventoryList.IndexOf(jwItem);
            }
        }
        return _jwInventoryList[jwExpensiveIndex].DisplayItem();
    }
    public void DisplayTheme(string jwTheme)
    {
        foreach(JWLegoItem jwItem in _jwInventoryList)
        {
            if (jwItem.DisplayTheme().ToLower() == jwTheme.ToLower())
            {
                Console.WriteLine(jwItem.DisplayItem());
            }
        }
    }
    public virtual void DeconstructFromFile(string jwLine)
    {
        string[] jwItemSplit = jwLine.Split("[]");
        if (jwItemSplit[0] == "Minifigure")
        {
            string[] jwClassSplit = jwItemSplit[1].Split("|");
            JWMinifigure jwMinifigure = new JWMinifigure(jwClassSplit[0], float.Parse(jwClassSplit[1]), jwClassSplit[2], int.Parse(jwClassSplit[3]), int.Parse(jwClassSplit[4]), jwClassSplit[5]);
            _jwInventoryList.Add(jwMinifigure);
        }
    }
    public virtual string StringForFile()
    {
        string jwReturnLine = "";
        foreach (JWLegoItem jwItem in _jwInventoryList)
        {
            jwReturnLine += $"\nPersonal#{jwItem.StringForFile()}";
        }
        return jwReturnLine;
    }
}