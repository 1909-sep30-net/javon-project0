namespace Project0.BusinessLogic
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"[Product {Id}] [Name] {Name} [Price] ${Price}";
        }
    }
}
