using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilms.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            Console.WriteLine("Start EnsurePopulated.");

            MovieDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                List<Movie> moviesToAdd = new List<Movie>();

                Movie movie1 = new Movie
                {
                    category = "Comedy",
                    title = "What About Bob?",
                    director = "Frank Oz",
                    year = 1991,
                    rating = "PG",
                    edited = false
                };

                Movie movie2 = new Movie
                {
                    category = "Action/Adventure",
                    title = "Indiana Jones and the Last Crusade",
                    director = "Steven Spielberg",
                    year = 1989,
                    rating = "PG-13",
                    edited = false
                };

                moviesToAdd.Add(movie1);
                moviesToAdd.Add(movie2);

                Console.WriteLine("Finished creating the tours.");

                context.Movies.AddRange(moviesToAdd);

                Console.WriteLine("Finished adding the tour times to the DB.");

                context.SaveChanges();

                Console.WriteLine("Finished saving changes to the DB.");
            }
        }
    }
}
