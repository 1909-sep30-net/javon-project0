using System.Collections.Generic;

namespace Project0.Logic
{
    public class Location
    {
        private int id;
        private string address;
        private string city;
        private int zipcode;
        private USState state;
        private Dictionary<Product, int> inventory = new Dictionary<Product, int>();
        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }
        public string Address
        {
            get => address;
            set
            {
                address = value;
            }
        }
        public string City
        {
            get => city;
            set
            {
                city = value;
            }
        }
        public int Zipcode
        {
            get => zipcode;
            set
            {
                zipcode = value;
            }
        }
        public USState State
        {
            get => state;
            set
            {
                state = value;
            }
        }
        public void AddProduct(Product product, int stock)
        {
            inventory.Add(product, stock);
        }

        public override string ToString()
        {
            return $"[{Id}] {Address}, {City}, {State}, {Zipcode}";
        }
    }
}
