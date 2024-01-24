using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Runes_Bio.Pages
{
    public class PopCornModel : PageModel
    {
        public void OnGet()
        {
            string logged = HttpContext.Session.GetString("Logged");
            if (string.IsNullOrEmpty(logged))
            {
                HttpContext.Response.Redirect("/Index");
            }
        }
    }
}
