using SD115Demos.Data;

namespace SD115Demos.Models
{
    public class Rating
    {
        private readonly int _id;
        public int Id { get { return _id; } }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                if(value > 0 && value < 11)
                {
                    _value = value;
                }
                else
                {
                    throw new Exception("Rating must be on a 1 to 10 scale.");
                }
            }
        }

        // Many-To-Many between Users and Movies broken by Roles
        public User User { get; set; }
        public Movie Movie { get; set; }

        public Rating()
        {
            _id = Context.GetIdCount();
        }
    }
}
