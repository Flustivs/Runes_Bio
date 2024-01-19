namespace Runes_Bio.Controller
{
	public class TicketController
	{
		private readonly Dbconnection.Connection _connection;
		
		public void SaveSeats(string[] seats, string email)
		{
			List<string> seatsList = new List<string>();
			string seatcommand = "INSERT INTO Seats VALUE (";
			foreach (string seat in seats)
			{
				seatcommand += seat;
			}
			seatcommand += ")";
			_connection.DBConnection(seatcommand);
		}
	}
}
