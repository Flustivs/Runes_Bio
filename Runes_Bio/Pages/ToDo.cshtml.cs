using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Runes_Bio.Pages
{
    public class ToDoModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Console.WriteLine("Hello");
            return RedirectToPage("/EmployeeIndex");
        }
    }
}
