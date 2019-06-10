using Microsoft.EntityFrameworkCore;
using TakeOnCore.Models;
using TakeOnCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeOnFront;
using Microsoft.AspNetCore.Mvc;
using TakeOnFront.Data;

namespace TakeOnFront
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return null;
            }

            return post;
        }


        public async Task<ActionResult<IEnumerable<Post>>> GetPostsCreationTimeOrderDesc()
        {
            return await _context.Posts.OrderByDescending(x => x.CreationTime).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Post>>> GetPostsToday()
        {
            return await _context.Posts
                .Where(Post => Post.CreationTime == DateTime.Today)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Post>>> GetPostsDestinateTimeOrderDesc()
        {
            return await _context.Posts.OrderByDescending(x => x.DestinateDate).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Post>>> GetJournalPosts()
        {
            return await _context.Posts
                .Where(Post => Post.PostType == PostType.Journal)
                .OrderByDescending(time => time.CreationTime)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Post>>> GetQuestionPosts()
        {
            return await _context.Posts
                .Where(Post => Post.PostType == PostType.Question)
                .OrderByDescending(time => time.CreationTime)
                .ToListAsync();
        }

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

        public async Task PutPost(int id, Post post)
        {

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
            
        }



        public async Task PostPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

        }



        public async Task DeletePost(int id)
        {
            try
            {
                var post = await _context.Posts.FindAsync(id);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update in database: {ex.Message}");
            }
        }


        public bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
