namespace AggregateLoops;
public class PurchaseOrder : EntityBase
{
    public string Name {  get; private set; } = string.Empty;
    public decimal MaxAmount { get; private set; }
    public string Status { get; private set; } = string.Empty;
    private List<PurchaseOrderItem> _items = new();
    public IReadOnlyCollection<PurchaseOrderItem> Items => _items.AsReadOnly();

    public void UpdateMaxAmount(decimal maxAmount) => MaxAmount = maxAmount;
    public void AddItem(PurchaseOrderItem item)
    {
        if(_items.Sum(x => x.Amount) + item.Amount > MaxAmount)
        {
            throw new PurchaseOrderMaxAmountExceededException();
        }
        _items.Add(item);
    }

    internal void CheckAmount(decimal difference)
    {
        if (_items.Sum(x => x.Amount) + difference > MaxAmount)
        {
            throw new PurchaseOrderMaxAmountExceededException();
        }
    }
}
