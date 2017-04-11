using Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Repositories
{
    public interface IProducerRepository : IDisposable
    {
        IEnumerable<Producer> GetProducers();
        Producer GetProducerByID(int Id);
        void InsertProducer(Producer producer);
        void DeleteProducer(int Id);
        void UpdateProducer(Producer producer);
        void Save();
    }
}
