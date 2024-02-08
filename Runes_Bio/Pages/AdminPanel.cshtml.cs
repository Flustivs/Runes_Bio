using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Runes_Bio.Pages
{
    public class AdminPanelModel : PageModel
    {
        public string normalPrice = "46";
        public string luxuryPrice = "98";
        public void OnGet()
        {
            string logged = HttpContext.Session.GetString("Logged");
            if (logged != "Admin")
            {
                HttpContext.Response.Redirect("/Index");
            }
        }
        public void OnPost(float? Inputfield1, float? Inputfield2)
        {
            Console.WriteLine($"Received input: {Inputfield1}, {Inputfield2}");
        }


    }
}
