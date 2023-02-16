using SD115Demos.Models;

namespace SD115Demos.Data
{
    public static class Database
    {
        public static HashSet<Laptop> Laptops = new HashSet<Laptop>();
        public static HashSet<Brand> Brands = new HashSet<Brand>();

        private static void _seed()
        {
            // SEED BRANDS
            Brand toshiba = new Brand("Toshiba");
            Brand lenovo = new Brand("Lenovo");
            Brand dell = new Brand("Dell");

            Brands.Add(toshiba);
            Brands.Add(lenovo);
            Brands.Add(dell);

            // SEED LAPTOPS
            // TOSHIBA
            Laptop libretto = new Laptop("Libretto", toshiba, 1200, 2023, 10, LaptopType.New);
            Laptop portege = new Laptop("Portege", toshiba, 900, 2020, 20, LaptopType.Refurbished);

            Laptops.Add(libretto);
            Laptops.Add(portege);

            toshiba.AddLaptop(libretto);
            toshiba.AddLaptop(portege);

            // LENOVO
            Laptop thinkpad = new Laptop("ThinkPad", lenovo, 2000, 2023, 5, LaptopType.New);
            Laptop thinkbook = new Laptop("ThinkBook", lenovo, 1500, 2019, 7, LaptopType.Rental);

            Laptops.Add(thinkpad);
            Laptops.Add(thinkbook);

            lenovo.AddLaptop(thinkpad);
            lenovo.AddLaptop(thinkbook);

            // DELL
            Laptop xps = new Laptop("XPS", dell, 1900, 2022, 10, LaptopType.New);

            Laptops.Add(xps);

            dell.AddLaptop(xps);
        }

        static Database()
        {
            _seed();
        }
    }
}
