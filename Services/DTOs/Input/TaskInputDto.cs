using System;

namespace Services.DTOs.Input
{
    public class TaskInputDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedTime { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public TimeSpan Estimation { get; set; }

        public TimeSpan SpentTime { get; set; }

        public string ReporterUserId { get; set; }

        public string BoardId { get; set; }
    }
}