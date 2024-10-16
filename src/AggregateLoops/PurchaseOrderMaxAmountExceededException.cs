namespace AggregateLoops;

public class PurchaseOrderMaxAmountExceededException : Exception
{
    public PurchaseOrderMaxAmountExceededException() : base("PO Max Amount Exceeded.")
    {
    }
}
