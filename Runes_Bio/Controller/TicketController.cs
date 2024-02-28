using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Runes_Bio.Controller
{
    public class TicketController
    {
        private readonly Dbconnection.Connection _connection = new Dbconnection.Connection();

        public void SaveTicket(string seats, string name, string email, string movieName, string ticketPrice)
        {
            DateTime timestamp = DateTime.Now;

            string formattedDate = timestamp.ToString("yyyy-MM-dd HH:mm:00");

            string[] seatArray = seats.Split(' ');

            string userExits = _connection.DBConnection($"SELECT email FROM Customer WHERE email = '{email}'").Count.ToString();

            if (userExits == "0")
            {
                string saveUser = $"INSERT INTO Customer(fName, email) VALUES ('{name}', '{email}')";
                _connection.DBConnection(saveUser);
            }

            // EXEC SaveTicket @timestamp, @email, @seat, @movieName, @ticketPrice
            foreach (string seat in seatArray)
            {
                if (!string.IsNullOrEmpty(seat))
                {
                    string procedurecmd = $"EXEC SaveTicket @timestamp = '{formattedDate}', @email = '{email}', @seat = '{seat}', @movieName = '{movieName}', @ticketPrice = {ticketPrice}";
                    _connection.DBConnection(procedurecmd);
                }

            }
        }
    }
}
