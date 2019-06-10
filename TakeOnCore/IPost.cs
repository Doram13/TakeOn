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
        
        Task<ActionResult<IEnumerable<Post>>> GetPosts();
        Task<ActionResult<IEnumerable<Post>>> GetPostsDestinateTimeOrderDesc();

        Task<ActionResult<IEnumerable<Post>>> GetPostsCreationTimeOrderDesc();

        Task<ActionResult<IEnumerable<Post>>> GetJournalPosts();

        Task<ActionResult<IEnumerable<Post>>> GetQuestionPosts();

        Task<ActionResult<IEnumerable<Post>>> GetJournalPostsDestinate();
        Task<ActionResult<IEnumerable<Post>>> GetQuestionPostsDestinate();
        Task<ActionResult<Post>> GetPost(int id);
        Task PutPost(int id, Post post); //Task<IActionResult>
        Task PostPost(Post post);
        Task DeletePost(int id);
        bool PostExists(int id);



    }
}
