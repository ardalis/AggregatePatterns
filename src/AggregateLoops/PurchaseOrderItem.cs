namespace AggregateLoops;

/// <summary>
/// How to enforce maximum on parent?
/// 1. Move all amount mutation to parent
/// 2. Pass parent into UpdateAmount (double dispatch)
/// 3. Public Parent property
/// 4. Private Parent property** shown here**
/// 5. Domain Event (w/expectation of exception - passive aggressive)
/// </summary>
public class PurchaseOrderItem(decimal amount) : EntityBase
{
    public decimal Amount { get; private set; } = amount;
    public int PurchaseOrderId { get; private set; }
    private PurchaseOrder Parent { get; set; } = null!;

    public void UpdateAmount(decimal newAmount)
    {
        if (newAmount == Amount) return;

        decimal difference = newAmount - Amount;
        Parent.CheckAmount(difference);
    }
}
