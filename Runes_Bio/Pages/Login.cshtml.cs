using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Runes_Bio.Controller;
using Newtonsoft.Json;
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

		[HttpPost]
		public IActionResult OnPost()
		{
			string pass;
			bool verified;
			bool adminEmail = dbCMD.EmailChecker(emailID, 1);
			bool empEmail = dbCMD.EmailChecker(emailID, 3);
			if (adminEmail || empEmail)
			{
				int roleId = adminEmail ? 0 : 1;
				pass = dbCMD.GetPass((byte)roleId, emailID);
				verified = hash.Verify(passID, pass);
				if (verified)
				{
					var result = new { Success = true, Message = "Logged in successfully!" };
					return RedirectToPage("/EmployeeIndex");
				}
			}

			var errorResult = new { Success = false, Message = "Invalid login credentials." };
			return RedirectToPage("/Login");
		}


	}
}
