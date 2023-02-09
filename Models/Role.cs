using SD115Demos.Data;

namespace SD115Demos.Models
{
    // break the relationship between Movies and Actors
    // store information about a role in a movie for an actor
    public class Role
    {
        private readonly int _id;
        public int Id { get { return _id; } }


        private string _credit;
        public string Credit 
        {
            get { return _credit; }
            set
            {
                if(value.Length > 0)
                {
                    _credit = value;
                }
                else
                {
                    throw new Exception("Credit must have a value");
                }
            }
        }


        private int _pay;
        public int Pay { get { return _pay; }
        set
            {
                if(value >= 0)
                {
                    _pay = value;
                }
                else
                {
                    throw new Exception("Pay cannot be negative.");
                }
            }
        }

        // breaking many-to-many between Actors and Movies
        // one-to-many on both sides
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }

        public Role()
        {
            _id = Context.GetIdCount();
        }
    }
}
