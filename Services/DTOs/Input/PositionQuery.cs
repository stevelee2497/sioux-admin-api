namespace Services.DTOs.Input
{
    public class PositionQuery : PagingQuery
    {
        public string UserId { get; set; }
    }

    public class TimeLineEventQuery : PagingQuery
    {
        public string UserId { get; set; }
    }
}