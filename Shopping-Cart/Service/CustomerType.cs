namespace Dealeron_ass.Service
{
    public enum CustomerType
    {
        Regular,
        Premium
    }

    public class BillRequest
    {
        public CustomerType CustomerType { get; set; }
        public decimal PurchaseAmount { get; set; }
    }

    public class BillResponse
    {
        public decimal FinalAmount { get; set; }
    }
}
