using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Seed data for testing my databse. No longer used.

namespace MovieCollection.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MoviesDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MoviesDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(

                    new Movie
                    {
                        Category = "Category",
                        Title = "Title",
                        Year = 0000,
                        Director = "Director",
                        Rating = "Rating",
                        Edited = false,
                        Lent = "Lent",
                        Notes = "Notes"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}