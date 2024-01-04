using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Runes_Bio.Pages
{
    public class ToDoModel : PageModel
    {
		private bool submit1;
		private bool submit2;
		private bool submit3;
		private bool submit4;
		private bool submit5;
		public void OnGet()
        {
        }
		public void OnPost()
		{
			if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit1"]))
			{
				HttpContext.Session.SetString("submit1", "true");
			}

			if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit2"]))
			{
				HttpContext.Session.SetString("submit2", "true");
			}

			if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit3"]))
			{
				HttpContext.Session.SetString("submit3", "true");
			}

			if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit4"]))
			{
				HttpContext.Session.SetString("submit4", "true");
			}

			if (!string.IsNullOrEmpty(HttpContext.Request.Form["submit5"]))
			{
				HttpContext.Session.SetString("submit5", "true");
			}

			if (HttpContext.Session.GetString("submit1") == "true" &&
				HttpContext.Session.GetString("submit2") == "true" &&
				HttpContext.Session.GetString("submit3") == "true" &&
				HttpContext.Session.GetString("submit4") == "true" &&
				HttpContext.Session.GetString("submit5") == "true")
			{
				HttpContext.Session.SetString("submit1", "false");
				HttpContext.Session.SetString("submit2", "false");
				HttpContext.Session.SetString("submit3", "false");
				HttpContext.Session.SetString("submit4", "false");
				HttpContext.Session.SetString("submit5", "false");
			}
		}

		//public byte CheckTrash(string trashBag)
		//{
		//	switch (trashBag)
		//	{
		//		case "submit1":
		//			return 1;
		//		case "submit2":
		//			return 2;
		//		case "submit3":
		//			return 3;
		//		case "submit4":
		//			return 4;
		//		case "submit5":
		//			return 5;
		//	}
		//	return 0;
		//}

	}
}
