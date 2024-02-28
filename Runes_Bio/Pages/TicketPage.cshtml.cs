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
        private readonly Dbconnection.Connection _connection = new Dbconnection.Connection();
        public int left = 15;
        public int top = 28;
        public string[] _aPosition =
        {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g"
        };
        public byte _numPosition;
        public int luxuryTic;
        public int normalTic;
        public string movie;
        private List<string> reservedSeat = new List<string>();
        public void OnGet()
        {
            movie = HttpContext.Session.GetString("selectedMovie");
            if (string.IsNullOrEmpty(movie))
            {
                HttpContext.Response.Redirect("/Index");
            }

        }
        public string UsedSeat()
        {
            List<string> movieID = new List<string>();
            movieID = _connection.DBConnection($"SELECT movieID FROM Movie WHERE movieName = '{movie}'");
            if (movieID.Count > 0)
            {
                reservedSeat = _connection.DBConnection($"SELECT seat FROM Ticket WHERE movieID = {movieID[0]}");
                string seats = "";
                foreach (string seat in reservedSeat)
                {
                    seats += ' ' + seat;
                }
                return seats;
            }
            return "";
        }
        /// <summary>
        /// ticketPriceID = 1 thats normal ticket
        /// ticketPriceID = 2 thats luxury ticket
        /// </summary>
        /// <param name="seats"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="ticketPrice"></param>
        public void OnPost(string seats, string name, string email, string ticketPrice)
        {
            luxuryTic = int.Parse(_connection.DBConnection("SELECT ticketPrice FROM TicketPrice WHERE ticketPriceID = 2")[0]);
            normalTic = int.Parse(_connection.DBConnection("SELECT ticketPrice FROM TicketPrice WHERE ticketPriceID = 1")[0]);
            string movie = HttpContext.Session.GetString("selectedMovie");
            int price = 0;
            if (ticketPrice == "one")
            {
                price = luxuryTic;
            }
            else
            {
                price = normalTic;
            }
            if (seats != null)
            {
                string[] splitSeat = seats.Split(' ');
                bool savedTicket = false;
                foreach (string seat in splitSeat)
                {
                    _ticket.SaveTicket(seats, name, email, movie, price.ToString());
                    savedTicket = true;
                }
                if (savedTicket)
                {
                    HttpContext.Session.SetString("selectedMovie", "");
                    HttpContext.Response.Redirect("/Index");
                }
            }
            HttpContext.Session.SetString("selectedMovie", "");
        }
    }
}