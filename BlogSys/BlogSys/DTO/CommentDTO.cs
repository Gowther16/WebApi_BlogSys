namespace BlogSys.DTO
{
    public class CommentDTO
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int PostId { get; set; }
        public int UserId { get; set; }

    }
}
