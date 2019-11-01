using System;

namespace Services.DTOs.Input
{
    public class TaskAssigneeInputDto
    {
        public Guid UserId { get; set; }

        public Guid TaskId { get; set; }
    }
}