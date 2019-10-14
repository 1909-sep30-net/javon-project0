using Project0.BusinessLogic;
using Xunit;

namespace Project0.Tests
{
    public class BusinessOrderTest
    {
        [Theory]
        [InlineData(9)]
        [InlineData(81)]
        [InlineData(10672615)]
        public void TestBusinessOrderSettersAndGetters(int id)
        {
            BusinessOrder order = new BusinessOrder();
            order.Id = id;

            Assert.Equal(id, order.Id);
        }
    }
}
