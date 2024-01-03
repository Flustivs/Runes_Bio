namespace Runes_Bio.Controller
{
	public class DBCommands
	{
		Dbconnection.Connection db = new Dbconnection.Connection();
<<<<<<< HEAD:Runes_Bio/Controller/DBCommands.cs
		internal bool EmailChecker(string input, byte num)
=======
		private byte savedID = 0;
		internal bool PassChecker(string pass, byte num)
>>>>>>> a87409cb00af136c6ad99589bf141b59aaf7bcaf:Runes_Bio/Controller/PassCheck.cs
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
					dbCmd = "SELECT emailID FROM Administrator WHERE adminID = ";
					break;
				case 2:
					dbCmd = "SELECT codeWord FROM Employee WHERE employeeID = ";
					break;
				case 3:
					dbCmd = "SELECT emailID FROM Employee WHERE employeeID = ";
					break;
			}
			numAdmin += numEmployee;
			for (int i = 0; i <= numAdmin; i++)
			{
<<<<<<< HEAD:Runes_Bio/Controller/DBCommands.cs
				passList = db.DBConnection(dbCmd + $"{i}");
				if (passList.Count > 0)
=======
				for (byte i = 0; i < numAdmin; i++)
>>>>>>> a87409cb00af136c6ad99589bf141b59aaf7bcaf:Runes_Bio/Controller/PassCheck.cs
				{
					item = passList[0];

<<<<<<< HEAD:Runes_Bio/Controller/DBCommands.cs
					if (item == input)
					{
						return true;
					}
					else
					{
						passList.Clear();
					}
=======
						if (item == pass)
						{
							savedID = i;
							return true;
						}
						else
						{
							passList.Clear();
						}
					}
				}
			}
			else
			{

				passList = db.DBConnection(dbCmd + $"{savedID}");
				item = passList[0];
				savedID = 0;
				if (item == pass)
				{
					return true;
>>>>>>> a87409cb00af136c6ad99589bf141b59aaf7bcaf:Runes_Bio/Controller/PassCheck.cs
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
