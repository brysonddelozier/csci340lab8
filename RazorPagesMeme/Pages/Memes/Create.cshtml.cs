using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMeme.Data;
using RazorPagesMeme.Models;

namespace RazorPagesMeme.Pages.Memes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMeme.Data.RazorPagesMemeContext _context;

        public CreateModel(RazorPagesMeme.Data.RazorPagesMemeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Meme Meme { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Meme.Add(Meme);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
