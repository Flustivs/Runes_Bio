using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Common;

namespace Runes_Bio.Pages
{
	public class ToDoModel : PageModel
	{
		private readonly Controller.DBCommands _cmd = new Controller.DBCommands();
		[BindProperty]
		public string Won { get; set; }
		public string Task { get; set; }

		public string trashInput { get; set; }
		public string moneyInput { get; set; }
		public string popcornInput { get; set; }
		public string dateInput { get; set; }

		public void OnGet()
		{
			Won = Request.Query["won"];
			Task = Request.Query["task"];

			AvailableTask();

			string admin = HttpContext.Session.GetString("Admin");
			string employee = HttpContext.Session.GetString("Employee");
			if (!string.IsNullOrEmpty(admin))
			{
				HttpContext.Session.SetString("Logged", admin + ".ad");
				if (Won != null)
				{
					HttpContext.Response.Redirect("/ToDo");
					Assigment(admin, 0);
				}
			}
			if (!string.IsNullOrEmpty(employee))
			{
				HttpContext.Session.SetString("Logged", employee + ".em");
				if (Won != null)
				{
					HttpContext.Response.Redirect("/ToDo");
					Assigment(employee, 1);
				}
			}
			if (string.IsNullOrEmpty(admin) && string.IsNullOrEmpty(employee))
			{
				HttpContext.Response.Redirect("/Index");
			}
		}
		public int GetAmount(int num)
		{
			int amount = 0;
			amount = _cmd.GetAmount(num);
			return amount;
		}
		private void AvailableTask()
		{
			List<string> timeStamp = _cmd.GetDate();
			if (timeStamp.Count == 3)
			{
				string trashDate = timeStamp[0];
				string moneyDate = timeStamp[1];
				string popcornDate = timeStamp[2];
				trashInput = trashDate;
				moneyInput = moneyDate;
				popcornInput = popcornDate;
				DateTime dateNow = DateTime.Now;
				dateInput = dateNow.Subtract(TimeSpan.FromHours(2)).ToString();
			}
		}
		private void Assigment(string person, int ad_em)
		{
			if (Won == "won")
			{
				_cmd.UpdateAssignment(person, ad_em, Task);
			}
			if (Won == "lost")
			{

			}
		}
		public void OnPost()
		{

		}
	}
}
