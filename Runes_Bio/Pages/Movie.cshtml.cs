using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Common;

namespace Runes_Bio.Pages
{
    public class MovieModel : PageModel
    {
		Dbconnection.Connection dbConnection = new Dbconnection.Connection();
        public void OnGet(){}
		public List<string> item()
		{
			List<string> items = new List<string>();
			items = dbConnection.DBConnection("SELECT movieName FROM Movie");
			return items;
		}
		public IActionResult OnPostMoviePick(string movieName)
		{
			HttpContext.Session.SetString("selectedMovie", movieName);
			return RedirectToPage("/TicketPage");
		}
	}
}
