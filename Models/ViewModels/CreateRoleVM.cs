using Microsoft.AspNetCore.Mvc.Rendering;

namespace SD115Demos.Models.ViewModels
{
    public class CreateRoleVM
    {
        public List<SelectListItem> Actors { get; } = new List<SelectListItem>();
        public List<SelectListItem> Movies { get; } = new List<SelectListItem>();
        public string ActorId { get; set; }
        public string MovieId { get; set; }
        public string Credit { get; set; }
        public int Pay { get; set; }

        public CreateRoleVM(HashSet<Movie> movies, HashSet<Actor> actors) {
            foreach (Actor a in actors)
            {
                Actors.Add(new SelectListItem(a.Name, a.Id.ToString()));
            }

            foreach (Movie m in movies)
            {
                Movies.Add(new SelectListItem(m.Title, m.Id.ToString()));
            }
        }

        public CreateRoleVM()
        {

        }
    }
}
