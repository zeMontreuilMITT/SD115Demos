using SD115Demos.Models;

namespace SD115Demos.Data
{
    public static class Database
    {
        public static HashSet<Laptop> Laptops = new HashSet<Laptop>();
        public static HashSet<Brand> Brands = new HashSet<Brand>();
        private static int _idIncrement = 1;

        private static void _seed()
        {
            // SEED BRANDS
            Brand toshiba = new Brand(_idIncrement++, "Toshiba");
            Brand lenovo = new Brand(_idIncrement++, "Lenovo");
            Brand dell = new Brand(_idIncrement++, "Dell");

            Brands.Add(toshiba);
            Brands.Add(lenovo);
            Brands.Add(dell);

            // SEED LAPTOPS
            // TOSHIBA
            Laptop libretto = new Laptop(_idIncrement++, "Libretto", toshiba, 1200, 2023, 10, LaptopType.New);
            Laptop portege = new Laptop(_idIncrement++, "Portege", toshiba, 900, 2020, 20, LaptopType.Refurbished);

            Laptops.Add(libretto);
            Laptops.Add(portege);

            toshiba.AddLaptop(libretto);
            toshiba.AddLaptop(portege);

            // LENOVO
            Laptop thinkpad = new Laptop(_idIncrement++, "ThinkPad", lenovo, 2000, 2023, 5, LaptopType.New);
            Laptop thinkbook = new Laptop(_idIncrement++, "ThinkBook", lenovo, 1500, 2019, 7, LaptopType.Rental);

            Laptops.Add(thinkpad);
            Laptops.Add(thinkbook);

            lenovo.AddLaptop(thinkpad);
            lenovo.AddLaptop(thinkbook);

            // DELL
            Laptop xps = new Laptop(_idIncrement++, "XPS", dell, 1900, 2022, 10, LaptopType.New);

            Laptops.Add(xps);

            dell.AddLaptop(xps);
        }

        static Database()
        {
            _seed();
        }
    }
}
