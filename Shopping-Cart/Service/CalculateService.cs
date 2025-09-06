namespace Dealeron_ass.Service
{
    public interface IDiscountService
    {
        decimal CalculateFinalAmount(CustomerType customerType, decimal purchaseAmount);
    }

    public class DiscountService : IDiscountService
    {
        public decimal CalculateFinalAmount(CustomerType customerType, decimal purchaseAmount)
        {
            var slabs = GetDiscountSlabs(customerType);
            decimal discount = 0;

            foreach (var slab in slabs)
            {
                if (purchaseAmount > slab.Min)
                {
                    decimal applicableAmount = Math.Min(purchaseAmount, slab.Max) - slab.Min;
                    discount += applicableAmount * slab.DiscountRate;
                }
            }

            return purchaseAmount - discount;
        }


        private List<DiscountSlab> GetDiscountSlabs(CustomerType type)
        {
            if (type == CustomerType.Regular)
            {
                return new List<DiscountSlab>
            {
                new DiscountSlab(0, 5000, 0),
                new DiscountSlab(5000, 10000, 0.10m),
                new DiscountSlab(10000, decimal.MaxValue, 0.20m)
            };
            }
            else // Premium
            {
                return new List<DiscountSlab>
            {
                new DiscountSlab(0, 4000, 0.10m),
                new DiscountSlab(4000, 8000, 0.15m),
                new DiscountSlab(8000, 12000, 0.20m),
                new DiscountSlab(12000, decimal.MaxValue, 0.30m)
            };
            }
        }

        private record DiscountSlab(decimal Min, decimal Max, decimal DiscountRate);
    }
}
