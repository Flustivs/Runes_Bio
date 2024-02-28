using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Runes_Bio.Pages
{
    public class AdminPanelModel : PageModel
    {
        public string normalPrice;
        public string luxuryPrice;
        private readonly Controller.DBCommands _cmd = new Controller.DBCommands();
        public void OnGet()
        {
            string logged = HttpContext.Session.GetString("Admin");
            if (string.IsNullOrEmpty(logged))
            {
                HttpContext.Response.Redirect("/Index");
            }
        }
        public List<string> GetEmployee()
        {
            List<string> employees = new List<string>();
            employees = _cmd.GetEmployee();
            if (employees != null)
            {
                return employees;
            }
            return employees;
        }
        public void OnPostRemoveEmployee(string[] selectedEmployee)
        {
            _cmd.RemoveEmployee(selectedEmployee);
        }
        public List<string> GetMovie()
        {
            normalPrice = _cmd.GetNormalPrice().ToString();
            luxuryPrice = _cmd.GetLuxuryPrice().ToString();

            List<string> movie = new List<string>();
            movie = _cmd.GetMovie();
            return movie;
        }
        public IActionResult OnPostTicketPrice(float Inputfield1, float Inputfield2)
        {
            if (!(Inputfield1 < 70) && !(Inputfield1 > 200))
            {
                _cmd.NormalPriceChanger(Inputfield1, HttpContext.Session.GetString("Admin"));
            }
            if (!(Inputfield2 < 98) && !(Inputfield2 > 250))
            {
                _cmd.LuxuryPriceChanger(Inputfield2, HttpContext.Session.GetString("Admin"));
            }
            return RedirectToPage("/AdminPanel");
        }
        public void OnPostAddMovie(string movieName, int movie_Length, DateTime date, int theater)
        {
            string? adminID = HttpContext.Session.GetString("Admin");
            _cmd.Savemovie(movieName, date, movie_Length, theater, adminID);
        }
        public void OnPostDeleteMovie(string[] selectedMovie)
        {
            _cmd.DeleteMovie(selectedMovie);
        }

    }
}
