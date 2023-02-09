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


        private int _budgetInMillions;
        public int BudgetInMillions
        {
            get { return _budgetInMillions; }
            set
            {
                if (value >= 0) { _budgetInMillions = value; }
                else
                {
                    throw new Exception("Budget cannot be less than 0");
                }
            }
        }


        public Genre Genre { get; set; }


        // RATINGS -- Many-to-many with users broken by Ratings
        private HashSet<Rating> _ratings = new HashSet<Rating>();
        public HashSet<Rating> GetRatings()
        {
            return _ratings.ToHashSet();
        }
        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
        }


        // ROLES - many-to-many with Actors broken by Roles
        private HashSet<Role> _roles = new HashSet<Role>();
        public HashSet<Role> GetRoles()
        {
            return _roles.ToHashSet();
        }
        public void AddRole(Role role)
        {
            _roles.Add(role);
        }


        public Movie()
        {
            _id = Context.GetIdCount();
        }

        public Movie(string title, DateTime releaseDate, int budget, Genre genre)
        {
            _id = Context.GetIdCount();
            Title = title;
            ReleaseDate = releaseDate;
            BudgetInMillions = budget;
            Genre = genre;
        }
    }
}
