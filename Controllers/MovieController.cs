using Microsoft.AspNetCore.Mvc;
using SD115Demos.Data;
using SD115Demos.Models;
using System.Linq;

namespace SD115Demos.Controllers
{
    public class MovieController : Controller
    {
        public decimal GetOverallRating(Movie movie)
        {
            HashSet<Rating> ratings = movie.GetRatings();

            if (ratings.Any())
            {
                // https://stackoverflow.com/a/5724542
                return decimal.Round(ratings.Average(r => (decimal)r.Value), 2);
            } else
            {
                return 0;
            }
        }

        public IActionResult Index()
        {
            ViewBag.PageTitle = "All Movies";
            return View(Context.Movies);
        }

        public IActionResult InBudget(int lower, int upper)
        {
            ViewBag.PageTitle = $"Movies in Budget between ${lower} million and ${upper} million";

            if(lower < 0 || upper < 0 || upper < lower)
            {
                ViewBag.Message = "Cannot have a negative budget, or an upper budget lower than a lower budget.";
                return View("Index");
            }
            else
            {
                HashSet<Movie> movies = Context.Movies.Where(m =>
                {
                    return m.BudgetInMillions >= lower && m.BudgetInMillions <= upper;
                }).ToHashSet();
                ViewBag.MovieCount = movies.Count;
                return View("Index",movies);
            }
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

                ViewBag.MovieCount = moviesInGenre.Count;
                ViewBag.PageTitle = $"Movies in {genre}";
                return View("Index", moviesInGenre);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult FromNineties()
        {
            ViewBag.PageTitle = "Movies from the Nineties";

            HashSet<Movie> ninetiesMovies = Context.Movies.Where(m =>
            {
                return m.ReleaseDate.Year >= 1990 && m.ReleaseDate.Year < 2000;
            }).ToHashSet();

            ViewBag.MovieCount = ninetiesMovies.Count;
            return View("Index", ninetiesMovies);
        }

        public IActionResult Info(int id)
        {
            try
            {
                Movie movie = Context.Movies.First(m =>
                {
                    return m.Id == id;
                });

                ViewBag.AverageRating = GetOverallRating(movie);

                return View("Details", movie);
            } catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}
