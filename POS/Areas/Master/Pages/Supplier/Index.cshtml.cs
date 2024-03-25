using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using POS.Data;

namespace POS.Areas.Master.Pages.Supplier
{
    public class IndexModel(POSDbContext context) : PageModel
    {
        private readonly POSDbContext _Context = context;

        public void OnGet()
        {
            
        }
    }
}
