using System;
using System.Linq;
using Collection.Repository.Entity.DAL;
using Collection.Repository.Entity.Repository;

namespace Collection.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new EntityDBContext();

            var itemRepository = new ItemRepository(context);

            var items = itemRepository.List(true).ToList();

            foreach(var item in items)
            {
                System.Console.WriteLine($"Item: {item.ItemId} - {item.Name}");
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
