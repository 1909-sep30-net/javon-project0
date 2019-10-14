using Project0.BusinessLogic;
using Xunit;

namespace Project0.Tests
{
    public class BusinessProductTest
    {
        [Theory]
        [InlineData(8, "Winter Chai", 32.16, 8, "Winter Chai", 32.16)]
        [InlineData(4, "Humblestone", 6.32, 4, "Humblestone", 6.32)]
        [InlineData(10032, "Herbal Kliff", 9.99, 10032, "Herbal Kliff", 9.99)]
        public void TestBusinessProductSettersAndGetters(int id, string name, decimal price, int expectedId, string expectedName, decimal expectedPrice)
        {
            BusinessProduct product = new BusinessProduct();
            product.Id = id;
            product.Name = name;
            product.Price = price;

            Assert.Equal(expectedId, product.Id);
            Assert.Equal(expectedName, product.Name);
            Assert.Equal(expectedPrice, product.Price);
        }
    }
}
