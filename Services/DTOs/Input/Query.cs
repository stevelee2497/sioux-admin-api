namespace Services.DTOs.Input
{
    public class PagingQuery
    {
        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 20;

        public string Sort { get; set; }
    }

    public class UserQuery : PagingQuery
    {
        public string Name { get; set; }

        public string PositionId { get; set; }

        public string SkillIds { get; set; }
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

    public class PhaseQuery : PagingQuery
    {
        public string BoardId { get; set; }
    }

    public class TaskQuery : PagingQuery
    {
        public string BoardId { get; set; }

        public string MemberId { get; set; }
    }

    public class LabelQuery : PagingQuery
    {
        public string BoardId { get; set; }
    }

    public class WorkLogQuery : PagingQuery
    {
        public string UserId { get; set; }
    }

    public class TaskActionQuery : PagingQuery
    {
        public string TaskId { get; set; }
    }

    public class CommentQuery : PagingQuery
    {
        public string TaskId { get; set; }  
    }
}