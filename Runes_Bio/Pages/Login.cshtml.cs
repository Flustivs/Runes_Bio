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
			bool adEmail = checker.PassChecker(emailID, 1);
			bool empEmail = checker.PassChecker(emailID, 3);
			bool adPass = false;
			bool empPass = false;
			if (adEmail)
			{
				adPass = checker.PassChecker(passID, 0);
			}
			else if (empEmail)
			{
				empPass = checker.PassChecker(passID, 2);
			}
			if (adPass && adEmail || empEmail && empPass)
			{
				return RedirectToPage("/Index");
			}

			return RedirectToPage("/Movie");
		}

	}
}
