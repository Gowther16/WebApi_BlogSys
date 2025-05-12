using BlogSys.DTO;
using BlogSys.Models;
using BlogSys.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentsController(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _commentRepository.GetAllAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentDTO dto)
        {
            var comment = new Comment
            {
                Text = dto.Text,
                CreatedAt = dto.CreatedAt,
                PostId = dto.PostId,
                UserId = dto.UserId
            };
            await _commentRepository.AddAsync(comment);
            await _commentRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentDTO dto)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            comment.Text = dto.Text;
            comment.CreatedAt = dto.CreatedAt;
            comment.PostId = dto.PostId;
            comment.UserId = dto.UserId;

            if (id != comment.CommentId) return BadRequest();
            _commentRepository.Update(comment);
            await _commentRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null) return NotFound();
            _commentRepository.Delete(comment);
            await _commentRepository.SaveChangesAsync();
            return NoContent();
        }
    
    }
}
