using MyInflatables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.Repositories
{
    public interface IToyRepository : IDisposable
    {
        IEnumerable<Toy> GetMyToys();
        IEnumerable<Toy> GetMyToysByCategory(int categoryId);
        IEnumerable<Toy> GetWantedToys();
        IEnumerable<Toy> GetWantedToysByCategory(int categoryId);
        Toy GetToyByID(int toyId);
        void InsertToy(Toy toy);
        void DeleteToy(int toyId);
        void UpdateToy(Toy toy);
        void Save();
    }
}
