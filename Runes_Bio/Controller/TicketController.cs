using System.Runtime.Serialization;

namespace Runes_Bio.Controller
{
	public class TicketController
	{
		private readonly Dbconnection.Connection _connection;
		
		public void SaveTicket(string seats, string name, string email, string movieName, string ticketPrice)
		{
			DateTime timestamp = DateTime.Now;
			string[] seatArray = seats.Split(' ');

			string saveUser = $"INSERT INTO Customer VALUES ({name}, {email})";
			_connection.DBConnection(saveUser);

            // EXEC SaveTicket @timestamp, @email, @seat, @movieName, @ticketPrice
            foreach (string seat in seatArray)
			{
                string procedurecmd = $"EXEC SaveTicket @timestamp = {timestamp}, @email = {email}, @seat = {seat}, @movieName = {movieName}, @ticketPrice = {ticketPrice}";
				_connection.DBConnection(procedurecmd);
            }
        }
	}
}
