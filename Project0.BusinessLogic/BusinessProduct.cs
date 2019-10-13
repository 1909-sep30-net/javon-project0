namespace Project0.BusinessLogic
{
    public class BusinessProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"[Product {Id}] [Name] {Name} [Price] ${Price}";
        }
    }
}
