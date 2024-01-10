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
        }
        public string GetQuestion(byte num)
        {
            List<string> questions = new List<string>();
            string questionCMD = "SELECT question FROM Questions";
            questions = _conn.DBConnection(questionCMD);
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
    }
}
