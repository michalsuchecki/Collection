using Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Repositories
{
    public interface IToyRepository
    {
        IQueryable<Toy> GetAllToys();
        IQueryable<Toy> GetMyToys();
        IQueryable<Toy> GetMyToysByCategory(int categoryId);
        IQueryable<Toy> GetWantedToys();
        IQueryable<Toy> GetWantedToysByCategory(int categoryId);
        IQueryable<Toy> GetToysContaining(string search);

        Toy GetToyById(int toyId);
        void AddToy(Toy toy);
        void DeleteToy(int toyId);
        void UpdateToy(Toy toy);

        void Save();
        
    }
}
