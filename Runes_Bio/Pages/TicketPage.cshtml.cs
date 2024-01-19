using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Runes_Bio.Controller;

namespace Runes_Bio.Pages
{
    public class TicketPageModel : PageModel
    {
        private readonly TicketController _ticket = new TicketController();
		internal int left = 500;
		internal int top = 200;
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
        public IActionResult SaveSeats(string[] seats, string email)
        {
            _ticket.SaveSeats(seats, email);
            return Page();
        }
    }
}
