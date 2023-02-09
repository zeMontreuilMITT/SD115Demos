using Microsoft.AspNetCore.Mvc;
using SD115Demos.Data;
using SD115Demos.Models;
using System.Linq;

namespace SD115Demos.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View(Context.Movies);
        }

        public IActionResult InGenre(string genre)
        {
            // does my Enum of Genres contain the genre argument?
            // to fix: searching for genres in enum should be case insensitive
            // get all genres in the enum
            List<string> genres = Enum.GetNames(typeof(Genre)).ToList();

            if(genres.Contains(genre, StringComparer.OrdinalIgnoreCase)) 
            {
                HashSet<Movie> moviesInGenre = Context.Movies.Where(m =>
                {
                    return m.Genre.ToString().Equals(genre, StringComparison.OrdinalIgnoreCase);
                }).ToHashSet();

                return View("Index", moviesInGenre);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Info(int id)
        {
            try
            {
                Movie movie = Context.Movies.First(m =>
                {
                    return m.Id == id;
                });

                return View("Details", movie);
            } catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}
