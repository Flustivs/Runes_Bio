using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Runes_Bio.Controller;
using Newtonsoft.Json;
using Runes_Bio.Dbconnection;
using Microsoft.AspNetCore.Http;

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
		public void OnGet()
		{
			string admin = HttpContext.Session.GetString("Admin");
			string employee = HttpContext.Session.GetString("Employee");
			if (!string.IsNullOrEmpty(admin) || !string.IsNullOrEmpty(employee))
			{
				HttpContext.Session.SetString("Admin", "");
				HttpContext.Session.SetString("Employee", "");
				HttpContext.Response.Redirect("/Index");
			}
		}

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
					if (roleId == 0)
					{
						string adminID = dbCMD.LoggedID(emailID);
						if (!string.IsNullOrEmpty(adminID))
						{
							HttpContext.Session.SetString("Admin", adminID);
						}
					}
					else
					{
						string employeeID = dbCMD.LoggedID(emailID);
						if (!string.IsNullOrEmpty(employeeID))
						{
							HttpContext.Session.SetString("Employee", employeeID);
						}
					}
					return RedirectToPage("/Index");
				}
			}
			return RedirectToPage("/Login");
		}


	}
}
