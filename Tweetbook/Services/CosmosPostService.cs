﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public class CosmosPostService : IPostService
    {
        public Task<List<Post>> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostByIdAsync(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreatePostAsync(Post postToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(Guid postToDelete)
        {
            throw new NotImplementedException();
        }
    }
}