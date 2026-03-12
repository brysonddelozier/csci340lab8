using Microsoft.EntityFrameworkCore;
using RazorPagesMeme.Data;

namespace RazorPagesMeme.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMemeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMemeContext>>()))
        {
            if (context == null || context.Meme == null)
            {
                throw new ArgumentNullException("Null RazorPagesMemeContext");
            }

            // Look for any movies.
            if (context.Meme.Any())
            {
                return;   // DB has been seeded
            }

            context.Meme.AddRange(
                new Meme
                {
                    Name = "DaBaby",
                    Date = DateTime.Parse("2020-8-24"),
                    Origin = "Tik Tok",
                    Funniness = 6
                },

                new Meme
                {
                    Name = "67",
                    Date = DateTime.Parse("2025-3-31"),
                    Origin = "Tik Tok",
                    Funniness = 7
                },

                new Meme
                {
                    Name = "Damn Daniel",
                    Date = DateTime.Parse("2016-2-15"),
                    Origin = "Vine",
                    Funniness = 8
                },

                new Meme
                {
                    Name = "Mans Not Hot",
                    Date = DateTime.Parse("2017-5-10"),
                    Origin = "Instagram",
                    Funniness = 8
                }
            );
            context.SaveChanges();
        }
    }
}