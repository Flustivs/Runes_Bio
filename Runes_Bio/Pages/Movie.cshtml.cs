using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Common;

namespace Runes_Bio.Pages
{
    public class MovieModel : PageModel
    {
        Dbconnection.Connection dbConnection = new Dbconnection.Connection();
        public void OnGet() { }
        public List<List<string>> item()
        {
            List<string> items = new List<string>();

            List<List<string>> moviePair = new List<List<string>>();
            items = dbConnection.DBConnection("SELECT movieName FROM Movie");
            for (int i = 0; i < items.Count; i += 2)
            {
                List<string> pair = new List<string>();

                pair.Add(items[i]);

                if (i + 1 < items.Count)
                {
                    pair.Add(items[i + 1]);
                }
                moviePair.Add(pair);
            }
            return moviePair;
        }
        public IActionResult OnPostMoviePick(string movieName)
        {
            HttpContext.Session.SetString("selectedMovie", movieName);
            return RedirectToPage("/TicketPage");
        }
    }
}
