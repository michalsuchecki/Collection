using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Collection.Models
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
                    new Producer() { Name = "Other", URL = String.Empty },
                }
                .ToArray();
                
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
                    new Category() { Name = "Other" },
                }
                .ToArray();

                foreach (var cat in categories)
                {
                    context.Categories.Add(cat);
                }

                context.SaveChanges();
            }
        }
    }
}
