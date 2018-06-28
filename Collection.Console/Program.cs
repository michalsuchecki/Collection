using System;
using System.Linq;
using System.Collections.Generic;
using Collection.Repository.Entity.DAL;
using Collection.Repository.Entity.Repository;
using Collection.Entity.Item;

namespace Collection.Console
{
    class Program
    {
        static void ListItems(IEnumerable<Item> items)
        {
            foreach(var item in items)
            {
                System.Console.WriteLine($"Item: {item.ItemId} - {item.Name}");
            }
            System.Console.WriteLine($"Total: {items.Count()}");
        }

        static void Main(string[] args)
        {
            var context = new EntityDBContext();

            var itemRepository = new ItemRepository(context);
            var producerRepository = new ProducerRepository(context);
            var categoryRepository = new CategoryRepository(context);

            var prod = producerRepository.Search("intex").FirstOrDefault();
            var cat  = categoryRepository.Search("isla").FirstOrDefault();

            // var items = itemRepository.Search("dragon");
            //ListItems(items);

            //var itemsProd = itemRepository.GetItemsByProducer(prod);
            //ListItems(itemsProd);

            var itemCat = itemRepository.GetItemsByCategory(cat);
            ListItems(itemCat);
        }
    }
}
