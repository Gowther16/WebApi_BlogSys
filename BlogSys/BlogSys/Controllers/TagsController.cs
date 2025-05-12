using BlogSys.DTO;
using BlogSys.Models;
using BlogSys.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IRepository<Tag> _tagRepository;

        public TagsController(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _tagRepository.GetAllAsync();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null) return NotFound();
            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] TagDTO dto)
        {
            var tag = new Tag
            {
                Name = dto.Name
            };
            await _tagRepository.AddAsync(tag);
            await _tagRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTag), new { id = tag.TagId }, tag);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, [FromBody] TagDTO dto)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            tag.Name = dto.Name;
            if (id != tag.TagId) return BadRequest();
            _tagRepository.Update(tag);
            await _tagRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null) return NotFound();
            _tagRepository.Delete(tag);
            await _tagRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
