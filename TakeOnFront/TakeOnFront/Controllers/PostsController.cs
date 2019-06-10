using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeOnCore.Models;
using TakeOnFront.Data;

namespace TakeOnFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly IPost _postService;

        public PostsController(IPost postservice)
        {
            _postService = postservice;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsToday()
        {
            return await _postService.GetPosts();
        }


        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _postService.GetPosts();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            return await _postService.GetPost(id);
        }
        


        // GET: api/Posts/last ??
        [HttpGet("last")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsCreationTimeOrderDesc()
        {
            return await _postService.GetPostsCreationTimeOrderDesc();
        }  
        
        // GET: api/Posts/lastDestinate
        [HttpGet("lastDestinate")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsDestinateTimeOrderDesc()
        {
            return await _postService.GetPostsDestinateTimeOrderDesc();
        }

        // GET: api/Posts
        [HttpGet("journalPostsLasts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetJournalPosts()
        {
            return await _postService.GetJournalPosts();
        }


        [HttpGet("QuestionPostsLasts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetQuestionPosts()
        {
            return await _postService.GetQuestionPosts();
        }
        

        [HttpGet("journalPostsDestinateLasts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetJournalPostsDestinate()
        {
            return await _postService.GetJournalPostsDestinate();
        }


        [HttpGet("QuestionPostsDestinateLasts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetQuestionPostsDestinate()
        {
            return await _postService.GetQuestionPostsDestinate();
        }





        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            try
            {
                await _postService.PutPost(id, post);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        [HttpPost]
        public async Task PostPost(Post post)
        {
            await _postService.PostPost(post);
            //return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task DeletePost(int id)
        {
            await _postService.DeletePost(id);
        }

        private bool PostExists(int id)
        {
            return _postService.PostExists(id);
        }

        
    }
}
