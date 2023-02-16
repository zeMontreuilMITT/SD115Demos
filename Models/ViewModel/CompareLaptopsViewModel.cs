using Microsoft.AspNetCore.Mvc.Rendering;

namespace SD115Demos.Models.ViewModel
{
    public class CompareLaptopsViewModel
    {
        // OPTIONS
        // dropdowns
        public HashSet<SelectListItem> LaptopItems { get; set; } = new HashSet<SelectListItem>();

        // FIELD VALUES
        // Laptop Ids
        public int? FirstLaptopId { get; set; }
        public int? SecondLaptopId { get; set; }

        // DISPLAY VALUES
        // Laptop Objects
        public Laptop? FirstLaptop { get; set; }
        public Laptop? SecondLaptop { get; set; }

        public void PopulateLaptopItems(IEnumerable<Laptop> laptops)
        {
            foreach(Laptop l in laptops)
            {
                LaptopItems.Add(new SelectListItem($"{l.Brand.Name} {l.Model}", l.Id.ToString()));
            }
        }

        public CompareLaptopsViewModel(IEnumerable<Laptop> laptops)
        {
            PopulateLaptopItems(laptops);
        }

        public CompareLaptopsViewModel()
        {

        }
        

    }
}
