using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSys.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
