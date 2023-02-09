using SD115Demos.Models;

namespace SD115Demos.Data
{
    public static class Context
    {
        private static int _idCount = 0;
        public static int GetIdCount()
        {
            _idCount++;
            return _idCount;
        }


        private static void _seedMethod()
        {
            
        }
        static Context()
        {

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
