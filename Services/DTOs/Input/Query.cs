namespace Services.DTOs.Input
{
    public class PagingQuery
    {
        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 20;

        public string Sort { get; set; }
    }

    public class PositionQuery : PagingQuery
    {
        public string UserId { get; set; }
    }

    public class TimeLineEventQuery : PagingQuery
    {
        public string UserId { get; set; }
    }

    public class SkillQuery : PagingQuery
    {
        public string UserId { get; set; }
    }

    public class BoardQuery : PagingQuery
    {
        public string UserId { get; set; }
    }
}