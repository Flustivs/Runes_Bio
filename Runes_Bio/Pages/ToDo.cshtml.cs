using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Runes_Bio.Pages
{
    public class ToDoModel : PageModel
    {
		public void OnGet()
        {
			string logged = HttpContext.Session.GetString("Logged");
			if (string.IsNullOrEmpty(logged))
			{
				HttpContext.Response.Redirect("/Index");
			}
		}
		public void OnPost()
		{

			//if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit1"]))
			//{
			//	HttpContext.Session.SetString("submit1", "true");
			//}

			//if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit2"]))
			//{
			//	HttpContext.Session.SetString("submit2", "true");
			//}

			//if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit3"]))
			//{
			//	HttpContext.Session.SetString("submit3", "true");
			//}

			//if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit4"]))
			//{
			//	HttpContext.Session.SetString("submit4", "true");
			//}

			//if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit5"]))
			//{
			//	HttpContext.Session.SetString("submit5", "true");
			//}

			//if (HttpContext.Session.GetString("submit1") == "true" &&
			//	HttpContext.Session.GetString("submit2") == "true" &&
			//	HttpContext.Session.GetString("submit3") == "true" &&
			//	HttpContext.Session.GetString("submit4") == "true" &&
			//	HttpContext.Session.GetString("submit5") == "true")
			//{
			//	HttpContext.Session.SetString("submit1", "false");
			//	HttpContext.Session.SetString("submit2", "false");
			//	HttpContext.Session.SetString("submit3", "false");
			//	HttpContext.Session.SetString("submit4", "false");
			//	HttpContext.Session.SetString("submit5", "false");
   //             Console.WriteLine("hello");
   //         }
		}
	}
}
