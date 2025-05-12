using BlogSys.DTO;
using BlogSys.Models;
using BlogSys.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IRepository<Post> _postRepository;

        public PostsController(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Createpost([FromBody] PostDTO dto)
        {
            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                PublishedAt = dto.PublishedAt,
                UserId = dto.UserId
            };
            await _postRepository.AddAsync(post);
            await _postRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPost), new { id = post.PostId }, post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatepost(int id, [FromBody] PostDTO dto)
        {
            var post = await _postRepository.GetByIdAsync(id);

            post.Title = dto.Title;
            post.Content = dto.Content;
            post.PublishedAt = dto.PublishedAt;
            post.UserId = dto.UserId;

            if (id != post.PostId) return BadRequest();
            _postRepository.Update(post);
            await _postRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepost(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null) return NotFound();
            _postRepository.Delete(post);
            await _postRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
