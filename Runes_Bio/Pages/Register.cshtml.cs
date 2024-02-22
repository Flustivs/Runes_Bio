using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Runes_Bio.Controller;

namespace Runes_Bio.Pages
{
    public class RegisterModel : PageModel
    {
        CreatePerson create = new CreatePerson();
        HashController hash = new HashController();
        public void OnGet()
        {
			string admin = HttpContext.Session.GetString("Admin");
			if (!string.IsNullOrEmpty(admin))
			{
				HttpContext.Session.SetString("Logged", admin + ".ad");
			}
            if (string.IsNullOrEmpty(admin))
            {
                HttpContext.Response.Redirect("/Index");
            }
		}
        [BindProperty]
        public string emailID { get; set; }
		[BindProperty]
        public string nameID { get; set; }
		[BindProperty]
        public string passID { get; set; }
		[BindProperty]
        public string confPassID { get; set; }

		[ValidateAntiForgeryToken]
		public IActionResult OnPost()
        {
            if (passID == confPassID)
            {
                string hashedPass = hash.Hash(passID);
                create.Create(nameID, emailID, hashedPass);
                return Page();
            }
            return Page();
        }

    }
}
