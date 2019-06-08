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
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Posts/last ??
        [HttpGet("last")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsCreationTimeOrderDesc()
        {
            return await _context.Posts.OrderByDescending(x => x.CreationTime).ToListAsync();
        }  
        
        // GET: api/Posts/lastDestinate
        [HttpGet("lastDestinate")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsDestinateTimeOrderDesc()
        {
            return await _context.Posts.OrderByDescending(x => x.DestinateDate).ToListAsync();
        }

        // GET: api/Posts
        [HttpGet("journalPostsLasts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetJournalPosts()
        {
            return await _context.Posts
                .Where(Post => Post.PostType == PostType.Journal)
                .OrderByDescending(time => time.CreationTime)
                .ToListAsync();
        }


        [HttpGet("QuestionPostsLasts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetQuestionPosts()
        {
            return await _context.Posts
                .Where(Post => Post.PostType == PostType.Question)
                .OrderByDescending(time => time.CreationTime)
                .ToListAsync();
        }
        

        [HttpGet("journalPostsDestinateLasts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetJournalPostsDestinate()
        {
            return await _context.Posts

                .Where(Post => Post.PostType == PostType.Journal)
                .OrderByDescending(time => time.DestinateDate)
                .ToListAsync();
        }


        [HttpGet("QuestionPostsDestinateLasts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetQuestionPostsDestinate()
        {
            return await _context.Posts
                .Where(Post => Post.PostType == PostType.Question)
                .OrderByDescending(time => time.DestinateDate)
                .ToListAsync();
        }



        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
