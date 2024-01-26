using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Runes_Bio.Controller;
using Runes_Bio.Model;

namespace Runes_Bio.Pages
{
	[IgnoreAntiforgeryToken]
	public class TicketPageModel : PageModel
    {
        private readonly TicketController _ticket = new TicketController();
        internal int left = 15;
        internal int top = 28;
        internal string[] _aPosition =
        {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g"
        };
        internal byte _numPosition;
        public void OnGet()
        {
        }
        [HttpPost]
        public IActionResult OnPostSaveSeats([FromBody] SeatsData data)
        {
            try
            {
                _ticket.SaveSeats(data.seats, data.email);
				var responseObject = new { status = "success" };
				return StatusCode(200, responseObject);
			}
			catch
            {
				var errorResponseObject = new { status = "error", message = "Internal server error" };
				return StatusCode(500, errorResponseObject);

			}
		}
	}
}
