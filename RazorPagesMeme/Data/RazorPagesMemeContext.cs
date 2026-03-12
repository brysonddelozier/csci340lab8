using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMeme.Models;

namespace RazorPagesMeme.Data
{
    public class RazorPagesMemeContext : DbContext
    {
        public RazorPagesMemeContext (DbContextOptions<RazorPagesMemeContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMeme.Models.Meme> Meme { get; set; } = default!;
    }
}
