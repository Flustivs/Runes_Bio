using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Runes_Bio.Controller
{
	public class DBCommands
	{
		Dbconnection.Connection admindb = new Dbconnection.Connection();
		Dbconnection.Connection empdb = new Dbconnection.Connection();
		Dbconnection.Connection db = new Dbconnection.Connection();

		ISession session;
		internal bool EmailChecker(string input, byte num)
		{
			List<string> admin = new List<string>();
			List<string> employee = new List<string>();
			admin = admindb.DBConnection("SELECT COUNT(adminID) FROM Administrator");
			employee = empdb.DBConnection("SELECT COUNT(employeeID) FROM employee");
			int numEmployee = int.Parse(employee[0]);
			int numAdmin = int.Parse(admin[0]);
			List<string> passList = new List<string>();
			string item;
			string dbCmd = "SELECT email FROM Customer WHERE employeeID = ";
			switch (num)
			{
				case 0:
					dbCmd = "SELECT password FROM Administrator WHERE adminID = ";
					break;
				case 1:
					dbCmd = "SELECT email FROM Administrator WHERE adminID = ";
					break;
				case 2:
					dbCmd = "SELECT password FROM Employee WHERE employeeID = ";
					break;
				case 3:
					dbCmd = "SELECT email FROM Employee WHERE employeeID = ";
					break;
			}
			numAdmin += numEmployee;
			for (int i = 0; i <= numAdmin; i++)
			{
				passList = db.DBConnection(dbCmd + $"{i}");
				if (passList.Count > 0)
				{
					item = passList[0];

					if (item == input)
					{
						return true;
					}
					else
					{
						passList.Clear();
					}
				}
			}
			return false;
		}
		internal string GetPass(byte num, string email)
		{
			List<string> pass = new List<string>();
			try
			{
				if (num == 0)
				{
					pass = db.DBConnection($"SELECT password FROM Administrator WHERE email = '{email}'");
				}
				if (num == 1)
				{
					pass = db.DBConnection($"SELECT password FROM Employee WHERE email = '{email}'");
				}
				return pass[0];
			}
			catch (Exception)
			{
				return null;
			}
		}
		internal void Savemovie(string movie, DateTime date, int movie_Length, int theater)
		{
			string formattedDate = date.ToString("yyyy-MM-dd HH:mm:00");
			string execMovie = $"EXEC InsertMovie @movieName = '{movie}', @playingTime = '{formattedDate}', @movieLength = {movie_Length}, @theater = {theater}";
			db.DBConnection(execMovie);
		}
		internal List<string> GetMovie()
		{
			List<string> movie = new List<string>();
			movie = db.DBConnection("SELECT movieName FROM Movie");
			return movie;
		}
		internal void SaveTicketPrice(int normalPrice, int luxuryPrice)
		{
			DateTime date = DateTime.Now;
			string adminName = session.GetString("Admin");
		}
		internal string LoggedName(string email)
		{
			List<string> adName = new List<string>();
			List<string> emName = new List<string>();
			try
			{
				adName = db.DBConnection($"SELECT fName FROM Administrator WHERE email = '{email}'");
				if (!string.IsNullOrEmpty(adName[0]))
				{
					return adName[0];
				}
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
				return "";
			}
			try
			{
				emName = db.DBConnection($"SELECT fName FROM Employee WHERE email = '{email}'");
				if (!string.IsNullOrEmpty(emName[0]))
				{
					return emName[0];
				}
				return "";
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
				return "";
			}
		}
	}
}
