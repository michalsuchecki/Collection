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

            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category() { Name = "Air mattress" },
                    new Category() { Name = "Furniture" },
                    new Category() { Name = "Rafts" },
                    new Category() { Name = "Ride-on" },
                    new Category() { Name = "Tubes" },
                };

                foreach(var cat in categories)
                {
                    context.Categories.Add(cat);
                }

                context.SaveChanges();
            }
        }
    }
}
