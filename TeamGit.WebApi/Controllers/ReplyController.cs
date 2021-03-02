using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamGit.Services;

namespace TeamGit.WebApi.Controllers
{
    public class ReplyController : ApiController
    {
        [Authorize]
        private ReplyService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var comments = replyService.GetReplies();
            return Ok(comments);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
    }
}
