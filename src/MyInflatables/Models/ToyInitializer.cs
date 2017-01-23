using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyInflatables.Models
{
    public class ToyInitializer
    {
        public static void Initialize(ToyContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Producers.Any())
            {
                var producers = new Producer[]
                {
                    new Producer() { Name = "All" },
                    new Producer() { Name = "Bestway" },
                    new Producer() { Name = "BIG MOUTH" },
                    new Producer() { Name = "Inflatable World" },
                    new Producer() { Name = "Intex" },
                    new Producer() { Name = "Puffypaws" },
                    new Producer() { Name = "RoyalBeach" },
                    new Producer() { Name = "Sevylor" },
                    new Producer() { Name = "Swimline" },
                    new Producer() { Name = "Wehncke" },
                    new Producer() { Name = "Other" }
                }.ToArray();
                /*OrderBy(s => s.Name).ToArray();*/

                foreach (var prod in producers)
                {
                    context.Producers.Add(prod);
                }

                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category() { Name = "Air mattress" },
                    new Category() { Name = "Animals" },
                    new Category() { Name = "Beach balls" },
                    new Category() { Name = "Clothes" },
                    new Category() { Name = "Furniture" },
                    new Category() { Name = "Islands" },
                    new Category() { Name = "Other" },
                    new Category() { Name = "Pools" },
                    new Category() { Name = "Rafts" },
                    new Category() { Name = "Ride-on" },
                    new Category() { Name = "Tubes" },
                }.ToArray();
                //.OrderBy(s => s.Name).ToArray();

                foreach (var cat in categories)
                {
                    context.Categories.Add(cat);
                }

                context.SaveChanges();
            }
        }
    }
}
