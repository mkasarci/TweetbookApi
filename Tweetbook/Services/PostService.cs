using System;
using System.Collections.Generic;
using System.Linq;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public class PostService : IPostService
    {
        private readonly List<Post> _posts;

        public PostService()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post Name {i}"
                });
            }
        }

        public List<Post> GetPosts()
        {
            return _posts;
        }

        public Post GetPostById(Guid postId)
        {
            return _posts.FirstOrDefault(x => x.Id == postId);
        }

        public bool UpdatePost(Post postToUpdate)
        {
            var exists = GetPostById(postToUpdate.Id) != null;
            if (!exists)
                return false;

            var index = _posts.FindIndex(x => x.Id == postToUpdate.Id);
            _posts[index] = postToUpdate;
            return true;
        }

        public bool DeletePost(Guid postId)
        {
            var post = GetPostById(postId);

            return _posts.Remove(post);
        }
    }
}