using Microsoft.AspNetCore.Mvc.Rendering;

namespace SD115Demos.Models.ViewModel
{
    public class LaptopsInBrandVM
    {
        // SELECT LIST
        public HashSet<SelectListItem> BrandItems = new HashSet<SelectListItem>();

        // Stored ID of Brand
        public string? BrandID { get; set; }    
        public Brand? Brand { get; set; }

        public void PopulateBrands(IEnumerable<Brand> brands)
        {
            foreach(Brand b in brands)
            {
                BrandItems.Add(new SelectListItem(b.Name, b.Id.ToString()));
            }
        }

        public LaptopsInBrandVM(IEnumerable<Brand> brands)
        {
            PopulateBrands(brands);
        }

        public LaptopsInBrandVM()
        {

        }
    }
}
