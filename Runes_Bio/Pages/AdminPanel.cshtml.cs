using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Runes_Bio.Pages
{
    public class AdminPanelModel : PageModel
    {
        public void OnGet()
        {
            string logged = HttpContext.Session.GetString("Logged");
            if (logged != "Admin")
            {
                HttpContext.Response.Redirect("/Index");
            }
        }

    }
}
