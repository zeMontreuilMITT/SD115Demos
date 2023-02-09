using SD115Demos.Models;

namespace SD115Demos.Data
{
    public static class Context
    {
        // === STORAGE
        public static HashSet<Movie> Movies = new HashSet<Movie>();
        public static HashSet<Actor> Actors = new HashSet<Actor>();
        public static HashSet<Rating> Ratings = new HashSet<Rating>();
        public static HashSet<Role> Roles = new HashSet<Role>();
        public static HashSet<User> Users = new HashSet<User>();


        // === METHODS
        private static int _idCount = 0;
        public static int GetIdCount()
        {
            _idCount++;
            return _idCount;
        }
        private static void _seedMethod()
        {
            Movie movie1 = new Movie("Die Hard", new DateTime(1988,1,1), 100, Genre.Action);
            Movie movie2 = new Movie("Blade Runner", new DateTime(1972, 1, 1), 70, Genre.Action);
            Movie movie3 = new Movie("Scream", new DateTime(1999, 1, 1), 200, Genre.Horror);
            Movie movie4 = new Movie("Back to the Future", new DateTime(1985, 7, 13), 19, Genre.Comedy);

            Movies.Add(movie1);
            Movies.Add(movie2);
            Movies.Add(movie3);
            Movies.Add(movie4);
        }


        // === CONSTRUCTOR
        static Context()
        {
            _seedMethod();
        }
    }



    public enum Genre
    {
        Action,
        Horror,
        Comedy,
        Drama,
        Documentary,
        Romance
    }
}
