using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Runes_Bio.Controller;

namespace Runes_Bio.Pages
{
    public class RegisterModel : PageModel
    {
        CreatePerson create = new CreatePerson();
        public void OnGet()
        {
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
                create.Create(nameID, emailID, passID);
                return RedirectToPage("/Login");
            }
            return Page();
        }

    }
}
