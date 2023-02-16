﻿namespace SD115Demos.Models
{
    public class Brand
    {
        private int _id;
        public int Id { get { return _id; } }

        private string _name;
        public string Name { get { return _name; } } 
        private void _setName(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new Exception("Brand must have a valid Name");
            } else
            {
                _name = value;
            }
        }


        private HashSet<Laptop> _laptops = new HashSet<Laptop>();
        public HashSet<Laptop> GetLaptops()
        {
            return _laptops.ToHashSet();
        }
        public void AddLaptop(Laptop laptop)
        {
            _laptops.Add(laptop);
        }

        public Brand(int id, string name)
        {
            _id = id;
            _setName(name);
        }
    }
}
