using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Runes_Bio.Pages
{
    public class Pick_TrashModel : PageModel
    {
        public void OnGet()
        {
			string admin = HttpContext.Session.GetString("Admin");
			string employee = HttpContext.Session.GetString("Employee");
			if (!string.IsNullOrEmpty(admin))
			{
				HttpContext.Session.SetString("Logged", admin + ".ad");
			}
			if (!string.IsNullOrEmpty(employee))
			{
				HttpContext.Session.SetString("Logged", employee + ".em");
			}
			if (string.IsNullOrEmpty(admin) && string.IsNullOrEmpty(employee))
			{
				HttpContext.Response.Redirect("/Index");
			}
		}
    }
}
