using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Runes_Bio.Controller;
using Runes_Bio.Dbconnection;

namespace Runes_Bio.Pages
{
    public class LoginModel : PageModel
    {
		PassCheck checker = new PassCheck();
        [BindProperty]
        public string emailID { get; set; }
		[BindProperty]
		public string passID { get; set; }

		[ValidateAntiForgeryToken]
		public IActionResult OnPost()
		{
			bool pass = checker.PassChecker(passID, 0);
			bool email = checker.PassChecker(emailID, 1);
			if (pass && email)
			{
				return RedirectToPage("/Index");
			}

			return RedirectToPage("/Movie");
		}

	}
}
