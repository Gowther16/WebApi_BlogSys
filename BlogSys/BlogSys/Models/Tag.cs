using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSys.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
