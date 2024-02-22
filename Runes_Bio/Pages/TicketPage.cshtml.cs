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
        private readonly Dbconnection.Connection _connection = new Dbconnection.Connection();
        public int luxuryTic;
        public int normalTic;
        public void OnGet()
        {
           
        }
        /// <summary>
        /// ticketPriceID = 1 thats normal ticket
        /// ticketPriceID = 2 thats luxury ticket
        /// </summary>
        /// <param name="seat"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="ticketPrice"></param>
        public void OnPost(string seat, string name, string email, string ticketPrice)
        {
            luxuryTic = int.Parse(_connection.DBConnection("SELECT ticketPrice FROM TicketPrice WHERE ticketPriceID = 2")[0]);
            normalTic = int.Parse(_connection.DBConnection("SELECT ticketPrice FROM TicketPrice WHERE ticketPriceID = 1")[0]);
            string movie = HttpContext.Session.GetString("SelectedMovie");
            int price = 0;
            if (ticketPrice == "one")
            {
                price = luxuryTic;
            }
            else
            {
                price = normalTic;
            }
            _ticket.SaveTicket(seat, name, email, movie, price.ToString());
		}
	}
}
