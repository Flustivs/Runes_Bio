using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Runes_Bio.Controller;
using Runes_Bio.Dbconnection;

namespace Runes_Bio.Pages
{
    public class LoginModel : PageModel
    {
		DBCommands dbCMD = new DBCommands();
		HashController hash = new HashController();
        [BindProperty]
        public string emailID { get; set; }
		[BindProperty]
		public string passID { get; set; }

		[ValidateAntiForgeryToken]
		public IActionResult OnPost()
		{
			string pass;
			string hashedPass;
			bool verified;
			bool adminEmail = dbCMD.EmailChecker(emailID, 1);
			bool empEmail = dbCMD.EmailChecker(emailID, 3);
			if (adminEmail)
			{
				pass = dbCMD.GetPass(0, emailID);
				verified = hash.Verify(passID, pass);
				if (verified)
				{
					return RedirectToPage("/EmployeeIndex");
				}
			}
			if (empEmail)
			{
				pass = dbCMD.GetPass(1, emailID);
				verified = hash.Verify(passID, pass);
				if (verified)
				{
					return RedirectToPage("/EmployeeIndex");
				}
			}

			return RedirectToPage("/Login");
		}

	}
}
