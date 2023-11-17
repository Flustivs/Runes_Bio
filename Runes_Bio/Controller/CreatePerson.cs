namespace Runes_Bio.Controller
{
	public class CreatePerson
	{
		Dbconnection.Connection db = new Dbconnection.Connection();

		internal void Create(string fName, string email, string pass)
		{
			db.DBConnection($"INSERT INTO Employee(fName, email, codeWord) VALUES ('{fName}', '{email}', '{pass}')");
		}
	}
}
