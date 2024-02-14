using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Data.SqlTypes;

namespace Runes_Bio.Pages
{
    public class AdminPanelModel : PageModel
    {
        public string normalPrice = "46";
        public string luxuryPrice = "98";
        private readonly Dbconnection.Connection _connection = new Dbconnection.Connection();
        public void OnGet()
        {
            string logged = HttpContext.Session.GetString("Logged");
            if (logged != "Admin")
            {
                HttpContext.Response.Redirect("/Index");
            }
        }
        public List<string> GetMovie()
        {
            List<string> movies = new List<string>();
            movies = _connection.DBConnection("SELECT movieName FROM Movie");
            return movies;
        }
        public void OnPostTicketPrice(float? Inputfield1, float? Inputfield2)
        {
            Console.WriteLine($"Received input: {Inputfield1}, {Inputfield2}");
        }
        public void OnPostAddMovie(string movieName, int moviePlaying, DateTime date, int theater)
        {

        }


    }
}
