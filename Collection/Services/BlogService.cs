using Collection.Models;
using Collection.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Collection.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUserService _userService;
        private readonly IPostRepository _postRepository;

        public BlogService(IUserService userService, IPostRepository postRepository)
        {
            _userService = userService;
            _postRepository = postRepository;
        }

        public IEnumerable<Post> GetMessages(int page = 1)
        {
            if (page < 1)
                page = 1;

            var posts = _postRepository.GetAllPosts()
                        .OrderByDescending(x => x.PublishDate)
                        .Skip((page - 1) * 10)
                        .Take(10);

            return posts;
        }

        public async Task PostMessage(string title, string message, Guid userId)
        {
            if(await _userService.IsOwnerAsync(userId))
            {
                var User = await _userService.GetUserAsync(userId);

                var post = new Post()
                {
                    Author = User,
                    PublishDate = DateTime.UtcNow,
                    Topic = title,
                    Message = message
                };

                _postRepository.Add(post);
                _postRepository.Save();
            }
        }

        public async Task RemovePost(int id, Guid userId)
        {
            if (await _userService.IsOwnerAsync(userId))
            {
                var exist = (_postRepository.GetPost(id) != null);

                if (exist)
                {
                    _postRepository.Remove(id);
                    _postRepository.Save();
                }
            }
        }
    }
}
