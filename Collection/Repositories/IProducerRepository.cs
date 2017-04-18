using Collection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Repositories
{
    public interface IProducerRepository
    {
        IEnumerable<Producer> GetProducers();
        Producer GetProducerByID(int Id);
        void AddProducer(Producer producer);
        void DeleteProducer(int Id);
        void UpdateProducer(Producer producer);

        void Save();
    }
}
