using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Entities;

namespace POS.Pages.AddItem
{
    public class CreateModel(POS.Data.POSDbContext context) : PageModel
    {
        private readonly POS.Data.POSDbContext _context = context;

        public async Task <IActionResult> OnGetAsync()
        {
            Item = new();
            string cha = "";

            string Code = "I" + "-";

            var Items = await _context.Items.Where(s => s.ItemId.Substring(0, 2) == Code).ToListAsync();
            if (Items.Count > 0)
            {
                string Result = Items.Max(s => s.ItemId.Substring(2, 3));
                cha = Code + $"{(int.Parse(Result) + 1):D3}";
            }
            else
            {
                cha = Code + "001";
            }

            Item.ItemId = cha;
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            try
            {
               
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "This Item Is Already Exist");
                return Page();
            }
        }
    }
}
