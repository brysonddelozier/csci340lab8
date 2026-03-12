using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMeme.Data;
using RazorPagesMeme.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMeme.Pages.Memes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMeme.Data.RazorPagesMemeContext _context;

        public IndexModel(RazorPagesMeme.Data.RazorPagesMemeContext context)
        {
            _context = context;
        }

        public IList<Meme> Meme { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Origins { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MemeOrigin { get; set; }

        public async Task OnGetAsync()
        {
            // <snippet_search_linqQuery>
            IQueryable<string> originQuery = from m in _context.Meme
                                            orderby m.Origin
                                            select m.Origin;
            // </snippet_search_linqQuery>

            var memes = from m in _context.Meme
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                memes = memes.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MemeOrigin))
            {
                memes = memes.Where(x => x.Origin == MemeOrigin);
            }

            // <snippet_search_selectList>
            Origins = new SelectList(await originQuery.Distinct().ToListAsync());
            // </snippet_search_selectList>
            Meme = await memes.ToListAsync();
        }
    }
}
