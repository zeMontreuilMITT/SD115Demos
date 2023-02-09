using SD115Demos.Data;

namespace SD115Demos.Models
{
    public class User
    {
        private readonly int _id;
        public int Id { get { return _id; } }

        private string _userName;
        public string UserName { 
            get { return _userName; }
            set
            {
                if(value.Length > 2 && value.Length <= 30)
                {
                    _userName = value;
                }
                else
                {
                    throw new Exception("Username must be three or more characters long and cannot exceed 30 characters.");
                }
            }
        }

        // Many-to-Many relationship with Movies broken by Ratings
        private HashSet<Rating> _ratings = new HashSet<Rating>();
        public HashSet<Rating> GetRatings()
        {
            return _ratings.ToHashSet();
        }
        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
        }


        public User() 
        {
            _id = Context.GetIdCount();
        }

        public User(string userName)
        {
            _id = Context.GetIdCount();
            UserName = userName;
        }
    }
}
