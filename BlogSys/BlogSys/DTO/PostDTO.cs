namespace BlogSys.DTO
{
    public class PostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }

    }
}
