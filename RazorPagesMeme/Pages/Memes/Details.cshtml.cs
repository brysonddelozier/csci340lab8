using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMeme.Data;
using RazorPagesMeme.Models;

namespace RazorPagesMeme.Pages.Memes
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMeme.Data.RazorPagesMemeContext _context;

        public DetailsModel(RazorPagesMeme.Data.RazorPagesMemeContext context)
        {
            _context = context;
        }

        public Meme Meme { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meme = await _context.Meme.FirstOrDefaultAsync(m => m.Id == id);

            if (meme is not null)
            {
                Meme = meme;

                return Page();
            }

            return NotFound();
        }
    }
}
