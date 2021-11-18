using System.Net.Mime;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace dockerApi.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var servicesScope = app.ApplicationServices.CreateScope())
            {
                SeedData(servicesScope.ServiceProvider.GetService<ColourContext>());
            }
        }
        public static void SeedData(ColourContext context)
        {
            System.Console.WriteLine("Applying migrations ...");
            context.Database.Migrate();
            if (!context.ColourItems.Any())
            {
                System.Console.WriteLine("Adding data ...");
                context.ColourItems.AddRange(
                    new Colour() { ColourName = "Red" },
                    new Colour() { ColourName = "Orange" },
                    new Colour() { ColourName = "Yellow" },
                    new Colour() { ColourName = "Green" },
                    new Colour() { ColourName = "Black" }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already Have data - not seeding");
            }
        }
    }
}