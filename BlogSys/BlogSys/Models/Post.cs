using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSys.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
