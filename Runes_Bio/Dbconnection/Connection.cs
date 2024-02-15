using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Runes_Bio.Dbconnection
{
	public class Connection
	{
		private string DBConn = "Data Source=ZBC-S-RUNE4805;Initial Catalog=New_Runes_Bio;Integrated Security=True;TrustServerCertificate=True;";
		List<string> items = new List<string>();
		public List<string> DBConnection(string command)
		{
			SqlConnection conn = new SqlConnection(DBConn);
			try
			{
				conn.Open();
				items.Clear();
				SqlCommand cmd = new SqlCommand(command, conn);
				using (SqlDataReader rdr = cmd.ExecuteReader())
				{
					while (rdr.Read())
					{
						object value = rdr.GetValue(0);
						string stringvalue = value is int intValue ? intValue.ToString() : value.ToString();
						items.Add(stringvalue);
					}
				}
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
			}
			finally
			{
				conn.Close();
			}
			return items;
		}
	}
}
