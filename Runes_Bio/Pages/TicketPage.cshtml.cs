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

        public void OnPost(string seat, string name, string email, string movieName, int ticketPrice)
        {
            _ticket.SaveTicket(seat, name, email, movieName, ticketPrice.ToString());
		}
	}
}
