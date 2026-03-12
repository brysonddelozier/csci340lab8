using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMeme.Data;
using RazorPagesMeme.Models;

namespace RazorPagesMeme.Pages.Memes
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMeme.Data.RazorPagesMemeContext _context;

        public EditModel(RazorPagesMeme.Data.RazorPagesMemeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meme Meme { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meme =  await _context.Meme.FirstOrDefaultAsync(m => m.Id == id);
            if (meme == null)
            {
                return NotFound();
            }
            Meme = meme;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Meme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemeExists(Meme.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MemeExists(int id)
        {
            return _context.Meme.Any(e => e.Id == id);
        }
    }
}
