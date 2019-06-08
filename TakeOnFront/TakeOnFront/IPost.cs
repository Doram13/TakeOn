using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeOnCore.Models;

namespace TakeOnFront
{
    public interface IPost
    {
        
        Task<Post> GetPostById(int id);
        Task<ActionResult<IEnumerable<Post>>> GetPosts();
        Task<ActionResult<IEnumerable<Post>>> GetPostsDestinateOrder();
        Task<ActionResult<Post>> GetPost(int id);
        Task<IActionResult> PutPost(int id, Post post);
        Task<ActionResult<Post>> PostPost(Post post);
        Task<ActionResult<Post>> DeletePost(int id);
        bool PostExists(int id);



    }
}
