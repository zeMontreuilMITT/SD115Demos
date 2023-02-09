using SD115Demos.Data;

namespace SD115Demos.Models
{
    public class Movie
    {
        private readonly int _id;
        public int Id { get { return _id; } }


        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value.Length > 0)
                {
                    _title = value;
                }
                else
                {
                    throw new Exception("Title must be at least one character.");
                }
            }
        }

        public DateTime ReleaseDate { get; set; }


        private int _budget;
        public int Budget
        {
            get { return _budget; }
            set
            {
                if (value >= 0) { _budget = value; }
                else
                {
                    throw new Exception("Budget cannot be less than 0");
                }
            }
        }


        public Genre Genre { get; set; }

        // RATINGS -- Many-to-many with users
        private HashSet<Rating> _ratings = new HashSet<Rating>();
        public HashSet<Rating> GetRatings()
        {
            return _ratings.ToHashSet();
        }
        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
        }
        

        public Movie()
        {
            _id = Context.GetIdCount();
        }
    }
}
