using Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Repositories
{
    public interface IToyRepository
    {
        IEnumerable<Toy> GetAllToys();
        IEnumerable<Toy> GetMyToys();
        IEnumerable<Toy> GetMyToysByCategory(int categoryId);
        IEnumerable<Toy> GetWantedToys();
        IEnumerable<Toy> GetWantedToysByCategory(int categoryId);
        Toy GetToyById(int toyId);
        void AddToy(Toy toy);
        void DeleteToy(int toyId);
        void UpdateToy(Toy toy);

        void Save();
    }
}
