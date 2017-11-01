using Collection.Models;
using Collection.Repositories;
using System;
using System.Threading.Tasks;
using Collection.Infrastructure;

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

        public PaginatedList<Post> GetMessages(int page = 1)
        {
            if (page < 1)
                page = 1;

            page = (page - 1);

            return new PaginatedList<Post>(_postRepository.GetAllPosts(), page, 10);
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
