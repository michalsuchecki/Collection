﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collection.Models;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repositories
{
    public class ToyRepository : IToyRepository, IDisposable
    {
        protected readonly ToyContext _context;

        public ToyRepository(ToyContext context)
        {
            _context = context;
        }

        public IEnumerable<Toy> GetAllToys()
        {
            return _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .OrderBy(i => i.Name)
                         .ToList();
        }

        public Toy GetToyById(int toyId)
        {
            return _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .SingleOrDefault(s => s.ToyID == toyId);
        }

        public IEnumerable<Toy> GetMyToys()
        {
            return _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .Where(i => i.InCollection)
                         .OrderBy(i => i.Name)
                         .ToList();
        }

        public IEnumerable<Toy> GetMyToysByCategory(int categoryId)
        {
            return _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .Where(i => i.InCollection && i.Category.Id == categoryId)
                         .OrderBy(i => i.Name)
                         .ToList();
        }

        public IEnumerable<Toy> GetWantedToys()
        {
            return _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .Where(i => !i.InCollection)
                         .OrderBy(i => i.Name)
                         .ToList();
        }

        public IEnumerable<Toy> GetWantedToysByCategory(int categoryId)
        {
            return _context.Toys
                         .Include(i => i.Category)
                         .Include(i => i.Producer)
                         .Include(i => i.Gallery)
                         .Where(i => !i.InCollection && i.Category.Id == categoryId)
                         .OrderBy(i => i.Name)
                         .ToList();
        }

        public void DeleteToy(int Id)
        {
            Toy toy = GetToyById(Id);
            _context.Toys.Remove(toy);
        }

        public void AddToy(Toy toy)
        {
             _context.Toys.Add(toy);
        }

        public void UpdateToy(Toy toy)
        {
            _context.Update(toy);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
