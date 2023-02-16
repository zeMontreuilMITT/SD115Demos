namespace SD115Demos.Models.ViewModel
{
    public class AffordableViewModel
    {
        public int Budget { get; set; }
        public HashSet<Laptop>? Laptops { get; set; }

        public AffordableViewModel()
        {

        }
        public AffordableViewModel(HashSet<Laptop>? laptops, int budget = 0)
        {
            Budget = budget;
            Laptops = laptops;
        }
    }
}
