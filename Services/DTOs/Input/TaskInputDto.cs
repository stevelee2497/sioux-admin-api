using System;
using System.Collections.Generic;

namespace Services.DTOs.Input
{
    public class TaskInputDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public TimeSpan Estimation { get; set; }

        public string ReporterId { get; set; }

        public string BoardId { get; set; }

        public IEnumerable<Guid> Assignees { get; set; }
    }
}