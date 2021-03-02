﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamGit.Models;
using TeamGit.Services;

namespace TeamGit.WebApi.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var notes = postService.GetPosts();
            return Ok(notes);
        }

        [HttpPost]
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        [HttpPost]
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }
    }
}
