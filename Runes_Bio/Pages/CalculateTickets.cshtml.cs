using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Runes_Bio.Pages
{
    public interface ICalculateTicketsModel
    {
        public string GetQuestion(byte num);
    }
    public class CalculateTicketsModel : PageModel, ICalculateTicketsModel
    {
        private readonly Dbconnection.Connection _conn;
        public CalculateTicketsModel(Dbconnection.Connection conn)
        {
            _conn = conn;
        }
        public void OnGet()
        {
            string logged = HttpContext.Session.GetString("Logged");
            if (string.IsNullOrEmpty(logged))
            {
                HttpContext.Response.Redirect("/Index");
            }
        }
        public string GetQuestion(byte num)
        {
            List<string> questions = new List<string>();
            string dbCMD = "SELECT question FROM Questions";
            questions = _conn.DBConnection(dbCMD);
            switch (num)
            {
                case 1:
                    return questions[0];
                case 2:
                    return questions[1];
                case 3:
                    return questions[2];
                case 4:
                    return questions[3];
                case 5:
                    return questions[4];
            }
            return "Something went wrong";
        }
        public string GetAnswer(byte num)
        {
            List<string> answer = new List<string>();
            string dbCmd = "SELECT answers FROM Questions";
            answer = _conn.DBConnection(dbCmd);
            switch (num)
            {
                case 1:
                    return answer[1];
				case 2:
					return answer[2];
				case 3:
					return answer[3];
				case 4:
					return answer[4];
			}
            return "";
        }
    }
}
