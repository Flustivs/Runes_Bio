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
        internal void Savemovie(string movie, DateTime date, int movie_Length, int theater, string? adminEmail)
        {
            string formattedDate = date.ToString("yyyy-MM-dd HH:mm:00");
            if (adminEmail != null)
            {
                string execMovie = $"EXEC InsertMovie @movieName = '{movie}', @playingTime = '{formattedDate}', @movieLength = {movie_Length}, @theater = {theater}, @adminEmail = '{adminEmail}'";
                db.DBConnection(execMovie);
            }

        }
        internal void DeleteMovie(string[] movies)
        {
            foreach (string movie in movies)
            {
                db.DBConnection($"DELETE mt FROM MovieTheater mt INNER JOIN Movie m ON mt.movieID = m.movieID WHERE m.movieName = '{movie}'");
                db.DBConnection($"DELETE FROM Movie WHERE movieName = '{movie}'");
            }
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
        internal string LoggedID(string email)
        {
            List<string> adID = new List<string>();
            List<string> emID = new List<string>();
            try
            {
                adID = db.DBConnection($"SELECT adminID FROM Administrator WHERE email = '{email}'");
                if (!string.IsNullOrEmpty(adID[0]))
                {
                    return adID[0];
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
            try
            {
                emID = db.DBConnection($"SELECT employeeID FROM Employee WHERE email = '{email}'");
                if (!string.IsNullOrEmpty(emID[0]))
                {
                    return emID[0];
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
