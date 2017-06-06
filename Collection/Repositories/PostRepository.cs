using System;
using System.Linq;
using Collection.Models;
using Microsoft.EntityFrameworkCore;

namespace Collection.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ToyContext _context;

        public PostRepository(ToyContext context)
        {
            _context = context;
        }

        public IQueryable<Post> GetAllPosts()
        {
            return _context.Posts
                .Include(x => x.Author)
                .OrderBy(x => x.PublishDate);
        }

        public Post GetPost(int id)
        {
            return _context.Posts
                .Include(x => x.Author)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Update(Post post)
        {
            _context.Update(post);
        }

        public void Remove(int id)
        {
            var post = GetPost(id);
            _context.Posts.Remove(post);
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
