using System;
using System.Collections.Generic;

namespace Services.DTOs.Output
{
    public class TaskOutputDto
    {
        public string Id { get; set; }

        public long TaskKey { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedTime { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public TimeSpan Estimation { get; set; }

        public TimeSpan SpentTime { get; set; }

        public string ReporterUserId { get; set; }

        public string BoardId { get; set; }

        public IEnumerable<TaskAssigneeOutputDto> TaskAssignees { get; set; }

        public IEnumerable<TaskLabelOutputDto> TaskLabels { get; set; }
    }
}