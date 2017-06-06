using Collection.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collection.Services
{
    public interface IBlogService
    {
        Task PostMessage(string title, string message, Guid userId);
        IEnumerable<Post> GetMessages(int page);
        Task RemovePost(int id, Guid userId);
    }
}
