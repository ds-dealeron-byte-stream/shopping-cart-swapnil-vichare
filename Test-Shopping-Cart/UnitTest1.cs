using Xunit;
using Dealeron_ass.Service;

namespace Test_Shopping_Cart
{
    public class DiscountServiceTests
    {
        private readonly DiscountService _service;

        public DiscountServiceTests()
        {
            _service = new DiscountService();
        }

        [Theory]
        [InlineData(CustomerType.Regular, 4000, 4000)]  // No discount
        [InlineData(CustomerType.Regular, 7000, 6800)]  // 10% on 2000
        [InlineData(CustomerType.Regular, 12000, 11100)] // 10% on 5000, 20% on 2000

        [InlineData(CustomerType.Premium, 4000, 3600)]  // 10% on 3600
        [InlineData(CustomerType.Premium, 8000, 7000)]  // 10% on 4000, 15% on 2000
        [InlineData(CustomerType.Premium, 12000, 10200)] // 10% on 4000, 15% on 4000, 20% on 2000
        [InlineData(CustomerType.Premium, 20000, 15800)] // 10% on 4000, 15% on 4000, 20% on 4000, 30% on 3000
        public void CalculateFinalAmount_ShouldReturnExpected(CustomerType type, decimal purchaseAmount, decimal expectedFinalAmount)
        {
            // Act
            var result = _service.CalculateFinalAmount(type, purchaseAmount);

            // Assert
            //Assert.Equal(expectedFinalAmount, result);
            Assert.Equal(expectedFinalAmount, Math.Round(result, 2));

        }
        [Fact]
        public void CalculateFinalAmount_WithZeroAmount_ShouldReturnZero()
        {
            var result = _service.CalculateFinalAmount(CustomerType.Regular, 0);
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateFinalAmount_WithNegativeAmount_ShouldReturnSame()
        {
            var result = _service.CalculateFinalAmount(CustomerType.Premium, -1000);
            Assert.Equal(-1000, result); // Or throw exception if you prefer
        }

    }

}