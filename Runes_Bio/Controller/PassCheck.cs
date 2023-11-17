namespace Runes_Bio.Controller
{
	public class PassCheck
	{
		Dbconnection.Connection db = new Dbconnection.Connection();

		internal bool PassChecker(string pass, byte num)
		{
			List<string> admin = new List<string>();
			List<string> employee = new List<string>();
			admin = db.DBConnection("SELECT COUNT(adminID) FROM Administrator");
			employee = db.DBConnection("SELECT COUNT(employeeID) FROM employee");
			int numEmployee = int.Parse(employee[0]);
			int numAdmin = int.Parse(admin[0]);
			byte savedID = 0;
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
			if (savedID == 0)
			{
				for (int i = 0; i < numAdmin; i++)
				{
					passList = db.DBConnection(dbCmd + $"{i}");
					if (passList.Count > 0)
					{
						item = passList[0];

						if (item == pass)
						{
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
				if (item == pass)
				{
					return true;
				}
			}
			return false;
		}
	}
}
