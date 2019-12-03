using System;

namespace Services.DTOs.Output
{
    public class WorkLogOutputDto
    {
        public string Id { get; set; }

        public TimeSpan Amount { get; set; }

        public DateTimeOffset DateLog { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string TaskId { get; set; }
    }
}