using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Runes_Bio.Pages
{
    public class AdminPanelModel : PageModel
    {
        public string normalPrice = "46";
        public string luxuryPrice = "98";
        private readonly Controller.DBCommands _cmd = new Controller.DBCommands();
        public void OnGet()
        {
            string logged = HttpContext.Session.GetString("Admin");
            if (string.IsNullOrEmpty(logged))
            {
                HttpContext.Response.Redirect("/Index");
            }
            string[] personID = logged.Split('.');
            if (personID[1] != "ad")
            {
                HttpContext.Response.Redirect("/Index");
            }
        }
        public List<string> GetMovie()
        {
            List<string> movie = new List<string>();
            movie = _cmd.GetMovie();
            return movie;
        }
        public void OnPostTicketPrice(float? Inputfield1, float? Inputfield2)
        {
            Console.WriteLine($"Received input: {Inputfield1}, {Inputfield2}");
        }
        public void OnPostAddMovie(string movieName, int movie_Length, DateTime date, int theater)
        {
            _cmd.Savemovie(movieName, date, movie_Length, theater);
        }


    }
}
