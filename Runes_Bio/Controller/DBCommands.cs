namespace Runes_Bio.Controller
{
	public class DBCommands
	{
		Dbconnection.Connection db = new Dbconnection.Connection();
		internal bool EmailChecker(string input, byte num)
		{
			List<string> admin = new List<string>();
			List<string> employee = new List<string>();
			admin = db.DBConnection("SELECT COUNT(adminID) FROM Administrator");
			employee = db.DBConnection("SELECT COUNT(employeeID) FROM employee");
			int numEmployee = int.Parse(employee[0]);
			int numAdmin = int.Parse(admin[0]);
			List<string> passList = new List<string>();
			string item;
			string dbCmd = "SELECT emailID FROM Customer WHERE employeeID = ";
			switch (num)
			{
				case 0:
					dbCmd = "SELECT codeWord FROM Administrator WHERE adminID = ";
					break;
				case 1:
					dbCmd = "SELECT email FROM Administrator WHERE adminID = ";
					break;
				case 2:
					dbCmd = "SELECT codeWord FROM Employee WHERE employeeID = ";
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
					pass = db.DBConnection($"SELECT codeWord FROM Administrator WHERE email = '{email}'");
				}
				if (num == 1)
				{
					pass = db.DBConnection($"SELECT codeWord FROM Employee WHERE email = '{email}'");
				}
				return pass[0];
			}
			catch (Exception)
			{
				return null;
			}
		}
}
}
