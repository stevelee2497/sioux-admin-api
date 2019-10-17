using System.Collections.Generic;

namespace Services.DTOs.Output
{
    public class PhaseOutputDto
    {
        public string Id { get; set; }

        public string BoardId { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> TaskOrder { get; set; }
    }
}