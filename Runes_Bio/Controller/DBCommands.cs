using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Runes_Bio.Controller
{
    public class DBCommands
    {
        Dbconnection.Connection admindb = new Dbconnection.Connection();
        Dbconnection.Connection empdb = new Dbconnection.Connection();
        Dbconnection.Connection db = new Dbconnection.Connection();

        ISession session;
        /// <summary>
        /// Takes the highest id from both the employees and admins and from there finds out if the email exits in either of those,
        /// and if it does it returns true, else False
        /// </summary>
        /// <param name="input"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        internal bool EmailChecker(string input, byte num)
        {
            List<string> admin = new List<string>();
            List<string> employee = new List<string>();
            admin = admindb.DBConnection("SELECT TOP 1 adminID FROM Administrator ORDER BY adminID DESC");
            employee = empdb.DBConnection("SELECT TOP 1 employeeID FROM Employee ORDER BY employeeID DESC");
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
            numAdmin += numEmployee + 1;
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
        internal List<string> GetEmployee()
        {
            return db.DBConnection("SELECT email FROM Employee");
        }
        internal void RemoveEmployee(string[] selectedEmployee)
        {
            foreach (string employee in selectedEmployee)
            {
                db.DBConnection($"DELETE FROM Employee WHERE email = '{employee}'");
            }
        }
        internal int GetNormalPrice()
        {
            return int.Parse(db.DBConnection("SELECT ticketPrice FROM TicketPrice WHERE ticketPriceID = 1")[0]);
        }
        internal int GetLuxuryPrice()
        {
            return int.Parse(admindb.DBConnection("SELECT ticketPrice FROM TicketPrice WHERE ticketPriceID = 2")[0]);
        }
        /// <summary>
        /// Saves the price of the normal ticket
        /// </summary>
        /// <param name="price"></param>
        /// <param name="adminID"></param>
        internal void NormalPriceChanger(float price, string adminID)
        {
            DateTime dateTime = DateTime.Now;
            string time = dateTime.ToString("yyyy-MM-dd HH:mm:00");
            admindb.DBConnection($"UPDATE TicketPrice SET ticketPrice = {price}, adminID = {adminID}, changeTimeStamp = '{time}' WHERE ticketPriceID = 1");
        }
        /// <summary>
        /// Saves the price of the luxury ticket
        /// </summary>
        /// <param name="price"></param>
        /// <param name="adminID"></param>
        internal void LuxuryPriceChanger(float price, string adminID)
        {
            DateTime dateTime = DateTime.Now;
            string time = dateTime.ToString("yyyy-MM-dd HH:mm:00");
            empdb.DBConnection($"UPDATE TicketPrice SET ticketPrice = {price}, adminID = {adminID}, changeTimeStamp = '{time}' WHERE ticketPriceID = 2");
        }
        /// <summary>
        /// Gets the hashed password from the database, using their email to find it
        /// </summary>
        /// <param name="num"></param>
        /// <param name="email"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Saves a movie using the stored procedure "InsertMovie"
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="date"></param>
        /// <param name="movie_Length"></param>
        /// <param name="theater"></param>
        /// <param name="adminID"></param>
        internal void Savemovie(string movie, DateTime date, int movie_Length, int theater, string? adminID)
        {
            string formattedDate = date.ToString("yyyy-MM-dd HH:mm:00");
            if (adminID != null)
            {
                string execMovie = $"EXEC InsertMovie @movieName = '{movie}', @playingTime = '{formattedDate}', @movieLength = {movie_Length}, @theater = {theater}, @adminID = '{adminID}'";
                db.DBConnection(execMovie);
            }

        }
        /// <summary>
        /// Deletes the movies that are in the string array
        /// </summary>
        /// <param name="movies"></param>
        internal void DeleteMovie(string[] movies)
        {
            foreach (string movie in movies)
            {
                db.DBConnection($"DELETE mt FROM MovieTheater mt INNER JOIN Movie m ON mt.movieID = m.movieID WHERE m.movieName = '{movie}'");
                db.DBConnection($"DELETE FROM Movie WHERE movieName = '{movie}'");
            }
        }
        /// <summary>
        /// Gets a list of movies
        /// </summary>
        /// <returns></returns>
        internal List<string> GetMovie()
        {
            List<string> movie = new List<string>();
            movie = db.DBConnection("SELECT movieName FROM Movie");
            return movie;
        }
        //internal void SaveTicketPrice(int normalPrice, int luxuryPrice)
        //{
        //    DateTime date = DateTime.Now;
        //    string adminName = session.GetString("Admin");
        //}

        /// <summary>
        /// Checking if the person exist in the database,
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        internal string LoggedID(string email)
        {
            List<string> adID = new List<string>();
            List<string> emID = new List<string>();
            adID = admindb.DBConnection($"SELECT adminID FROM Administrator WHERE email = '{email}'");
            emID = empdb.DBConnection($"SELECT employeeID FROM Employee WHERE email = '{email}'");
            try
            {
                if (!string.IsNullOrEmpty(adID[0]))
                {
                    return adID[0];
                }
            }
            catch (ArgumentOutOfRangeException ad)
            {
            }
            try
            {
                if (!string.IsNullOrEmpty(emID[0]))
                {
                    return emID[0];
                }
            }
            catch (ArgumentOutOfRangeException em)
            {
            }
            return "";
        }
        /// <summary>
        /// Uses an UPDATE statement to change what time the task was last completed, which admin / employee last completed it,
        /// and how many times that task have been completed in total
        /// </summary>
        /// <param name="person"></param>
        /// <param name="num"></param>
        /// <param name="assignment"></param>
        internal void UpdateAssignment(string person, int num, string assignment)
        {
            DateTime time = DateTime.Now;
            string formattedTime = time.ToString("yyyy-MM-dd HH:mm:ss");
            int amount = 0;
			List<string> amountDone = db.DBConnection("SELECT amountDone FROM Assignment");
            if (amountDone != null)
            {
                switch (assignment)
                {
                    case "Trash-Pick-Up":
						amount = int.Parse(amountDone[0]);
						break;
                    case "Money-Count":
						amount = int.Parse(amountDone[1]);
						break;
                    case "Catch-PopCorn":
						amount = int.Parse(amountDone[2]);
						break;
				}
				if (num == 0)
				{
					amount++;
					switch (assignment)
					{
						case "Trash-Pick-Up":
							db.DBConnection($"UPDATE Assignment SET adminID = {person}, employeeID = null, available = '{formattedTime}', amountDone = {amount} WHERE assigmentName = '{assignment}'");
							break;
						case "Money-Count":
							db.DBConnection($"UPDATE Assignment SET adminID = {person}, employeeID = null, available = '{formattedTime}', amountDone = {amount} WHERE assigmentName = '{assignment}'");
							break;
						case "Catch-PopCorn":
							db.DBConnection($"UPDATE Assignment SET adminID = {person}, employeeID = null, available = '{formattedTime}', amountDone = {amount} WHERE assigmentName = '{assignment}'");
							break;
					}
				}
				if (num == 1)
				{
					amount++;
					switch (assignment)
					{
						case "Trash-Pick-Up":
							db.DBConnection($"UPDATE Assignment SET employeeID = {person}, adminID = null, available = '{formattedTime}', amountDone = {amount} WHERE assigmentName = '{assignment}'");
							break;
						case "Money-Count":
							db.DBConnection($"UPDATE Assignment SET employeeID = {person}, adminID = null, available = '{formattedTime}', amountDone = {amount} WHERE assigmentName = '{assignment}'");
							break;
						case "Catch-PopCorn":
							db.DBConnection($"UPDATE Assignment SET employeeID = {person}, adminID = null, available = '{formattedTime}', amountDone = {amount} WHERE assigmentName = '{assignment}'");
							break;
					}
				}
			}
        }
		/// <summary>
		/// Gets total amount of how many times a task have been completed <para />
		/// 0 = trash assignment <para />
		/// 1 = money assignment <para />
		/// 2 = popcorn assignment
		/// </summary>
		/// <param name="num"></param>
		/// <returns></returns>
		public int GetAmount(int num)
        {
            int amount = 0;
            switch (num)
            {
                case 0:
                    amount = int.Parse(db.DBConnection("SELECT amountDone FROM Assignment WHERE assignmentID = 1")[0]);
                    return amount;
                case 1:
					amount = int.Parse(admindb.DBConnection("SELECT amountDone FROM Assignment WHERE assignmentID = 2")[0]);
                    return amount;
                case 2:
					amount = int.Parse(empdb.DBConnection("SELECT amountDone FROM Assignment WHERE assignmentID = 3")[0]);
                    return amount;
                default:
                    return amount;
            }
        }

        public List<string> GetDate()
        {
            return db.DBConnection("SELECT available FROM Assignment");
        }
    }
}
