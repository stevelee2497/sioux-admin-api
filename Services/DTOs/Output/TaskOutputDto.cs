using System;

namespace Services.DTOs.Output
{
    public class TaskOutputDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public TimeSpan Estimation { get; set; }

        public string ReporterId { get; set; }
    }
}