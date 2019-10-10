using Project0.Logic;

namespace Project0.Data
{
    public static class OrderData
    {
        public static Order GetOrderById(int id)
        {
            foreach (Order order in MemoryStore.Orders)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }

            return null;
        }
    }
}
