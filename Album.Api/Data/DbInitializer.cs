using Album.Api.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Albums.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SimpleModelsAndRelationsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Albums.
            if (context.Albums.Any())
            {
                Console.WriteLine("DB has been seeded");
                return;   // DB has been seeded
            }

            var Albums = new Album.Api.Models.Album[]
            {
            new Album.Api.Models.Album{Name="Carson",Artist="Alexander",ImageUrl="Norman"},
            new Album.Api.Models.Album{Name="John",Artist="Doe",ImageUrl="Nino"},
            new Album.Api.Models.Album{Name="Doe",Artist="John",ImageUrl="Olivetto"},
            new Album.Api.Models.Album{Name="Norman",Artist="Alexander",ImageUrl="Gytis"},
            new Album.Api.Models.Album{Name="Gytis",Artist="Barzdukas",ImageUrl="Carson"}
            };
            foreach (Album.Api.Models.Album s in Albums)
            {
                context.Albums.Add(s);
            }
            Console.WriteLine("DB not has been seeded");
            context.SaveChanges();
        }
    }
}