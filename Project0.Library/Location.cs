using System;

namespace Project0.Logic
{
    public class Location
    {
        private int id;
        private string address;
        private string city;
        private int zipcode;
        private USState state;
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
    }
}
