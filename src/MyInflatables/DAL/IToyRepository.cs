using MyInflatables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyInflatables.DAL
{
    public interface IToyRepository : IDisposable
    {
        IEnumerable<Toy> GetToys();
        Toy GetToyByID(int toyId);
        void InsertToy(Toy toy);
        void DeleteToy(int toyId);
        void UpdateToy(Toy toy);
        void Save();
    }
}
