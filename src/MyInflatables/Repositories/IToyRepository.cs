using MyInflatables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.Repositories
{
    public interface IToyRepository : IDisposable
    {
        IEnumerable<Toy> GetToys();
        IEnumerable<Toy> GetToysByCategoryId(int id);
        Toy GetToyByID(int toyId);
        void InsertToy(Toy toy);
        void DeleteToy(int toyId);
        void UpdateToy(Toy toy);
        void Save();
    }
}
