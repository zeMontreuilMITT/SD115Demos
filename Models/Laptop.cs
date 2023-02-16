namespace SD115Demos.Models
{
    public class Laptop
    {
        private string _model;
        public string Model { 
            get { return _model; } 
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Model must have a value");
                }
                else
                {
                    _model = value;
                }
            }
        }


        private Brand _brand;
        public Brand Brand { get { return _brand; } }   


        private decimal _price;
        public decimal Price { 
            get { return _price; } 
            set
            {
                if (value < 0)
                {
                    throw new Exception("Cannot have negative price");
                }
                else
                {
                    _price = value;
                }
            } 
        }


        private int _yearOfMake;
        public int YearOfMake
        {
            get { return _yearOfMake; }
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                {
                    throw new Exception("Enter a valid year");
                }
            }
        }

        public int Quantity { get; set; }

        private LaptopType _type;
        public LaptopType Type { get { return _type; } }


        public Laptop(string model, Brand brand, decimal price, int yearOfMake, int quantity, LaptopType type)
        {
            Model = model;
            _brand = brand;
            Price = price;
            YearOfMake = yearOfMake;
            Quantity = quantity;
            _type = type;
        }
    }

    public enum LaptopType
    {
        New,
        Refurbished,
        Rental
    }
}
