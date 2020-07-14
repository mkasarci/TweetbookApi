using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tweetbook.Contracts.V1;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Contracts.V1.Responses;
using Tweetbook.Domain;
using Tweetbook.Services;

namespace Tweetbook.Controllers.V1
{
    public class PostController : Controller
    {
        private IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public IActionResult Update([FromRoute]Guid postId, [FromBody]UpdatePostRequest request)
        {
            var post = new Post {Id = postId, Name = request.Name};
            var isUpdated = _postService.UpdatePost(post);

            if (isUpdated)
                return Ok(post);

            return NotFound();
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute]Guid postId)
        {
            var post = _postService.GetPostById(postId);
            if (post is null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post {Id = Guid.Parse(postRequest.Id)};

            if (post.Id != Guid.Empty)
                post.Id = Guid.NewGuid();

            _postService.GetPosts().Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse {Id = post.Id};

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public IActionResult Delete([FromRoute] Guid postId)
        {
            var isDeleted = _postService.DeletePost(postId);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
