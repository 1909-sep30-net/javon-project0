﻿namespace Project0.Data
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Location(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}