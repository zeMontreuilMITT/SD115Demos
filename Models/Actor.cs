using SD115Demos.Data;

namespace SD115Demos.Models
{
    public class Actor
    {
        private readonly int _id;
        public int Id { get { return _id; } }


        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Name cannot be empty.");
                }
            }
        }

        public Actor()
        {
            _id = Context.GetIdCount();
        }

    }
}
