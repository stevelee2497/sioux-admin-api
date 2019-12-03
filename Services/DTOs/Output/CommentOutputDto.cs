namespace Services.DTOs.Output
{
    public class CommentOutputDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string TaskId { get; set; }

        public string Content { get; set; }

        public string CreatedTime { get; set; }
    }
}